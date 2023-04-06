using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//T800 shooting diagonally on flying cars manager
public class T800Diagonal : Enemy {
	[SerializeField] public GameObject bulletDiagonalLeft; 
	public GameObject ShotPoint;
	Vector2 bulletPos;

	void Awake(){
		animator = GetComponent<Animator>();
	}

	void FixedUpdate(){
	animate();
	attack();
	if(hitted){
		if(health==4)
			SoundManager.instance.T800LowEnergy();
		}
	}

	void Start(){
		health=6;	
	}

	override public void animate(){
		animator.SetBool("isDied", isDied);
	}

	override public void attack(){
		if(Time.time>nextFire) {
			bulletPos=ShotPoint.transform.position;
			nextFire=Time.time+fireRate;
			bulletPos+=new Vector2(0,0);
			Instantiate(bulletDiagonalLeft, bulletPos, Quaternion.Euler(0,0,45));
			isShot=true;
		}
		else{
			isShot=false;
		}
	}

	override public void die(){			
		Debug.Log("T800DIAGONAL IS DEAD!");
		animator.Play("Dead");
		isDied=true;
		SoundManager.instance.T800Death();
		Destroy(gameObject,0.5f);
		Status.instance.AddPoints(15);
	}
}
