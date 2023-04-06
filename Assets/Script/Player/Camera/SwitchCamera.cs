using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//used to move camera if he teleports too far
public class SwitchCamera : MonoBehaviour {
	[SerializeField] Camera Camera;
	[SerializeField] GameObject PortalEnter;
	[SerializeField] GameObject PortalExit;
	CameraMoving script;

	void Start () {
		script = GetComponent<CameraMoving>();
		script.enabled = true;		
	}
	
	void FixedUpdate(){
		Switch();
	}
	
	void Switch(){
		if (!PortalExit){
			script.enabled=true;
		}
		else if (!PortalEnter){
    		script.enabled=true;
		}
	}	
}
