using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SaveGame {
	
//MUSIC VOLUME
	public static void SaveMusicVolume(float volume){
		PlayerPrefs.SetFloat("MUSIC",volume);
		PlayerPrefs.Save();
	}

	public static float GetMusic(){
		return PlayerPrefs.GetFloat("MUSIC");
	}

	//SOUND VOLUME
	public static void SaveSoundVolume(float volume){
		PlayerPrefs.SetFloat("SOUND",volume);
		PlayerPrefs.Save();
	}

	public static float GetSound(){
		return PlayerPrefs.GetFloat("SOUND");
	}
	//RESOLUTION
	public static void SaveResolution(int resolution){
		PlayerPrefs.SetInt ("RESOLUTION", resolution);
		PlayerPrefs.Save();
	}
	public static int GetResolution(){
		return PlayerPrefs.GetInt("RESOLUTION");
	}
	//FULLSCREEN
	public static void SaveFullScreen(bool fullscreen){
		BooleanConverter.SetBool("FULLSCREEN",fullscreen);
		PlayerPrefs.Save ();
	}

	public static bool GetFullScreen(){
		return BooleanConverter.GetBool("FULLSCREEN",false);
	}

	//PARTICLES
	public static void SaveParticles(bool particles){
		BooleanConverter.SetBool("PARTICLES",particles);
		PlayerPrefs.Save ();
	}

	public static bool GetParticles(){
		return BooleanConverter.GetBool("PARTICLES",false);
	}

	//RESET SETTING
	public static void resetOptions(){
		PlayerPrefs.SetFloat("MUSIC",0);
		PlayerPrefs.SetFloat("SOUND",0);
		PlayerPrefs.SetInt("RESOLUTION",3);
		PlayerPrefs.SetInt("FULLSCREEN",1);
		PlayerPrefs.SetInt("PARTICLES",1);
		Debug.Log("RESETTED - MUSIC :"+GetMusic()+" SFX :"+GetSound()+"RESOLUTION INDEX :"+GetResolution()+"PARTICLES :"+GetParticles());
		PlayerPrefs.Save();
	}
	
	//FLUSH RANK
	public static void FlushRank(){
		for(int j = 0; j < 5; j++){
				SaveRankPoints(j, 0);
				SaveRankNames(j, "---");
			}
		PlayerPrefs.Save();
	}

	//RANK
	public static void SaveRankPoints(int i, int points){
		PlayerPrefs.SetInt("RankEntryPoints" + i, points);		//save score
		PlayerPrefs.Save ();
	}

	public static int GetRankPoints(int i){
		if (PlayerPrefs.HasKey ("RankEntryPoints" + i))			//get	score
			return PlayerPrefs.GetInt ("RankEntryPoints" + i);
		else
			return 0;
	}
	public static void SaveRankNames(int i, string RankNames){		//save name
		PlayerPrefs.SetString("RankEntryNames" + i, RankNames);
		PlayerPrefs.Save ();
	}

	public static string GetRankNames(int i){			//get name
		if (PlayerPrefs.HasKey ("RankEntryNames" + i))
			return PlayerPrefs.GetString ("RankEntryNames" + i);
		else
			return "0";
	}
//POSITION
	public static void SaveX(float x){
		PlayerPrefs.SetFloat ("PlayerX", x);
		PlayerPrefs.Save ();
	}

	public static float GetX(){
		if (PlayerPrefs.HasKey ("PlayerX"))
			return PlayerPrefs.GetFloat ("PlayerX");
		else
			return PlayerController.instance.transform.position.x;
	}

	public static void SaveY(float y){
		PlayerPrefs.SetFloat ("PlayerY", y);
		PlayerPrefs.Save ();
	}

	public static float GetY(){
		if (PlayerPrefs.HasKey ("PlayerY"))
			return PlayerPrefs.GetFloat ("PlayerY");
		else
			return PlayerController.instance.transform.position.y;
	}

	public static void SaveZ(float z){
		PlayerPrefs.SetFloat ("PlayerZ", z);
		PlayerPrefs.Save ();
	}

	public static float GetZ(){
		if (PlayerPrefs.HasKey ("PlayerZ"))
			return PlayerPrefs.GetFloat ("PlayerZ");
		else
			return PlayerController.instance.transform.position.z;
	}
	
	//HP
	public static void SaveHealth(int health){
		PlayerPrefs.SetInt ("HEALTH", health);
		PlayerPrefs.Save ();
	}
	public static int GetHealth(){
		if (PlayerPrefs.HasKey ("HEALTH"))
			return PlayerPrefs.GetInt ("HEALTH");
		else
			return PlayerController.instance.health;
	}
	//PT
	public static void SavePoints(int points){
		PlayerPrefs.SetInt ("POINTS", points);
		PlayerPrefs.Save ();
	}

	public static int GetPoints(){
		if (PlayerPrefs.HasKey ("POINTS"))
			return PlayerPrefs.GetInt ("POINTS");
		else
			return 0;
	}

	//LIVES
	public static void SaveLives(int lives){
		PlayerPrefs.SetInt ("LIVES", lives);
		PlayerPrefs.Save ();
	}

	public static int GetLives(){
	if (PlayerPrefs.HasKey ("LIVES"))
		return PlayerPrefs.GetInt ("LIVES");
	else
		return 0;
	}
	
	//CHECKPOINT
	public static void ActiveCheckpoints(){
		PlayerPrefs.SetInt ("CHECKPOINT", 1);
		PlayerPrefs.Save ();
	}

	public static void DeactiveCheckpoints(){
		PlayerPrefs.SetInt ("CHECKPOINT", 0);
		PlayerPrefs.Save ();
	}

	public static int GetCheckpoints(){
		return PlayerPrefs.GetInt ("CHECKPOINT");
	}

	//TIMER
	public static void SaveTimer(int minutes, int seconds){
		if(minutes !=0 && seconds !=0){
			PlayerPrefs.SetInt("TIME", ((minutes * 60) + seconds));
			PlayerPrefs.Save ();
		}
	}
	public static int GetTimer(){
		if (PlayerPrefs.HasKey ("TIME"))
			return PlayerPrefs.GetInt("TIME");
		else
			return Status.instance.startTime;
	}	

	//DIFFICULT
	public static void SaveDifficult(int difficult){
		PlayerPrefs.SetInt ("DIFFICULT", difficult);
		PlayerPrefs.Save ();
	}

	public static int GetDifficult(){
		if (PlayerPrefs.HasKey ("DIFFICULT"))
			return PlayerPrefs.GetInt ("DIFFICULT");
		else
			return 1;
	}
}
