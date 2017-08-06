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
	}
	public void OnEffectsVolumeChanges(){
	}


}
