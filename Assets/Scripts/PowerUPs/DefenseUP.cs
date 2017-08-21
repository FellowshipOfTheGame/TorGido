using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DefenseUP : PowerUP {
	private float defense = 0.0f;
	public Text defensetxt;
	public int Increase;

	// Use this for initialization
	void Start () {
		defensetxt.text = defense.ToString();
		Initialization ();
	}
	
	// Update is called once per frame
	void Update () {
		Refresh ();
	}

	void OnTriggerEnter2D(Collider2D col) {
		if (col.gameObject.tag == "Player") {
			UpDefense ();
			//GameObject.Find ("PlayerHealthBarCanvas").GetComponent<UIGidoStatusManager>().UpDefense();
			col.gameObject.GetComponent<StatsManager> ().defense += Increase;
			Destroy (gameObject);
		}
	}
	void UpDefense(){
		defense = defense + 1;
		defensetxt.text = defense.ToString();

	}
}
