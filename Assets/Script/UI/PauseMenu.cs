using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

//pause menù manager
public class PauseMenu : MonoBehaviour {

	public static bool isPaused = false;
	public GameObject menuUI;

	void Update () {
		if(Input.GetKeyDown(KeyCode.Escape)){		//check ESC key
			if(!isPaused){
				pause();
			}
			else{
				resume();
			}
		}	
	}

	public void resume(){
		menuUI.SetActive(false);
		Time.timeScale = 1;
		isPaused = false;
	}

	void pause(){
		menuUI.SetActive(true);
		Time.timeScale = 0;
		isPaused = true;
	}


	public void QuitGame(){
		Time.timeScale = 1;
		Application.Quit();
	}

	//return on main menù
	public void ReturnToMenu(string name){
		menuUI.SetActive(false);
		Time.timeScale = 1;
		isPaused = false;
		SaveGame.DeactiveCheckpoints();
		SceneManager.LoadScene (name);
	}
	//overloading
	public void ReturnToMenu(int i){
		menuUI.SetActive(false);
		Time.timeScale = 1;
		isPaused = false;
		SaveGame.DeactiveCheckpoints();
		SceneManager.LoadScene (i);
	}
}
