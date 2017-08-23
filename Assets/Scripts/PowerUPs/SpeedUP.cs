using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SpeedUP : PowerUP {
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
			UpSpeed ();
			//GameObject.Find ("PlayerHealthBarCanvas").GetComponent<UIGidoStatusManager>().UpSpeed();
			col.gameObject.GetComponent<StatsManager> ().speed += Increase;
			Destroy (gameObject);
		}
	}

}