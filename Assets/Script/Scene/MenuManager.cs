using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Audio;

public class MenuManager : MonoBehaviour {
	const int DIM_RANK = 5;
	const int EASY = 1;
	const int HARD = 2;
	

	[SerializeField] Text [] RankEntry = new Text [DIM_RANK];
	[SerializeField] Text [] RankEntryName = new Text [DIM_RANK];

	
	[SerializeField] private AudioClip  music;

	void Awake(){

	}
	void Start(){
		Screen.fullScreen = SaveGame.GetFullScreen();
		PrintRank();		
	}

	void Update(){
	}

	public void PlayEasy(){
		SaveGame.SaveDifficult(EASY);
		SaveGame.DeactiveCheckpoints();
		SceneManager.LoadScene ("Game");
	}

	public void PlayHard(){
		SaveGame.SaveDifficult(HARD);
		SaveGame.DeactiveCheckpoints();
		SceneManager.LoadScene ("Game");
	}

	public void SaveDifficult(int difficult){
		if(difficult == 0) 
			difficult=1;
		SaveGame.SaveDifficult(difficult);
	}

	public void PlayTutorial(int i){
		SaveGame.DeactiveCheckpoints();		//altrimenti si spawna in coordinate sbagliate se ci sono checkpoint precedenti
		SceneManager.LoadScene(3);
	}

	public void PlayTutorial(string i){
		SaveGame.DeactiveCheckpoints();		//altrimenti si spawna in coordinate sbagliate se ci sono checkpoint precedenti
		SceneManager.LoadScene(i);
	}
   
	public void QuitGame(){
		Application.Quit();
		Debug.Log("I have exit");

	}
	public void PrintRank(){						//invocato allo start e stampa il rank
		for(int i = 0; i < DIM_RANK; i++){
			RankEntry[i].text = SaveGame.GetRankPoints(i).ToString();
			RankEntryName[i].text = SaveGame.GetRankNames(i);
		}
	}

	public void FlushRank(){			//cancella i record del rank
		SaveGame.FlushRank();
	}   
}
	
