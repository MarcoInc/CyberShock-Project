using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//generic enemy manager
public class Enemy : MonoBehaviour,IEnemy {
	[SerializeField] public float speed;
	[SerializeField] public Rigidbody2D rb2d;
	protected Transform player;
	public Collider2D hitbox;
	public string direction;
	protected bool isLeft=true;
	public int points;
	public bool hitted;
	public bool isDied;
	public int health;
	public float fireRate;
	public bool isShot;
	public Animator animator;
	public float nextFire=0.0f;

	void Awake(){
		isDied=false;
		hitted = false;
		rb2d = GetComponent<Rigidbody2D>();
		hitbox = GetComponent<Collider2D>();
		player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
	}

	void Update(){
		if(hitted){
			StartCoroutine(HitSprite());
		}
		else if(health <= 0 && !isDied)
			die();
	}

	void Start(){
		rb2d = GetComponent<Rigidbody2D>();
		hitbox = GetComponent<Collider2D>();
	}

	virtual public void isHit(){						//se è colpito
		hitted = true;
		health -= 1;	
	}

	virtual public void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.tag == "Player") {			//se tocca il player
			//PlayerController.instance.isHit();
		}else if (other.gameObject.tag == "BulletPlayer"){	//se tocca un bulletplayer
			other.gameObject.SetActive(false);
			isHit();
			hitted = true;
		}
		else{
			hitted = false;
		}
	
	}

	virtual public void die(){							//se finisce gli hp
		Debug.Log("ENEMY IS DEAD!");
		isDied=true;
		Status.instance.AddPoints(points);
		Destroy(gameObject,0.5f);
	}

	public void flip(){				//non usato
		isLeft = !isLeft;
		transform.Rotate(0,180,0);
		if(isLeft)
			direction="Left";
		else if(!isLeft)
			direction="Right";
	}

	IEnumerator HitSprite() {
 		GetComponent<SpriteRenderer>().color = Color.red;
 		yield return new WaitForSeconds(0.1f);
 		GetComponent<SpriteRenderer>().color = Color.white;
		hitted = false;
 	}

	virtual public void attack(){
	}
	virtual public void move(){
	}
	virtual public void animate(){
	}

}
