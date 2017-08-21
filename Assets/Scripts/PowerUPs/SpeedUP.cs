using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SpeedUP : PowerUP {
	public GameObject upcounter;
	public int Increase;

	// Use this for initialization
	void Start () {
		upcounter = GameObject.Find ("PUCounter");
		Initialization ();
	}
	
	// Update is called once per frame
	void Update () {
		
		Refresh ();
	}

	void OnTriggerEnter2D(Collider2D col) {
		if (col.gameObject.tag == "Player") {
			upcounter.GetComponent<PUCounterManager>().UpSpeed ();
			//GameObject.Find ("PlayerHealthBarCanvas").GetComponent<UIGidoStatusManager>().UpSpeed();
			col.gameObject.GetComponent<StatsManager> ().speed += Increase;
			Destroy (gameObject);
		}
	}

}