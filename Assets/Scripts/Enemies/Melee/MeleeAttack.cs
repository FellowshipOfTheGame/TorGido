using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttack : MonoBehaviour {
	
	protected float next_attack = 0.0f;

	private Rigidbody2D Rigid;
	private StatsManager sm;
	private Timer t;
	private EnemyController control;

	public GameObject SpecialEffect;
	private Vector3 SkeletonPosition;
	private bool attacking = false;
	private bool normal_atk = false;
	private float anim_time;

	// Use this for initialization
	void Start () {
		Rigid = gameObject.GetComponent<Rigidbody2D>();
		sm = gameObject.GetComponent<StatsManager> ();
		control = gameObject.GetComponent<EnemyController> ();
		t = gameObject.GetComponent<Timer> ();

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
		}
	}

	private void NormalAttack() {
		SkeletonPosition = gameObject.transform.position;
		Instantiate (SpecialEffect, SkeletonPosition, Quaternion.identity);
		//GameObject spa = (Instantiate (SpecialEffect, SkeletonPosition, Quaternion.identity) as GameObject);
		//spa.transform.localScale = new Vector3(spa.transform.localScale.x * (transform.localScale.x % 1), spa.transform.localScale.y, spa.transform.localScale.z);
		gameObject.GetComponent<MovementManager> ().Target.gameObject.GetComponent<GidoController> ().CalculateDamage (sm.damage, Rigid.position);
		next_attack = Time.time + (float)(1f / (sm.attack_speed));
		attacking = false;
		normal_atk = false;
	}
}
