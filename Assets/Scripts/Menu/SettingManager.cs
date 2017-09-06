using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI; 
using UnityEngine;

public class SettingManager : MonoBehaviour {

	public Slider MusicVolumeSlider;
	public Slider EffectsVolumeSlider;
	public Toggle fullscreenToggle;
	public GameSettings gameSettings;
	public AudioSource musicSource;

	void Start(){
		
		gameSettings.fullScreen = fullscreenToggle.isOn = Screen.fullScreen;
		musicSource.volume = gameSettings.VolumeMusic = MusicVolumeSlider.value = 1;
		PlayerPrefs.SetFloat ("Volume", MusicVolumeSlider.value);
	}

	// Use this for initialization
	void OnEnable() {
		gameSettings = new GameSettings ();
		fullscreenToggle.onValueChanged.AddListener (delegate { OnFullScreenToggle();});
		MusicVolumeSlider.onValueChanged.AddListener(delegate { OnMusicVolumeChanges();});
	
	

	}
	public void OnFullScreenToggle(){
		gameSettings.fullScreen = Screen.fullScreen = fullscreenToggle.isOn;
	}
	public void OnMusicVolumeChanges(){
		musicSource.volume = gameSettings.VolumeMusic = MusicVolumeSlider.value;
		PlayerPrefs.SetFloat ("Volume", MusicVolumeSlider.value);
	}
	public void OnEffectsVolumeChanges(){
	}


}
