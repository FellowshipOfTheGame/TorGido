using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PUSpawner : CameraLimits {

	public float Delay;
	public GameObject[] PowerUP;

	private Vector3 PlayerPosition;
	private float _time;

	// Use this for initialization
	void Start () {
		_time = 0f;
	}
	
	// Update is called once per frame
	void Update () {
		_time += Time.deltaTime;
		if (_time > Delay) {
			
			_time = 0f;
			PlayerPosition = GameObject.FindGameObjectWithTag ("Player").transform.position;

			GameObject PU = PowerUP [3];//Random.Range (0, PowerUP.Length)];

			float PosX = Random.Range (MinHorizontalPosition (), MaxHorizontalPosition ());
			float PosY = Random.Range (MinVerticalPosition (), MaxVerticalPosition ());
			Vector3 newPosition = new Vector3 (PosX, PosY, 0);

			while (Vector2.Distance (newPosition, PlayerPosition) < 4.0f) { //verificação de spawn proximo do Gido
				PosX = Random.Range (MinHorizontalPosition (), MaxHorizontalPosition ());
				PosY = Random.Range (MinVerticalPosition (), MaxVerticalPosition ());
				newPosition = new Vector3 (PosX, PosY, 0);
			}

			Instantiate (PU, newPosition, Quaternion.identity);
		}
	}

}
