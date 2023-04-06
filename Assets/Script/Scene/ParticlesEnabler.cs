using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//to enable/disable all particles on scene
public class ParticleSwitch : MonoBehaviour {
	[SerializeField] public ParticleSystem [] ParticlesArray;
	// Use this for initialization
	void Start () {
		filler();
		if(SaveGame.GetParticles()==true){
			Switch(true);
		}
		if(SaveGame.GetParticles()==false){
			Switch(false);
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void Switch(bool switcher){
		for(int i=0;i<ParticlesArray.Length;i++){
			ParticlesArray[i].gameObject.SetActive(switcher);
		}
	}

	public void filler(){
		GameObject[] find = GameObject.FindGameObjectsWithTag("Particle");
 		ParticlesArray = new ParticleSystem[find.Length];
 		for (int i = 0; i < find.Length; i++) {
    		ParticlesArray[i] = find[i].GetComponent<ParticleSystem>();
		 }
 	}
		

}
