using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//to destroy disk2 an teleport
public class ObjectDestroyer2 : MonoBehaviour {
	//singleton
	public static ObjectDestroyer2 instance;

	[SerializeField] GameObject [] teleports;
	[SerializeField] GameObject thisScript;

	void Awake(){
		instance=this;
	}

	void FixedUpdate(){
		if(GameObject.Find("Disk2") == null){
			Detroyer();
		}				
	}
	
	public void Detroyer(){
		for(int i=0;i<teleports.Length;i++){
			Destroy(teleports[i].gameObject);
			Debug.Log("Teleport "+i+" DESTROYED");
		}
		thisScript.SetActive(false);
	}
}
