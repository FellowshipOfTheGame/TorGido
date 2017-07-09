using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour {

	private Vector3 PlayerPossition;
	private float spawn_speed = 1.0f;
	private float next_spawn = 0.0f;
	private int max = 1;
	private int current = 0;
	private bool isSpawning = true;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		Spawn ();
		VerifyWave ();
	}

	void Spawn(){
		PlayerPossition = GameObject.FindGameObjectWithTag ("Player").transform.position;

		//if (Time.time > next_spawn && current < max) {
		if (current < max) {
			//	next_spawn = Time.time + spawn_speed;
			//verificar se gera inimigo muito perto do gido....

			Vector3 newPosition = new Vector3 (Random.Range (-14.5f, 14.5f), Random.Range (-8.9f, 8.9f), 0);
			if (Vector2.Distance (newPosition, PlayerPossition) > 4.0f) {

				Instantiate (Resources.Load ("Enemy1"), newPosition, Quaternion.identity);
				current++;
			}
		} else {
			isSpawning = false;
		}
	}

	void VerifyWave(){
		if (!isSpawning) {
			GameObject[] enemies = GameObject.FindGameObjectsWithTag ("Enemy");

			if (enemies.Length == 0) {
				max += 1;
				current = 0;
				isSpawning = true;
			}
		}
	}
}
