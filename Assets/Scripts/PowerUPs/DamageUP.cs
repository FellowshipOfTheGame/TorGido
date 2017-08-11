using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageUP : PowerUP {

	public int Increase;
	private GameObject Tor;

	// Use this for initialization
	void Start () {
		Initialization ();
		Tor = GameObject.FindGameObjectWithTag ("Tor");
	}
	
	// Update is called once per frame
	void Update () {
		Refresh ();
	}
	void OnTriggerEnter2D(Collider2D col) {
		if (col.gameObject.tag == "Player") {
			Tor.gameObject.GetComponent<StatsManager> ().damage += Increase;
			Destroy (gameObject);
		}
	}
}
