using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PUCounterManager : MonoBehaviour {
	private float attack = 0.0f;
	public Text attacktxt;

	private float defense = 0.0f;
	public Text defensetxt;

	private float speed = 0.0f;
	public Text speedtxt;

	private float wave = 0.0f;

	// Use this for initialization
	void Start () {
		attacktxt.text = attack.ToString();
		defensetxt.text = defense.ToString();
		speedtxt.text = speed.ToString();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void UpSpeed(){
		speed = speed + 1;
		speedtxt.text = speed.ToString();

	}

	public void UpAttack(){
		attack = attack + 1;
		attacktxt.text = attack.ToString();

	}

	public void UpDefense(){
		defense = defense + 1;
		defensetxt.text = defense.ToString();

	}

}
