using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLimits : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public float MaxVerticalPosition() {
		return Camera.main.orthographicSize;
	}
	public float MinVerticalPosition() {
		return - Camera.main.orthographicSize;
	}
	public float MaxHorizontalPosition() {
		return Camera.main.orthographicSize * Screen.width / Screen.height;
	}
	public float MinHorizontalPosition() {
		return - Camera.main.orthographicSize * Screen.width / Screen.height;
	}

}
