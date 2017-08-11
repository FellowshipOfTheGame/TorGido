using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUP : MonoBehaviour {

	public float DurationTime;
	public float BlinkTime;
	public float BlinkRefresh;
	public float NextBlink = 0;
	public float Counter = 0;
	public SpriteRenderer spriteRend;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Initialization() {
		DurationTime = 5;
		BlinkTime = 1;
		BlinkRefresh = 0.2f;
		spriteRend = gameObject.GetComponent<SpriteRenderer> ();
		Destroy (gameObject, DurationTime);
	}

	public void Refresh() {
		Counter += Time.deltaTime;
		if ((Counter >= DurationTime - BlinkTime) && (Time.time >= NextBlink)) {
			NextBlink = Time.time + BlinkRefresh;
			spriteRend.enabled = !spriteRend.enabled;
		}
	}
}
