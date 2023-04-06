using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//used to move text on intro
public class move_Text : MonoBehaviour {
	public float y;
	[SerializeField] RectTransform canvas;
	// Use this for initialization
	void Start () {				
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		//Debug.Log("y"+canvas.position.y);
		move();	
	}

	void move(){
	if(canvas.position.y < -5.189869) 
		transform.Translate(0,y*Time.deltaTime,0);
	}
}

