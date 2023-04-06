using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//to manage a bullet obj
public class Bullet : MonoBehaviour {
	public Collider2D bulletCollider;
	public float speedX;
	public float speedY;
	Rigidbody2D rb2d;

	void Start () {
		rb2d = GetComponent<Rigidbody2D>();
		bulletCollider = GetComponent<Collider2D>();
	}
	
	void Update () {
		rb2d.velocity=new Vector2(speedX,speedY);
		Destroy(gameObject,4.5f);
		
	}
	
	void OnTriggerEnter2D(Collider2D enemy){
		if (enemy.gameObject.tag == "Enemy"){
			Destroy(gameObject);			
		}
	}
}
