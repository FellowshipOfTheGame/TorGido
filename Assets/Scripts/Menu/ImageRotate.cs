using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImageRotate : MonoBehaviour {
	private float _time;

	// Use this for initialization
	void Start () {
		_time = 0;
	}
	
	// Update is called once per frame
	void Update () {

	}

	public void Rotateto0(){

		transform.eulerAngles = new Vector2 (0, 0);
	}
	public void Rotateto180(){
		transform.eulerAngles = new Vector2 (0, 180);

	}

}
