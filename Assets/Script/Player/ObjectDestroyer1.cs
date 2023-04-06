using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//to destroy disk3 and teleport
public class ObjectDestroyer1 : MonoBehaviour {
	//singleton
	public static ObjectDestroyer1 instance;

	[SerializeField] GameObject [] objects;
	[SerializeField] GameObject thisScript;

	void Awake(){
		instance=this;
	}

	void FixedUpdate(){
		if(GameObject.Find("Disk3") == null){	
			Detroyer();
		}				
	}
	
	public void Detroyer(){
		for(int i=0;i<objects.Length;i++){
			Destroy(objects[i].gameObject);
			Debug.Log("OBJECT "+i+" DESTROYED");
		}
		thisScript.SetActive(false);
	}
}
