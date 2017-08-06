using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : EnemyController {
	
	public GameObject[] PowerUP;
	private StatsManager Status;
	private Vector3 EnemyPosition;
	private int my_powerup;

	// Use this for initialization
	void Start () {
		Status = gameObject.GetComponent<StatsManager> ();
		my_powerup = Random.Range (0, PowerUP.Length);
		GameObject PU = PowerUP [my_powerup];
		switch(my_powerup) {
		case 0:
			Status.attack_speed += 5 * PowerUP [0].GetComponent<Atk_SpeedUP> ().Increase;
			break;
		case 1:	
			Status.damage += 5 * PowerUP [1].GetComponent<DamageUP> ().Increase;
			break;
		case 2:
			Status.defense += 5 * PowerUP [2].GetComponent<DefenseUP> ().Increase;
			break;
		case 3:
			Status.speed += 5 * PowerUP [3].GetComponent<SpeedUP> ().Increase;
			break;
		case 4:
			gameObject.GetComponent<HPManager> ().MaxHealth += 5 * PowerUP [4].GetComponent<Max_HpUP> ().Increase;
			gameObject.GetComponent<HPManager> ().CurrentHealth += 5 * PowerUP [4].GetComponent<Max_HpUP> ().Increase;
			break;
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void boss_death () {
		EnemyPosition = gameObject.transform.position;
		Instantiate (PowerUP [my_powerup], EnemyPosition, Quaternion.identity);
	}

}
