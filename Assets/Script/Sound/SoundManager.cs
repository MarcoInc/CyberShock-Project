using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SoundManager : MonoBehaviour {

	// singleton class 
	public static SoundManager instance;

	private AudioSource enemy,player,item;
	[SerializeField] private AudioClip teleport,T800_death,DressedT800_death, dressedT800_low_energy,t800_low_energy,
									   player_death,player_hit,pow_up_live, pow_up_checkpoint,pow_up_hp;
	void Awake () {
		instance = this;	
		enemy = gameObject.AddComponent<AudioSource> ();
		enemy.volume = (SaveGame.GetSound()+45)/45;
		player = gameObject.AddComponent<AudioSource> ();
		player.volume = (SaveGame.GetSound()+45)/45;
		item = gameObject.AddComponent<AudioSource> ();
		item.volume = (SaveGame.GetSound()+45)/45;
	}

	//all in-game SFX
	public void T800Death(){
		enemy.clip = T800_death;
		enemy.Play();
	}

	public void DressedT800Death(){
		enemy.clip = DressedT800_death;
		enemy.Play();
	}

	public void DressedT800LowEnergy(){
		enemy.clip = dressedT800_low_energy;
		enemy.loop = false;
		enemy.Play();
	}

	public void T800LowEnergy(){
		enemy.clip = t800_low_energy;
		enemy.loop = false;
		enemy.Play();
	}

	public void PW_UP_CHECKPOINT(){
		item.clip = pow_up_checkpoint;
		item.Play();
	}

	public void PW_UP_LIVE(){
		item.clip = pow_up_live;
		item.Play();
	}

	public void PW_UP_HP(){
		item.clip = pow_up_hp;
		item.Play();
	}

	public void Teleport(){
		item.clip = teleport;
		item.Play();
	}

	public void PlayerHit(){
		player.clip = player_hit;
		player.Play();
	}

	public void PlayerDeath(){
		player.clip = player_death;
		player.Play();
	}
}
