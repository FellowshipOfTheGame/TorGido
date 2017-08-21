using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heal : PowerUP {

	public int Increase_apple;
	public int Increase_meat;
	public Sprite[] sprite;

	private int rand;
	private SpriteRenderer render;

	// Use this for initialization
	void Start () {
		Initialization ();
		render = gameObject.GetComponent<SpriteRenderer> ();
	}
	
	// Update is called once per frame
	void Update () {
		Refresh ();
	}

	void OnTriggerEnter2D(Collider2D col) {
		if (col.gameObject.tag == "Player") {
			//if (
				col.gameObject.GetComponent<HPManager> ().CurrentHealth += Increase_meat;
			if (col.gameObject.GetComponent<HPManager> ().CurrentHealth > col.gameObject.GetComponent<HPManager> ().MaxHealth)
				col.gameObject.GetComponent<HPManager> ().CurrentHealth = col.gameObject.GetComponent<HPManager> ().MaxHealth;
			col.gameObject.GetComponent<HPManager> ().bar.value = col.gameObject.GetComponent<HPManager> ().CalculateHealth ();
			Destroy (gameObject);
		}
	}
}
