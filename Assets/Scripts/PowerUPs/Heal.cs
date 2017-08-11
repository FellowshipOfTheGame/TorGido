using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heal : PowerUP {

	public int Increase;

	// Use this for initialization
	void Start () {
		Initialization ();
	}
	
	// Update is called once per frame
	void Update () {
		Refresh ();
	}

	void OnTriggerEnter2D(Collider2D col) {
		if (col.gameObject.tag == "Player") {
			col.gameObject.GetComponent<HPManager> ().CurrentHealth += Increase;
			if (col.gameObject.GetComponent<HPManager> ().CurrentHealth > col.gameObject.GetComponent<HPManager> ().MaxHealth)
				col.gameObject.GetComponent<HPManager> ().CurrentHealth = col.gameObject.GetComponent<HPManager> ().MaxHealth;
			col.gameObject.GetComponent<HPManager> ().bar.value = col.gameObject.GetComponent<HPManager> ().CalculateHealth ();
			Destroy (gameObject);
		}
	}
}
