using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//to move car obj
public class move_car : MonoBehaviour {
	 public float delta;  // amount to move left and right from the start point
     public float speed; 
     private Vector3 startPos;
 
     void Start () {
         startPos = transform.position;
     }
     
     void Update () {
         Vector3 v = startPos;
         v.y += delta * Mathf.Sin (Time.time * speed);
         transform.position = v;
     }
	
}

