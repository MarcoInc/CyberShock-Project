using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//camaera manager
public class CameraMoving : MonoBehaviour {

	public Transform target;
	public Vector3 offset;
	[Range(1,10)]
	public float smoothFactor;

	public void FixedUpdate(){
		Follow();
	}

	public void Follow(){
		Vector3 targetPosition=target.position + offset;
		Vector3 smoothPosition=Vector3.Lerp(transform.position,targetPosition,smoothFactor*Time.fixedDeltaTime);
		transform.position=smoothPosition;
	}
	
}
