using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : EnemyController {
	
	public GameObject[] PowerUP;
	private StatsManager Status;
	private Rigidbody2D RigidB;
	private MovementManager Movement;
	private int my_powerup;

	public float CDspecialAttack2 = 10f;
	public float rangeSpecialAttack2 = 1000f;
	private float nextSpecialAttack2 = 10f;

	public GameObject AXE;
	public GameObject SpecialEffect;
	public GameObject Death;
	private Vector3 GidoPosition;
	private Vector3 BossPosition;

	private Timer t;
	private bool attacking = false;
	private bool normal_atk = false;
	private bool special_atk = false;
	private float anim_time;

	public AudioClip[] audioClip;
	private AudioSource audio;

	// Use this for initialization
	void Start () {
		Status = gameObject.GetComponent<StatsManager> ();
		RigidB = gameObject.GetComponent<Rigidbody2D> ();
		Movement = gameObject.GetComponent<MovementManager> ();
		t = gameObject.GetComponent<Timer> ();

		anim_time = 25.0f / 60.0f;
		nextSpecialAttack2 = CDspecialAttack2;
		my_powerup = Random.Range (0, PowerUP.Length);

		nextSpecialAttack2 = Time.time + CDspecialAttack2;

		switch(my_powerup) {
		case 0:
			Status.attack_speed += 3 * PowerUP [0].GetComponent<Atk_SpeedUP> ().Increase;
			break;
		case 1:	
			Status.damage += 3 * PowerUP [1].GetComponent<DamageUP> ().Increase;
			break;
		case 2:
			Status.defense += 3 * PowerUP [2].GetComponent<DefenseUP> ().Increase;
			break;
		case 3:
			Status.speed += 3 * PowerUP [3].GetComponent<SpeedUP> ().Increase;
			break;
		case 4:
			gameObject.GetComponent<HPManager> ().MaxHealth += 2 * PowerUP [4].GetComponent<Max_HpUP> ().Increase;
			gameObject.GetComponent<HPManager> ().CurrentHealth += 2 * PowerUP [4].GetComponent<Max_HpUP> ().Increase;
			break;
		}

		attack = true;

		CDspecialAttack2 = CDspecialAttack2 - (Mathf.Sqrt (Status.attack_speed));
		nextSpecialAttack2 = Time.time + CDspecialAttack2 / 2;
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.time > next_attack) {
			if (!attacking)
				tryAttack ();
			else if (normal_atk && t.Finished)
				NormalAttack ();
			else if (special_atk && t.Finished)
				SpecialAttack ();
		}
	}

	public void tryAttack(){
		float distance = Vector2.Distance (transform.position, gameObject.GetComponent<MovementManager>().Target.transform.position);

		if (Time.time > nextSpecialAttack2 && rangeSpecialAttack2 >= distance) { // SPECIAL ATTACK
			gameObject.GetComponent<Animator> ().SetTrigger ("Special");
			Movement.canMove = false;
			gameObject.GetComponent<Animator> ().SetBool ("IsWalking", Movement.canMove);
			attacking = true;
			special_atk = true;
			t.Begin (anim_time);
		}
		else if (Status.range >= distance) {									// NORMAL ATTACK
			gameObject.GetComponent<Animator> ().SetTrigger ("Attack");
			attacking = true;
			normal_atk = true;
			t.Begin (anim_time);
		}
	}

	public void Attack(float Damage,Vector3 Pos) {
		gameObject.GetComponent<MovementManager> ().Target.gameObject.GetComponent<GidoController> ().CalculateDamage (Damage, Pos);
	}

	public void boss_death () {
		BossPosition = gameObject.transform.position;
		Death.GetComponent <BossDeath> ().PU = PowerUP [my_powerup];
		Instantiate (Death, BossPosition, Quaternion.identity);
		Destroy (gameObject);
	}

	private void SpecialAttack () {
		nextSpecialAttack2 = Time.time + CDspecialAttack2;
		next_attack = Time.time + (float)(1f / (Status.attack_speed));
		// Testando arremessar o machado :D
		BossPosition = gameObject.transform.position;
		GidoPosition = gameObject.GetComponent<MovementManager> ().Target.gameObject.transform.position;
		BossPosition.y += 1f;		// Fazer o machado sair do centro da sprite do boss
		GidoPosition.y += 0.5f;
		AXE.GetComponent<AxeController> ().BossPos = BossPosition;
		AXE.GetComponent<AxeController> ().GidoPos = GidoPosition;
		Instantiate (AXE, BossPosition, Quaternion.identity);
		attacking = false;
		special_atk = false;
	}

	private void NormalAttack() {
		BossPosition = gameObject.transform.position;
		Instantiate (SpecialEffect, BossPosition, Quaternion.identity);
		Attack (Status.damage, RigidB.position);
		next_attack = Time.time + (float)(1f / (Status.attack_speed));
		attacking = false;
		normal_atk = false;
	}
}