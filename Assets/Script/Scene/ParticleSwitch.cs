using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//particles manager
public class ParticlesEnabler : MonoBehaviour {
	[SerializeField] ParticleSystem [] ParticlesArray;
	bool switcher=false;

	// Use this for initialization
	void Start () {
		Switch();	
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	//enable/disable particles
	public void Switch(){
		for(int i=0;i<ParticlesArray.Length;i++){
			ParticlesArray[i].gameObject.SetActive(switcher);
		}
	}
}
