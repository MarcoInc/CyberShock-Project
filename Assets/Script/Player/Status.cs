using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

//player status manager
public class Status : MonoBehaviour {
	//singleton
	public static Status instance;

	[SerializeField] Text points_text, health_text,lives_text,whydied_text, mission_complete_text;
	private int points,health,lives;
	private string why_died, mission_complete;

	float currentTime;
	[SerializeField] public int startTime;
	[SerializeField] Text dots,min_text, sec_text;
	int min, sec;
	[SerializeField] GameObject particleComplete;
	float timeChar=0.15f;

	void Awake(){
		instance=this;

		min=sec=0; 
		
		if(SaveGame.GetCheckpoints() == 1){
			startTime = SaveGame.GetTimer();
		}	
		if(SaveGame.GetCheckpoints() == 0){
			if(SaveGame.GetDifficult()==1){
					SaveGame.SaveHealth(10);
					SaveGame.SaveLives(4);
			}
			if(SaveGame.GetDifficult()==2){
					SaveGame.SaveHealth(6);
					SaveGame.SaveLives(2);
			}
		}		
	}

	void Start() {
		currentTime=(float)startTime;				//countdown starts
		particleComplete.SetActive(false);	
	}

	void FixedUpdate () {
		Timer();									//this makes time go by
		if(sec == 0 && min == 0){					//check if timeout
			PlayerController.instance.deathAnimation();
			StartCoroutine(PausePostDeath());
			//PlayerController.instance.postDie();
		}
		died();
		
	}
	
	//POINT
	public void AddPoints(int ptToAdd){
		points += ptToAdd;
		points_text.text = points.ToString();
	}
	public int GetPoints(){
		return points;
	}
	public void RemovePoints(int x){
		points -= x;
		points_text.text = points.ToString();
	}

	//HEALTH
	public void AddHealth(int HpToAdd){
		health += HpToAdd;
		health_text.text = health.ToString();
	}
	public void RemoveHealth(){
		health -= 1;
		health_text.text = health.ToString();
	}
	public int GetHealth(){
		return health;
	}

	//LIVES
	public void AddLives(int livesToAdd){
		lives += livesToAdd;
		lives_text.text = lives.ToString();
	}
	public void RemoveLives(){
		lives -= 1;
		lives_text.text = lives.ToString();
	}
	public int GetLives(){
		return lives;
	}

	//TIME MANAGER
	public int GetMinutes(){
		return min;
	}
	public int GetSeconds(){
		return sec;
	}
	public void SetCurrentTime(int time){
		currentTime = time;
	}
	private void Timer(){
		currentTime -= 1 * Time.deltaTime;
		min = ((int) currentTime / 60);
		sec = ((int)currentTime % 60);
		min_text.text = min.ToString("00");
		sec_text.text = sec.ToString("00");
		if(sec == 59 && min ==0)
			StartCoroutine(TimerAlert());	
		if(health<4)
			StartCoroutine(HPAlert());	
		if(sec==00 && min ==0)
			SetDied("TIME OUT!");
			
	}

	//END
	public void end(){
		StartCoroutine(MissionComplete());
		points += ((min * 60) + sec)*5;				//multiplier remaining time
		points += lives * 100;						//multiplier remaining lives
		points += health * 10;						//multiplier remaining health
		points += points*SaveGame.GetDifficult();	//multiplier difficulty
		PlayerPrefs.SetInt("TempPoints", Status.instance.GetPoints());
	}

	//WHYDIED
	public void SetDied(string why){
		whydied_text.text=why;
	}
	public string died(){
		return why_died;
	}

	//animation time text
	IEnumerator TimerAlert(){
		while(sec > 0){
			sec_text.color = Color.yellow;
			min_text.color = Color.yellow;
			dots.color = Color.yellow;
			yield return new WaitForSeconds(0.8f);
			sec_text.color = Color.white;
			min_text.color = Color.white;
			dots.color = Color.white;
			yield return new WaitForSeconds(0.8f);
		}
	}
	//animation hp text 
	IEnumerator HPAlert(){
		while(health < 4){
			health_text.color = Color.red;
			yield return new WaitForSeconds(0.8f);
			health_text.color = Color.white;
			yield return new WaitForSeconds(0.8f);
		}
	}

	IEnumerator PausePostDeath(){
		yield return new WaitForSeconds(1.2f);
			PlayerController.instance.postDie();
	}

	//print mission complete in metal slug style
	IEnumerator MissionComplete(){
		while(PlayerController.instance.end==true){
			if(SaveGame.GetParticles()==true){
				particleComplete.SetActive(true);
			}
			mission_complete="M";
			mission_complete_text.text=mission_complete.ToString();
			yield return new WaitForSeconds(timeChar);
			mission_complete="MI";
			mission_complete_text.text=mission_complete.ToString();
			yield return new WaitForSeconds(timeChar);
			mission_complete="MIS";
			mission_complete_text.text=mission_complete.ToString();
			yield return new WaitForSeconds(timeChar);
			mission_complete="MISS";
			mission_complete_text.text=mission_complete.ToString();
			yield return new WaitForSeconds(timeChar);
			mission_complete="MISSI";
			mission_complete_text.text=mission_complete.ToString();
			yield return new WaitForSeconds(timeChar);
			mission_complete="MISSIO";
			mission_complete_text.text=mission_complete.ToString();
			yield return new WaitForSeconds(timeChar);
			mission_complete="MISSION";
			mission_complete_text.text=mission_complete.ToString();
			yield return new WaitForSeconds(timeChar);
			mission_complete="MISSION ";
			mission_complete_text.text=mission_complete.ToString();
			yield return new WaitForSeconds(timeChar);
			mission_complete="MISSION C";
			mission_complete_text.text=mission_complete.ToString();
			yield return new WaitForSeconds(timeChar);
			mission_complete="MISSION CO";
			mission_complete_text.text=mission_complete.ToString();
			yield return new WaitForSeconds(timeChar);
			mission_complete="MISSION COM";
			mission_complete_text.text=mission_complete.ToString();
			yield return new WaitForSeconds(timeChar);
			mission_complete="MISSION COMP";
			mission_complete_text.text=mission_complete.ToString();
			yield return new WaitForSeconds(timeChar);
			mission_complete="MISSION COMPL";
			mission_complete_text.text=mission_complete.ToString();
			yield return new WaitForSeconds(timeChar);
			mission_complete="MISSION COMPLE";
			mission_complete_text.text=mission_complete.ToString();
			yield return new WaitForSeconds(timeChar);
			mission_complete="MISSION COMPLET";
			mission_complete_text.text=mission_complete.ToString();
			yield return new WaitForSeconds(timeChar);
			mission_complete="MISSION COMPLETE";
			mission_complete_text.text=mission_complete.ToString();
			yield return new WaitForSeconds(timeChar);
			SceneManager.LoadScene ("Ending");
			yield return new WaitForSeconds(timeChar);
		}	
	}
}

