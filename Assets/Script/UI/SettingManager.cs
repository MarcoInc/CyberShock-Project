using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

//TO SET SETTINGS

public class SettingManager : MonoBehaviour{
	public AudioMixer SFXMixer, musicMixer;
    [SerializeField] Slider soundSlider, musicSlider;  
 
	public Dropdown resolutionDropdown;
    
    public Toggle fullScreenToggle,particlesToggle;
    int[] resolutionsW = new int[] { 1366, 1600, 1768, 1920, 3840 };
    int[] resolutionsH = new int[] { 768, 900, 992, 1080, 2160 };
   
	[SerializeField] Button resetButton;
	
    public void Update(){
        soundSlider.value=SaveGame.GetSound();
		musicSlider.value=SaveGame.GetMusic();   
        resolutionDropdown.value=SaveGame.GetResolution();
        fullScreenToggle.isOn=SaveGame.GetFullScreen();
        particlesToggle.isOn=SaveGame.GetParticles();
    }

    private void Start(){
      	Screen.fullScreen = fullScreenToggle.isOn;
        fullScreenToggle.isOn=SaveGame.GetFullScreen();
        //SaveGame.SaveParticles(particlesToggle.isOn);
        particlesToggle.isOn=SaveGame.GetParticles();
        dropdownResolution(); 
    }
    
    public void dropdownResolution(){
        resolutionDropdown.ClearOptions();		
        List<string> options = new List<string>();	
        int currentResolutionIndex = 0;
        for (int i = 0; i < resolutionsW.Length; i++){
            string option = resolutionsW[i] + " x " + resolutionsH[i];
            options.Add(option);
            if (resolutionsW[i] == Screen.currentResolution.width){
                currentResolutionIndex = i;
            }
        }
        resolutionDropdown.AddOptions(options);
        //resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();
    }

    //ALL SETTINGS
    public void SetResolution (int resIndex){
        Screen.SetResolution(resolutionsW[resIndex], resolutionsH[resIndex], Screen.fullScreen = SaveGame.GetFullScreen());
        Debug.Log("w : "+resolutionsW[resIndex]+" h : "+resolutionsH[resIndex]);
        Debug.Log("INDEX : "+resIndex);
        SaveGame.SaveResolution(resIndex);
    }
    /*
	public void SetResolution (int resolutionIndex){
        Resolution resolution = resolutions[resolutionIndex];
		Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }
    */

	public void SetVolumeSFX(float SFX){
		SFXMixer.SetFloat("SFX",SFX);
        Debug.Log("SFX Volume Setted:"+SFX);
	}
    public void SaveSoundVolume(){
		SaveGame.SaveSoundVolume(soundSlider.value);
	}

    public void SetVolumeMusic(float Music){
		musicMixer.SetFloat("Music",Music);
        Debug.Log("Music Volume Setted:"+Music);
	}
    public void SaveMusicVolume(){
		SaveGame.SaveMusicVolume(musicSlider.value);
	}

    public void SetFullscreen (bool isFullscreen){
        Screen.fullScreen = isFullscreen;
        Debug.Log("Fullscreen Setted:"+Screen.fullScreen);
        SaveFullScreen();
    }
    public void SaveFullScreen(){
		SaveGame.SaveFullScreen(fullScreenToggle.isOn);
          Debug.Log("Fullscreen Saved:"+Screen.fullScreen);
	}

    public void SetParticles (bool particles){
        SaveGame.SaveParticles(particles);
        Debug.Log("Particles Setted:"+Screen.fullScreen);
        SaveParticles();
    }
    public void SaveParticles(){
		SaveGame.SaveParticles(particlesToggle.isOn);
        Debug.Log("Particles Saved:"+Screen.fullScreen);
	}

    public void resetOptions(){
		SaveGame.resetOptions();
        Debug.Log("All Resetted");
	}

    public void FlushRank(){        
		SaveGame.FlushRank();
        Debug.Log("Rank Flushed");
	}
}
