using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//if lives==0
public class DeathScene : MonoBehaviour {
	[SerializeField] public GameObject InputField;

	string myname;
	void Start(){
		if((PlayerPrefs.GetInt("TempPoints")<=0))			//input field appears only if more than 0 points have been scored
			InputField.SetActive(false);
		if((PlayerPrefs.GetInt("TempPoints")>0))
			InputField.SetActive(true);
		Screen.fullScreen = SaveGame.GetFullScreen();
		Debug.Log("SCORE :"+PlayerPrefs.GetInt("TempPoints"));
	}

	public void ReturnToMenu(string scene){
		Rank.insertPoint(PlayerPrefs.GetInt("TempPoints"), myname);
		SceneManager.LoadScene (scene);
	}
	public void ReturnToMenu(int i)	{
		Rank.insertPoint(PlayerPrefs.GetInt("TempPoints"), myname);
		SceneManager.LoadScene (i);
	}

	//to set a record name
	public void TextName(string name){
		myname = name;
	}
}
