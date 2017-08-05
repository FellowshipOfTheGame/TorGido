using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

	private Rigidbody2D Rigid;
	private bool kAttack = false; //não sei onde deixar essa variavel
	private float next_attack = 0.0f;

	private StatsManager sm;

	// Use this for initialization
	void Start () {
		Rigid = gameObject.GetComponent<Rigidbody2D>();

		gameObject.GetComponent<HPManager> ().HP = 3; //setando 3 de hp para o inimigo

		gameObject.GetComponent<MovementManager> ().Target = GameObject.FindGameObjectWithTag ("Player"); 

		sm = gameObject.GetComponent<StatsManager> ();

		sm.speed = 5f;
		sm.range = 1f;
		sm.field = 5f;
		sm.damage = 1f;
		sm.attack_speed = 1f;
		sm.defense = 0;
	}
	
	// Update is called once per frame
	void Update () {
		move();

		if (Time.time > next_attack) {
			attack_gido ();
		}
	}

	public bool attack{
		get { return kAttack; }
		set { kAttack = value; }
	}

	void move() {
		gameObject.GetComponent<MovementManager> ().move();

	}

	void attack_gido(){
		if (kAttack) {
			//GOTarget.gameObject.GetComponent<GidoController>().CalculateDamage (sm.damage);
			gameObject.GetComponent<MovementManager> ().Target.gameObject.GetComponent<GidoController>().CalculateDamage (sm.damage, Rigid.position);

			next_attack = Time.time + sm.attack_speed;


		}
	}

	public void CalculateDamage(float damage, Vector3 attackDir){
		gameObject.GetComponent<AttackManager> ().CalculateDamage (damage);

		Vector2 direction = new Vector2 (Rigid.position.x - attackDir.x, Rigid.position.y - attackDir.y);

		gameObject.GetComponent<MovementManager> ().push (direction.normalized);

	}
}
