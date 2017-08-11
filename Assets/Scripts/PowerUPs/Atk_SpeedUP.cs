using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Atk_SpeedUP : PowerUP {

	public int Increase;
	private GameObject Tor;

	// Use this for initialization
	void Start () {
		Tor = GameObject.FindGameObjectWithTag ("Tor");
		Initialization ();
	}
	
	// Update is called once per frame
	void Update () {
		Refresh ();
	}
	void OnTriggerEnter2D(Collider2D col) {
		if (col.gameObject.tag == "Player") {
			Tor.gameObject.GetComponent<StatsManager> ().attack_speed += Increase;
			Destroy (gameObject);
		}
	}
}
