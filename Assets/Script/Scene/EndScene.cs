using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//if the game is over with success
public class EndScene : MonoBehaviour {

	string yourName;
	void Start(){
		Screen.fullScreen = SaveGame.GetFullScreen();
	}

	public void ReturnToMenu(string scene){
		Rank.insertPoint(PlayerPrefs.GetInt("TempPoints"), yourName);
		SceneManager.LoadScene (scene);
	}
	public void ReturnToMenu(int i){
		Rank.insertPoint(PlayerPrefs.GetInt("TempPoints"), yourName);
		SceneManager.LoadScene (i);
	}

	public void TextName(string name){
		yourName = name;
	}
}
