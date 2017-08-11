using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenseUP : PowerUP {

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
			col.gameObject.GetComponent<StatsManager> ().defense += Increase;
			Destroy (gameObject);
		}
	}
}
