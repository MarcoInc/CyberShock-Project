using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//to set background music in-game
public class SwitchMusic : MonoBehaviour {
	[SerializeField] GameObject PortalEnter;
	[SerializeField] GameObject PortalExit;
	[SerializeField] AudioSource Main;
	[SerializeField] AudioSource Secret;

	void Start () {
		//Main = GetComponent<AudioSource>();
		Main.enabled=true;
		//Secret = GetComponent<AudioSource>();
		Secret.enabled=false;
	}

	void FixedUpdate(){
		Switch();
	}

	void Switch(){
		if (!PortalExit){
			Secret.enabled=false;
			Main.enabled=true;
		}
		else if (!PortalEnter){
    			Main.enabled = false;
				Secret.enabled=true;
		}
	}	
}
