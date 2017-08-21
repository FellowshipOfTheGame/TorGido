using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpeedUP : PowerUP {
	private float speed = 0.0f;
	public int Increase;
	public Text speedtxt;
	// Use this for initialization
	void Start () {
		speedtxt.text = speed.ToString();
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
	void UpSpeed(){
		speed = speed + 1;
		speedtxt.text = speed.ToString();

	}
}