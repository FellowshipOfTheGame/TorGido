using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIGidoStatusManager : MonoBehaviour {

	private float speed = 0.0f;
	private float attack = 0.0f;
	private float defense = 0.0f;

	public Text speedtxt;
	public Text attacktxt;
	public Text defensetxt;


	// Use this for initialization
	void Start () {

		speedtxt.text = speed.ToString();
		attacktxt.text = attack.ToString();
		defensetxt.text = defense.ToString();

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
