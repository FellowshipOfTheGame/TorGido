using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class HPManager : MonoBehaviour {
	public float HP;
	private float CurrentHealth { set; get; }
	private float MaxHealth { set; get; }
	public Slider bar;


	void Start () {
		MaxHealth = HP;
		CurrentHealth = MaxHealth - 1;
		bar.value = CalculateHealth ();

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void DealDamage(float damage){
	
		CurrentHealth -= damage;
		bar.value = CalculateHealth ();
		if (CurrentHealth <= 0) {
			Die ();
		}

	}
	float CalculateHealth(){
	
		return CurrentHealth / MaxHealth;
	
	}


	void Die(){
		GameObject.Destroy (gameObject);
	}


}
