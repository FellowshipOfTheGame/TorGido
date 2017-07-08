using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPManager : MonoBehaviour {
	private float kHP;


	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public float HP{
		get { return kHP; }
		set { kHP = value; }
	}

	public void decreaseHP (float value){
		kHP -= value;

		if(kHP <= 0)
			Debug.Log ("O hp chegou a 0");
	}

}
