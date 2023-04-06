using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//enemy bullets manager
public class OtherBullet : MonoBehaviour {
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
		Destroy(gameObject,5f);
	}

	void OnTriggerEnter2D(Collider2D Player){
		if (Player.gameObject.tag == "Player"){
			Destroy(gameObject);			
		}
	}
}
