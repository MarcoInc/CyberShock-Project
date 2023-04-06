using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//simple T800 enemy manager
public class T800 : Enemy {
	[SerializeField] public GameObject bulletLeft;
	public GameObject ShotPoint;
	Vector2 bulletPos;

	void Awake(){
		animator = GetComponent<Animator>();
	}

	void FixedUpdate(){
		animate();
		attack();
		if(hitted){
			if(health==6)
				SoundManager.instance.T800LowEnergy();
		}
	}

	void Start(){	
		health=8;
	}

	override public void animate(){
		animator.SetBool("isDied", isDied);
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

	override public void die(){				
		Debug.Log("T800 IS DEAD!");
		animator.Play("Dead");
		isDied=true;
		SoundManager.instance.T800Death();
		Destroy(gameObject,0.5f);
		Status.instance.AddPoints(10);
	}	
}
