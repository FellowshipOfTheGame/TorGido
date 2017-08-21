using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heal : PowerUP {

	public int Increase_apple;
	public int Increase_meat;
	public Sprite[] sprite;
	private GameObject gido;

	private SpriteRenderer render;
	private bool meat;			// True: heal mais forte (meat). False: heal mais fraco (apple)
	private float chance;

	// Use this for initialization
	void Start () {
		Initialization ();
		render = gameObject.GetComponent<SpriteRenderer> ();
		gido = GameObject.FindGameObjectWithTag ("Player");
		chance = 25 + 50 * (1 - gido.GetComponent<HPManager> ().CurrentHealth / gido.GetComponent<HPManager> ().MaxHealth);
		if (Random.Range (0, 100) <= chance) {
			meat = true;
			render.sprite = sprite [1];
		} else {
			meat = false;
			render.sprite = sprite [0];
		}
	}
	
	// Update is called once per frame
	void Update () {
		Refresh ();
	}

	void OnTriggerEnter2D(Collider2D col) {
		if (col.gameObject.tag == "Player") {
			if (meat)
				col.gameObject.GetComponent<HPManager> ().CurrentHealth += Increase_meat;
			else
				col.gameObject.GetComponent<HPManager> ().CurrentHealth += Increase_apple;
			if (col.gameObject.GetComponent<HPManager> ().CurrentHealth > col.gameObject.GetComponent<HPManager> ().MaxHealth)
				col.gameObject.GetComponent<HPManager> ().CurrentHealth = col.gameObject.GetComponent<HPManager> ().MaxHealth;
			col.gameObject.GetComponent<HPManager> ().bar.value = col.gameObject.GetComponent<HPManager> ().CalculateHealth ();
			Destroy (gameObject);
		}
	}
}
