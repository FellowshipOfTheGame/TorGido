using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour {

	private float spawn_speed = 1.0f;
	private float next_spawn = 0.0f;
	private int max = 3;
	private int current = 0;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		Spawn ();
		VerifyWave ();
	}

	void Spawn(){
		//if (Time.time > next_spawn && current < max) {
		if(current < max){
		//	next_spawn = Time.time + spawn_speed;
			//verificar se gera inimigo muito perto do gido....
			Instantiate (Resources.Load ("Enemy1"), new Vector3(Random.Range(-9f, 9f), Random.Range(-4.9f, 4.9f), 0), Quaternion.identity );
			current++;
		}
	}

	void VerifyWave(){
		GameObject[] enemies = GameObject.FindGameObjectsWithTag ("Enemy");

		if (enemies.Length == 0) {
			max += 1;
			current = 0;
		}
	}
}
