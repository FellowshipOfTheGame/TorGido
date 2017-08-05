using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : EnemyController {
	
	public GameObject[] PowerUP;

	// Use this for initialization
	void Start () {
		GameObject PU = PowerUP [Random.Range (0, PowerUP.Length)];
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
