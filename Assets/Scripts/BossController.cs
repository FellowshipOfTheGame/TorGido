using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : EnemyController {
	
	public GameObject[] PowerUP;
	private StatsManager Status;
	private Rigidbody2D RigidB;
	private MovementManager Move;
	private int my_powerup;

	public float CDspecialAttack1 = 5f;
	public float rangeSpecialAttack1 = 5f;
	private float nextSpecialAttack1 = 0f;

	public float CDspecialAttack2 = 10f;
	public float rangeSpecialAttack2 = 1000f;
	private float nextSpecialAttack2 = 10f;

	public GameObject AXE;
	private Vector3 GidoPosition;
	private Vector3 BossPosition;

	// Use this for initialization
	void Start () {
		Status = gameObject.GetComponent<StatsManager> ();
		RigidB = gameObject.GetComponent<Rigidbody2D> ();
		Move = gameObject.GetComponent<MovementManager> ();

		nextSpecialAttack2 = CDspecialAttack2;
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

		attack = true;
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.time > next_attack) {
			tryAttack();
		}
		gameObject.GetComponent<Animator> ().SetBool ("IsWalking", Move.canMove);
	}

	public void tryAttack(){
		float distance = Vector2.Distance (transform.position, gameObject.GetComponent<MovementManager>().Target.transform.position);

		//Debug.Log ("distancia: " + distance +", range SA2: " +rangeSpecialAttack2 );

		if (Time.time > nextSpecialAttack2 && rangeSpecialAttack2 >= distance) {
			Debug.Log ("boss usou S. Attack 2");
			nextSpecialAttack2 = Time.time + CDspecialAttack2;
			next_attack = Time.time + (float)(1f/(Status.attack_speed));
			// Testando arremessar o machado :D
			Move.canMove = false;
			BossPosition = gameObject.transform.position;
			GidoPosition = gameObject.GetComponent<MovementManager> ().Target.gameObject.transform.position;
			BossPosition.y += 1f;		// Fazer o machado sair do centro da sprite do boss
			GidoPosition.y += 0.5f;
			AXE.GetComponent<AxeController> ().BossPos = BossPosition;
			AXE.GetComponent<AxeController> ().GidoPos = GidoPosition;
			Instantiate (AXE, BossPosition, Quaternion.identity);


		} else if (Time.time > nextSpecialAttack1 && rangeSpecialAttack1 >= distance) {
			Debug.Log ("boss usou S. Attack 1");
			nextSpecialAttack1 = Time.time + CDspecialAttack1;
			next_attack = Time.time + (float)(1f/(Status.attack_speed));

		} else if (Status.range >= distance) {
			Debug.Log ("boss usou attack normal");
			Attack (Status.damage, RigidB.position);
			next_attack = Time.time + (float)(1f/(Status.attack_speed));
		}
	}

	public void Attack(float Damage,Vector3 Pos) {
		gameObject.GetComponent<MovementManager> ().Target.gameObject.GetComponent<GidoController> ().CalculateDamage (Damage, Pos);
	}
	
	public void boss_death () {
		BossPosition = gameObject.transform.position;
		Instantiate (PowerUP [my_powerup], BossPosition, Quaternion.identity);
	}

}
