﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class HPManager : MonoBehaviour {

	public float CurrentHealth;
	public float MaxHealth = 0.0f;
	public Slider bar;
	public Text health;

	//caso precise, alterar...
	public float HP{
		get { return CurrentHealth; }
		set { 

		}
	}


	void Start () {
		bar.value = CalculateHealth ();

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public bool DealDamage(float damage){
	
		CurrentHealth -= damage;
		bar.value = CalculateHealth ();

		if (gameObject.tag == "Enemy") {
			gameObject.GetComponent<Animator> ().SetTrigger ("Damage");
		}

		if (CurrentHealth <= 0) {
			return false;
		}

		return true;

	}
	public float CalculateHealth(){
	
		float r = (CurrentHealth / MaxHealth)*10;
		if (health != null)		health.text = r.ToString ();
		return r/10;
	
	}


	public void IncreaseHP(float value) {
		value = value/2 + 1; 
		MaxHealth *= value;
		CurrentHealth *= value;
		bar.value = CalculateHealth ();

	}

}
