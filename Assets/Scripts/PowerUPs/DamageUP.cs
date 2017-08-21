using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DamageUP : PowerUP {
	private float attack = 0.0f;
	public Text attacktxt;
	public int Increase;
	private GameObject Tor;

	// Use this for initialization
	void Start () {
		attacktxt.text = attack.ToString();
		Initialization ();
		Tor = GameObject.FindGameObjectWithTag ("Tor");
	}
	
	// Update is called once per frame
	void Update () {
		Refresh ();
	}
	void OnTriggerEnter2D(Collider2D col) {
		if (col.gameObject.tag == "Player") {
			UpAttack ();
			Tor.gameObject.GetComponent<StatsManager> ().damage += Increase;
			Destroy (gameObject);
		}
	}
	void UpAttack(){
		attack = attack + 1;
		attacktxt.text = attack.ToString();

	}
}
