using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Atk_SpeedUP : MonoBehaviour {

	public int Increase;
	private GameObject Tor;

	// Use this for initialization
	void Start () {
		Tor = GameObject.FindGameObjectWithTag ("Tor");
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnTriggerEnter2D(Collider2D col) {
		if (col.gameObject.tag == "Player") {
			Tor.gameObject.GetComponent<StatsManager> ().attack_speed += Increase;
			Destroy (gameObject);
		}
	}
}
