using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Audio;

public class DisclaimerScene : MonoBehaviour{
     public float delay;
	 float currentTime;
	 int sec;
	 [SerializeField] Text seconds;

     public string introScene= "Intro";

     void Start(){
		Screen.fullScreen = SaveGame.GetFullScreen();
		currentTime=(float)delay;	
		sec=0;
		PrintSec();
        StartCoroutine(LoadLevelAfterDelay(delay));
     }

	 void FixedUpdate(){
		Timer();
	 	if(Input.GetKeyDown(KeyCode.Escape)){		//check ESC key
			SceneManager.LoadScene(introScene);
		}
	 }
	
    IEnumerator LoadLevelAfterDelay(float delay){
         yield return new WaitForSeconds(delay);
         SceneManager.LoadScene(introScene);
     }

	public void PrintSec(){						//call at start and prints the rank
		
	}

	//countdown
	public void Timer(){
		currentTime -= 1 * Time.deltaTime;
		sec = ((int)currentTime % 60)+1;
		seconds.text = sec.ToString("0");
	}
	
 }