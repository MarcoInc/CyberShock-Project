using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//teleport manager
public class Teleport : MonoBehaviour {

	public GameObject Portal;
	public GameObject Player;
	public float exitDir;
	public bool selfDestroy;
	public bool dissapperExit;

	void Start () {
	}
	
	void Update () {
	}

	public void OnTriggerEnter2D(Collider2D other)	{
		if (other.gameObject.tag == "Player") {
			SoundManager.instance.Teleport();
			StartCoroutine (Teleportation ());		
		}
	}

	public IEnumerator Teleportation(){
		yield return new WaitForSeconds(0.5f);
		exitDir=PlayerController.direction;  //to check player direction 
		Player.transform.position = new Vector2 (Portal.transform.position.x+1.6f*exitDir, Portal.transform.position.y);
		if(selfDestroy==true){
				gameObject.SetActive(false);
				Destroy(gameObject);
		}
		if(dissapperExit==true){
				Portal.SetActive(false);
				Destroy(Portal);
		}
	}
}

 
