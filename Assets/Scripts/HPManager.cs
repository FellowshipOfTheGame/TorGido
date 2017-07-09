using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class HPManager : MonoBehaviour {

	//public float HP;
	private float CurrentHealth;
	private float MaxHealth = 0.0f;
	public Slider bar;

	//caso precise, alterar...
	public float HP{
		get { return CurrentHealth; }
		set { 
			if (MaxHealth == 0) {
				MaxHealth = value; 
				CurrentHealth = MaxHealth;
				bar.value = CalculateHealth ();
			}
		}
	}


	void Start () {
		//MaxHealth = HP;
		//CurrentHealth = MaxHealth;
		//bar.value = CalculateHealth ();

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public bool DealDamage(float damage){
	
		CurrentHealth -= damage;
		bar.value = CalculateHealth ();

		if (CurrentHealth <= 0) {
	//	-	Die ();
			return false;
		}

		return true;

	}
	float CalculateHealth(){
	
		return CurrentHealth / MaxHealth;
	
	}


//	public bool decreaseHP (float value){
//		kHP -= value;
//
//		if (kHP <= 0) {
//			Debug.Log ("O hp chegou a 0");
//			return false;
//		}
//
//		return true;
//	}

}
