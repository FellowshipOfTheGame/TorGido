using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedAttack : MonoBehaviour {
	
	public GameObject Arrow;

	protected float next_attack = 0.0f;

	private StatsManager sm;
	private MovementManager Move;
	private Timer t;
	private EnemyController control;

	private Vector3 SkeletonPosition;
	private Vector3 GidoPosition;
	private bool attacking = false;
	private bool normal_atk = false;
	private float anim_time;

	// Use this for initialization
	void Start () {
		Move = gameObject.GetComponent<MovementManager> ();

		sm = gameObject.GetComponent<StatsManager> ();
		control = gameObject.GetComponent<EnemyController> ();
		t = gameObject.GetComponent<Timer> ();

		sm.range = 10.0f;

		anim_time = 25.0f / 60.0f;
	}

	// Update is called once per frame
	void Update () {
		if (Time.time > next_attack) {
			if (!attacking)
				attack_gido ();
			else if (normal_atk && t.Finished)
				NormalAttack ();
		}

	}

	void attack_gido(){
		if (control.attack) {
			gameObject.GetComponent<Animator> ().SetTrigger ("Attack");
			attacking = true;
			normal_atk = true;
			t.Begin (anim_time);

			Move.canMove = false;
		}
	}

	private void NormalAttack() {
		SkeletonPosition = gameObject.transform.position;
		GidoPosition = gameObject.GetComponent<MovementManager> ().Target.gameObject.transform.position;
		SkeletonPosition.y += 1f;		// Fazer a flecha sair do centro da sprite
		GidoPosition.y += 0.25f;
		GidoController Gido = gameObject.GetComponent<MovementManager> ().Target.gameObject.GetComponent<GidoController> ();
		Arrow.GetComponent<ArrowController> ().GidoControl = Gido;
		Arrow.GetComponent<ArrowController> ().ArrowDamage = gameObject.GetComponent<StatsManager> ().damage;

		Arrow.GetComponent<ArrowController> ().SkelPos = SkeletonPosition;
		Arrow.GetComponent<ArrowController> ().GidoPos = GidoPosition;
		Instantiate (Arrow, SkeletonPosition, Quaternion.identity);
		next_attack = Time.time + (float)(1f / (sm.attack_speed));
		attacking = false;
		normal_atk = false;

		Move.canMove = true;
	}

	public void MoveAgain(){
		Move.canMove = true;
	}
}
