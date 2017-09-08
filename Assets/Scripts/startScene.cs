using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startScene : MonoBehaviour {
	public GameObject audios;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		audios.GetComponent<AudioSource>().volume =	PlayerPrefs.GetFloat ("Volume");
	}
}
