using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

	//singleton
	public static PlayerController instance;

	public BoxCollider2D Stand;
	public BoxCollider2D Crouch;
	public GameObject Character;
	public Rigidbody2D rb2d;
	public float speed;
	public Animator animator;
	public Collider2D colliderPG;

	public static float direction=1;
	public string dir="Right";
	public bool isRight;
	public bool diagonal=false;
	public bool up=false;
	public bool isMove=false;
	public bool crouch=false;
	public bool end;

	[SerializeField] GameObject ShotPointStand;
	[SerializeField] GameObject ShotPointCrouch;
	[SerializeField] GameObject ShotPointDiagonal;
	[SerializeField] GameObject ShotPointUp;
	public GameObject bulletRight, bulletLeft, bulletDiagonalRight, bulletDiagonalLeft, bulletUp;
	Vector2 bulletPos;
	public float fireRate;
	float nextFire=0.0f;

	private float deathTime;

	public int health;
	public int lives;
	public bool death;
	public bool hit;


	void Awake() {
		instance = this;
	}

	void Start(){
		Status.instance.SetDied("");
		rb2d = GetComponent<Rigidbody2D>();
		colliderPG = GetComponent<Collider2D>();
		Debug.Log("START CHECKPOINT: "+SaveGame.GetCheckpoints());
		death = false;
		end=false;
		
		//to resume from the last active checkpoint
		if(SaveGame.GetCheckpoints() == 1){ 
			rb2d.position = new Vector3(SaveGame.GetX(), SaveGame.GetY(), SaveGame.GetZ());
			Status.instance.AddLives(SaveGame.GetLives());
			Status.instance.AddHealth(SaveGame.GetHealth());
			Status.instance.AddPoints(SaveGame.GetPoints());
		}
		else{   //starts from the beginning if there are no active checkpoints
			Status.instance.AddLives(SaveGame.GetLives());
			Status.instance.AddHealth(SaveGame.GetHealth());
		}
	}

	void Update(){
		if(hit){
			if(Status.instance.GetHealth()>0)
				SoundManager.instance.PlayerHit();
			StartCoroutine(HitSprite());
		}
		else if(death){		//if player dies
			Debug.Log("Death");
			StartCoroutine(PausePostDeath());			
		}
		Debug.Log("ACTUAL POSITION -> X: "+SaveGame.GetX()+" , Y: "+SaveGame.GetY()+" Z:"+SaveGame.GetZ());	
	}

	void FixedUpdate(){
		movement();		
		colliderControl();
		shooting();
		anim();
		
		if(Time.time > (deathTime + 3f)&& death){	//if timeout
			Debug.Log("Time Out!");
			deathAnimation();
			postDie();
		}
	}

	void movement(){
		Vector3 characterScale=transform.localScale;
		if(Input.GetAxis("Horizontal")<0){
			direction=-1f;
			dir="Left";
			isRight=false;
			characterScale.x=-3.5f;
			if(Input.GetKey(KeyCode.DownArrow)==false){  
				rb2d.AddForce(Vector2.left*speed*Time.deltaTime);
				isMove=true;
			}
		}
		else{
			rb2d.velocity = Vector2.zero;
		}
		if(Input.GetAxis("Horizontal")>0){
			direction=1f;
			dir="Right";
			isRight=true;
			characterScale.x=3.5f;
			if(Input.GetKey(KeyCode.DownArrow)==false){
				rb2d.AddForce(Vector2.right*speed*Time.deltaTime);	
				isMove=true;
			}
		}
		else{
			rb2d.velocity = Vector2.zero;
		}

		transform.localScale=characterScale;

		if(Input.GetAxis("Horizontal")==0){
			isMove=false;
		}
		//standed
		if(Input.GetKey(KeyCode.DownArrow)){
			crouch=true;
		}
		else{
			crouch=false;
		}
		//diagonal
		if(((Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow)) && Input.GetKey(KeyCode.UpArrow)) && !crouch ){
			diagonal=true;
		}
		else {
			diagonal=false;
		}	
		//up
		if (Input.GetKey(KeyCode.UpArrow) && !Input.GetKey(KeyCode.RightArrow) && !Input.GetKey(KeyCode.LeftArrow) && !crouch){
			up=true;
		}
		else {
			up=false;
		}	
	}

	//animation
	void anim(){
		animator.SetFloat("Speed", Mathf.Abs(Input.GetAxis("Horizontal")));
		animator.SetBool("Down",Input.GetKey(KeyCode.DownArrow));
		animator.SetBool("Diagonal",diagonal);
		animator.SetBool("Up",up);
	}	

	//to determine the entry location in a portal for the right direction in bringing the exit
	public float GetdirPortal(){
		 return direction;
	}

	void colliderControl(){
		if(!crouch){
			Stand.enabled=true;
			Crouch.enabled=false;
		}else if(crouch){
			Stand.enabled=false;
			Crouch.enabled=true;
		}
	}

	void shooting(){
		if((Input.GetButtonDown("Fire1") || Input.GetButton("Fire1")) && Time.time>nextFire) {
			nextFire=Time.time+fireRate;
			fire();
		}
	}

	void fire(){
		if(!crouch && !diagonal && isMove){
			bulletPos=ShotPointStand.transform.position;
			if(direction==-1f){
				bulletPos+=new Vector2(0,0);
				Instantiate(bulletRight, bulletPos, Quaternion.Euler(0,0,0));
			}
			else{
				bulletPos+=new Vector2(0,0);
				Instantiate(bulletLeft, bulletPos, Quaternion.Euler(0,0,0));
			}
		}
		if(!isMove && !up && !crouch){
			bulletPos=ShotPointStand.transform.position;
			if(direction==-1f){
				bulletPos+=new Vector2(0,0);
				Instantiate(bulletRight, bulletPos, Quaternion.Euler(0,0,0));
			}
			else{
				bulletPos+=new Vector2(0,0);
				Instantiate(bulletLeft, bulletPos, Quaternion.Euler(0,0,0));
			}
		}
		if(crouch){
			bulletPos=ShotPointCrouch.transform.position;
			if(direction==-1f){
				bulletPos+=new Vector2(0,0);
				Instantiate(bulletRight, bulletPos, Quaternion.Euler(0,0,0));		
			}
			else{
				bulletPos+=new Vector2(0,0);
				Instantiate(bulletLeft, bulletPos, Quaternion.Euler(0,0,0));
			}
		}
		if(diagonal){
			bulletPos=ShotPointDiagonal.transform.position;
			if(direction==-1f){
				bulletPos+=new Vector2(0,0);
				Instantiate(bulletDiagonalLeft, bulletPos, Quaternion.Euler(0,0,315));
			}
			else{
				bulletPos+=new Vector2(0,0);
				Instantiate(bulletDiagonalRight, bulletPos, Quaternion.Euler(0,0,45));
			}	
		}
		if(up){
			bulletPos=ShotPointUp.transform.position;
			bulletPos+=new Vector2(0,0);
			Instantiate(bulletUp, bulletPos,Quaternion.Euler(0,0,270));
		}
	}

	public void isHit(){
			if(!death)
				Status.instance.RemoveHealth();
				Status.instance.RemovePoints(1);
			hit = true;
			if(Status.instance.GetHealth() <= 0 ){
				SoundManager.instance.PlayerDeath();
				death = true;
				Status.instance.SetDied("YOU DIED!");
				deathTime = Time.time;
				deathAnimation();
            	Debug.Log("You DIED");
				Debug.Log(SaveGame.GetLives());
			}	
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.tag == "Enemy") {			//if Enemy is touched
			Debug.Log("Enemy has touch you!");
			isHit();
		}
		if (other.gameObject.tag == "EnemyBullet"){	//if EnemyBullet is touched 
			Debug.Log("Enemy has hit you!");
			other.gameObject.SetActive(false);
			isHit();
		}
		if (other.gameObject.tag == "Medikit") {		//if Medikit is touched 
			Debug.Log("Cured!");
			hit = false;
			if(SaveGame.GetDifficult()==1){				//if normal mode
				if(Status.instance.GetHealth()<10){				
					SoundManager.instance.PW_UP_HP();
					if(Status.instance.GetHealth()<=8){
						Status.instance.AddHealth(2);
					}
					if(Status.instance.GetHealth()==9){
						Status.instance.AddHealth(1);
					}
					Destroy(other.gameObject);
				}
			}
			if(SaveGame.GetDifficult()==2){				//if deus-ex mode
				if(Status.instance.GetHealth()<6){				
					SoundManager.instance.PW_UP_HP();
					if(Status.instance.GetHealth()<=4){
						Status.instance.AddHealth(2);
					}
					if(Status.instance.GetHealth()==5){
						Status.instance.AddHealth(1);
					}
					Destroy(other.gameObject);	
				}
			}
				
		}
		if (other.gameObject.tag == "Finish") {
			Debug.Log("End Level!");
			hit = false;	
			end=true;						//end of level
			Status.instance.end();
		}	
		if (other.gameObject.tag == "Lives") {		//if a Life 1UP obj is touched
			Debug.Log("+1UP!");
			hit = false;
			SoundManager.instance.PW_UP_LIVE();
			Status.instance.AddLives(1);
			Destroy(other.gameObject);
			
		}
		if (other.gameObject.tag == "Checkpoint") {	//if Checkpoint obj is touched
			Checkpoint.savePoint();
			Debug.Log("PICKED CHECKPOINT: "+SaveGame.GetCheckpoints());
			Debug.Log("SAVED POSITION -> X: "+SaveGame.GetX()+" , Y: "+SaveGame.GetY()+" Z:"+SaveGame.GetZ());
			hit = false;
			SoundManager.instance.PW_UP_CHECKPOINT();
			Destroy(other.gameObject);
		}
	}

	public void deathAnimation(){
		//SoundManager.instance.soundPlayerDeath();
		animator.Play("Death");
		
	}

	public void postDie(){
		if(Status.instance.GetLives() > 0 && SaveGame.GetCheckpoints() == 1){		//if I have lives -> Continue scene
			Debug.Log("Continue Scene");
			Debug.Log("CONTINUE CHECKPOINT: "+SaveGame.GetCheckpoints());
			Status.instance.RemovePoints(50);
			PlayerPrefs.SetInt("TempPoints", Status.instance.GetPoints());
			SceneManager.LoadScene("Continue");
		}
		else{
			PlayerPrefs.SetInt("TempPoints", Status.instance.GetPoints());	//if I haven't lives ->  Death scene
			Debug.Log("Death Scene");
			Debug.Log("DEATH CHECKPOINT: "+SaveGame.GetCheckpoints());
			SaveGame.DeactiveCheckpoints();
			SceneManager.LoadScene("Death");
		}
	}

	//animation if Player is hitted
	IEnumerator HitSprite(){
		GetComponent<SpriteRenderer>().color = Color.blue;
		yield return new WaitForSeconds(0.3f);
		GetComponent<SpriteRenderer>().color = Color.white;
		hit= false;
	}

	IEnumerator PausePostDeath(){
		yield return new WaitForSeconds(1.2f);
		postDie();
	}
}