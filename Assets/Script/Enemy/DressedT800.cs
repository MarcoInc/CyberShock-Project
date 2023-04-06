using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//black T800 manager
public class DressedT800 : Enemy {
	[SerializeField] public GameObject bulletLeft, bulletRight;
	public GameObject ShotPoint;
	Vector2 bulletPos;

	public float timeWalk;
	public bool isWalk;
	
	void Awake(){
		animator = GetComponent<Animator>();
	}
	
	void FixedUpdate(){
		move();
		animate();
		attack();
		if(hitted){
			if(health==6)
				SoundManager.instance.DressedT800LowEnergy();
		}
	}

	void Start () {	
		health=12;	
		isWalk=true;
	}

	override public void animate(){
		animator.SetBool("isWalk", isWalk);
		animator.SetBool("isDied", isDied);
	}
	
	override public void move(){
 		timeWalk -= Time.deltaTime;
        if(timeWalk>=0) {
			isWalk=true;
			rb2d.AddForce(Vector2.left*speed*Time.deltaTime);	
		}
		else{
			rb2d.velocity=Vector2.zero;	
			isWalk=false;
		}
	}

	override public void attack(){
		if(Time.time>nextFire) {
			bulletPos=ShotPoint.transform.position;
			nextFire=Time.time+fireRate;
			bulletPos+=new Vector2(0,0);
			Instantiate(bulletLeft, bulletPos, Quaternion.Euler(0,0,0));
			isShot=true;
		}
		else{
			isShot=false;
		}
	}

	override public void die(){							//se finisce gli hp
		Debug.Log("DRESSEDT800 IS DEAD!");
		animator.Play("Dead");
		isDied=true;
		SoundManager.instance.DressedT800Death();
		Destroy(gameObject,0.5f);
		Status.instance.AddPoints(15);
	}		
}
