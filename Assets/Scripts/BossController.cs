using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : EnemyController {
	
	public GameObject[] PowerUP;
	private StatsManager Status;
	private Vector3 EnemyPosition;

	// Use this for initialization
	void Start () {
		Status = gameObject.GetComponent<StatsManager> ();
		int aleatorio = 1;//Random.Range (0, PowerUP.Length);
		GameObject PU = PowerUP [aleatorio];
		switch(aleatorio) {
		case 0:
			Status.attack_speed += 5 * gameObject.GetComponent<Atk_SpeedUP> ().Increase;
			break;
		case 1:	
			Status.damage += 5 * gameObject.GetComponent<DamageUP> ().Increase;
			break;
		case 2:
			Status.defense += 5 * gameObject.GetComponent<DefenseUP> ().Increase;
			break;
		case 3:
			Status.speed += 5 * gameObject.GetComponent<SpeedUP> ().Increase;
			break;
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
//		EnemyPosition = gameObject.transform.position;
//		Instantiate (Heal, EnemyPosition, Quaternion.identity);
}
