using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//enemy animations
public interface IEnemy{
	void die();
	void attack();
	void isHit ();
	void move();
	void animate();
}
