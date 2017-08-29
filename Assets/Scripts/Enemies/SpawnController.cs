using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

//Controlador do spawn no modo arena

public class SpawnController : CameraLimits {

	private Vector3 PlayerPossition;
	private float spawn_speed = 1.0f;
	private float next_spawn = 0.0f;
	private int max = 5;
	private int current = 0;
	private bool isSpawning = true;
	private bool bossWave = false; 
	public Text wavenumber;

	//criar tempo de espera entre waves
	private int wave = 1;
	private int cycle = 5; //numeros de waves em um ciclo (normais + boss/semi-boss)
	private int numEnemy = 5 - 1; //numero de inimigos na primeira wave do ciclo - 1

	private float nextWave = 0f;
	private float waveInterval = 3f;

	public GameObject GOcanvas;
	public Text GOtext;
	private bool isGO = false;



	// Use this for initialization
	void Start () {
		max = wave % cycle + numEnemy;
		wavenumber.text = wave.ToString();
	}
	
	// Update is called once per frame
	void Update () {
		if (!isGO) {
			//Debug.Log ("valor de ArenaFinished: " + ArenaFinished);
			if (gameObject.GetComponent<CreateArena>().ArenaFinished && Time.time > nextWave) {
				Spawn ();
				VerifyWave ();
			}
		} else if(Input.GetKey("space")){
			Time.timeScale = 1;
			
			//voltar ao menu
			SceneManager.LoadScene("Menu");
		}
	}
		
	//Gera 'max' inimigos em lugares random da arena, garantindo uma distancia minima do Gido
	void Spawn(){

		//if (possiblePositions.Count == rows * rows) {
			PlayerPossition = GameObject.FindGameObjectWithTag ("Player").transform.position;

			//if (Time.time > next_spawn && current < max) {
			if (current < max) {
				//	next_spawn = Time.time + spawn_speed;
				//verificar se gera inimigo muito perto do gido....
				//float PosX = Random.Range (MinHorizontalPosition (), MaxHorizontalPosition ());
				//float PosY = Random.Range (MinVerticalPosition (), MaxVerticalPosition ());

				int idx = Random.Range (0, gameObject.GetComponent<CreateArena>().possiblePositions.Count);

				Debug.Log ("valores na lista: " + gameObject.GetComponent<CreateArena>().possiblePositions.Count);

				//Vector3 newPosition = new Vector3 (PosX, PosY, 0);
				Vector3 newPosition = gameObject.GetComponent<CreateArena>().possiblePositions [idx];

				if (Vector2.Distance (newPosition, PlayerPossition) > 4.0f) { //verificação de spawn proximo do Gido

					if (bossWave) {
						(Instantiate (Resources.Load ("Boss"), newPosition, Quaternion.identity) as GameObject).GetComponent<EnemyController> ().IncreaseStats ((wave - 1) / cycle);
					} else {
						(Instantiate (Resources.Load ("EnemyMelee"), newPosition, Quaternion.identity) as GameObject).GetComponent<EnemyController> ().IncreaseStats ((wave - 1) / cycle);
					}

					current++;
				}
			} else {
				isSpawning = false;
				bossWave = false;
			}
		//}
	}


	//Sistema inicial de waves -> a proxima wave terá MAX+1 inimigos
	void VerifyWave(){
		if (!isSpawning) {
			GameObject[] enemies = GameObject.FindGameObjectsWithTag ("Enemy");
			GameObject[] bossess = GameObject.FindGameObjectsWithTag ("Boss");

			if (enemies.Length + bossess.Length == 0) {
				nextWave = Time.time + waveInterval;

				wave += 1;
				wavenumber.text = wave.ToString();
				if (wave % cycle == 0) {
					bossWave = true;
					max = 1;
				} else {
					max = wave % cycle + numEnemy;
				}
				current = 0;
				isSpawning = true;

			}
		}
	}

	public void FinishArena(){
		Time.timeScale = 0;

		GOcanvas.SetActive(true);
		GOtext.text = "You reached the wave " + wave + "!\n... and failed!";

		isGO = true;
	}
}