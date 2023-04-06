using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//to move a teleport obj
public class TeleportMove : Teleport {

  float speed=6;
  
      public void FixedUpdate(){
	  move();
	  }
       
	  void move(){
		     float y = Mathf.PingPong((Time.time+3.574494f)*speed, 10);
          	 this.transform.position = new Vector2(116.44f, y);
	  } 
}

