using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//on tutorial
public class TutorialScene : MonoBehaviour {
	[SerializeField] private GameObject item1, item2, item3, item4, item5, robocop;

	void Awake(){
	}

	void Start(){
		Screen.fullScreen = SaveGame.GetFullScreen();

		SaveGame.DeactiveCheckpoints();
		item1.SetActive(false);
		item2.SetActive(false);
		item3.SetActive(false);
		item4.SetActive(false);
		item5.SetActive(false);
	}

	public void ReturntoMenu(){
		item4.SetActive(false);
		item5.SetActive(false);
		SceneManager.LoadScene ("GameMenu");
	}

	public void toPage2(){
		item1.SetActive(true);
		item2.SetActive(true);
		item3.SetActive(true);
	}
	
	public void toPage3(){
		item1.SetActive(false);
		item2.SetActive(false);
		item3.SetActive(false);
		item4.SetActive(true);
		item5.SetActive(true);
	}
}
