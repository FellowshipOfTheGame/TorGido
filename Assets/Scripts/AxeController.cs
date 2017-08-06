using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxeController : MonoBehaviour {

	public AnimationCurve X;
	public AnimationCurve Y;

	public float BossX;
	public float BossY;
	public float GidoX;
	public float GidoY;
	private float time_counter = 0;

	// Use this for initialization
	void Start () {
		gameObject.transform.position = new Vector2 (BossX, BossY);
	}
	
	// Update is called once per frame
	void Update () {
		time_counter += Time.deltaTime;
		float x = gameObject.transform.position.x + Mathf.Sin (time_counter);
		float y = gameObject.transform.position.y + Mathf.Sin (time_counter);
		gameObject.transform.position = new Vector2 (x, y);
	}
}
