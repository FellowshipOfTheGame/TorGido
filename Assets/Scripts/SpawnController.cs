using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Controlador do spawn no modo arena

public class SpawnController : MonoBehaviour {

	private Vector3 PlayerPossition;
	private float spawn_speed = 1.0f;
	private float next_spawn = 0.0f;
	private int max = 5;
	private int current = 0;
	private bool isSpawning = true;

	//criar tempo de espera entre waves
	private int wave = 1;
	private int cycle = 5; //numeros de waves em um ciclo (normais + boss/semi-boss)
	private int numEnemy = 5 - 1; //numero de inimigos na primeira wave do ciclo - 1

	// Use this for initialization
	void Start () {
		max = wave % cycle + numEnemy;
	}
	
	// Update is called once per frame
	void Update () {
		Spawn ();
		VerifyWave ();
	}
		
	//Gera 'max' inimigos em lugares random da arena, garantindo uma distancia minima do Gido
	void Spawn(){
		PlayerPossition = GameObject.FindGameObjectWithTag ("Player").transform.position;

		//if (Time.time > next_spawn && current < max) {
		if (current < max) {
			//	next_spawn = Time.time + spawn_speed;
			//verificar se gera inimigo muito perto do gido....

			Vector3 newPosition = new Vector3 (Random.Range (-14.5f, 14.5f), Random.Range (-8.9f, 8.9f), 0);
			if (Vector2.Distance (newPosition, PlayerPossition) > 4.0f) { //verificação de spawn proximo do Gido

				Instantiate (Resources.Load ("Enemy1"), newPosition, Quaternion.identity);
				current++;
			}
		} else {
			isSpawning = false;
		}
	}


	//Sistema inicial de waves -> a proxima wave terá MAX+1 inimigos
	void VerifyWave(){
		if (!isSpawning) {
			GameObject[] enemies = GameObject.FindGameObjectsWithTag ("Enemy");

			if (enemies.Length == 0) {
				wave += 1;
				max = wave % cycle + numEnemy;
				current = 0;
				isSpawning = true;
			}
		}
	}
}