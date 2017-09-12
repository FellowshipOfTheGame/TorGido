using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
		float currentAspect = (float)Screen.width / (float)Screen.height;
		Camera.main.orthographicSize = 1920 / currentAspect / 125;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
