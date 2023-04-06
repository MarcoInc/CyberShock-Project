using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

//at start of game
public class IntroManager : MonoBehaviour {

	public string gamemenuscene= "GameMenu";

	void Start(){
		Screen.fullScreen = SaveGame.GetFullScreen();		
	}

	void Update(){
		if(Input.GetKeyDown(KeyCode.Escape)){		//check ESC key
			SceneManager.LoadScene(gamemenuscene);
		}
	}

	public void SkipButton(int i){
		SceneManager.LoadScene(i);	
	}
	//overloading
	public void SkipButton(string i){
		SceneManager.LoadScene(i);	
	}
}
