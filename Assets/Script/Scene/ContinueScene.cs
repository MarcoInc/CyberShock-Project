using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

// lives>=0
public class ContinueScene : MonoBehaviour {

	[SerializeField] Text lives_text;

	void Start () {
		Screen.fullScreen = SaveGame.GetFullScreen();
		lives_text.text = (SaveGame.GetLives()-1).ToString();
	}
	
	public void No(string name){
		SaveGame.DeactiveCheckpoints();
		SceneManager.LoadScene (name);
	}

	//overloading
	public void No(int i){
		SaveGame.DeactiveCheckpoints();
		SceneManager.LoadScene (i);
	}

	public void Yes(string scene){
		SaveGame.ActiveCheckpoints();
		SaveGame.SaveLives((SaveGame.GetLives()-1));
		SceneManager.LoadScene (scene);
	}

	//overloading
	public void Yes(int i){
		SaveGame.ActiveCheckpoints();
		SaveGame.SaveLives((SaveGame.GetLives()-1));
		SceneManager.LoadScene (i);
	}
}
