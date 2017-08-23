using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

	public enum EnemyType{
		melee = 0,
		Boss = 100
	}

	private Rigidbody2D Rigid;
	private bool kAttack = false; //não sei onde deixar essa variavel
	protected float next_attack = 0.0f;

	private MovementManager Move;
	private StatsManager sm;


//	private Dictionary<EnemyType, StatsManager> EnemyList = new List<int> ();

	// Use this for initialization
	void Start () {
		Move = gameObject.GetComponent<MovementManager> ();
		Rigid = gameObject.GetComponent<Rigidbody2D>();

		//gameObject.GetComponent<HPManager> ().HP = 3; //setando 3 de hp para o inimigo

		gameObject.GetComponent<MovementManager> ().Target = GameObject.FindGameObjectWithTag ("Player"); 

		if (sm == null) {
			sm = gameObject.GetComponent<StatsManager> ();
		}

		/*sm.speed = 5f;
		sm.range = 1f;
		sm.field = 5f;
		sm.damage = 1f;
		sm.attack_speed = 1f;
		sm.defense = 0;*/
	}

	// Update is called once per frame
	void Update () {
		transform.position = new Vector3 (transform.position.x, transform.position.y, transform.position.y);

		move();

		if (Time.time > next_attack && gameObject.tag == "Enemy") {
			attack_gido ();
		}
		gameObject.GetComponent<Animator> ().SetBool ("IsWalking", Move.canMove);
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

			next_attack = Time.time + (float)(1f/(sm.attack_speed));
		}
	}

	public void CalculateDamage(float damage, Vector3 attackDir){
		gameObject.GetComponent<AttackManager> ().CalculateDamage (damage);

		Vector2 direction = new Vector2 (Rigid.position.x - attackDir.x, Rigid.position.y - attackDir.y);

		sm.SetFieldGlobal ();

		gameObject.GetComponent<MovementManager> ().push (direction.normalized);



	}

	//alterar
	public void IncreaseStats(int level){
		Debug.Log ("level do inimigo: " + level);
		gameObject.GetComponent<HPManager> ().IncreaseHP(level);

		if (sm == null) {
			sm = gameObject.GetComponent<StatsManager> ();
		}

		sm.speed += 0.5f * level;
		sm.range += 0f * level;
		sm.field += 1f * level;
		sm.damage += 0.2f * level;
		sm.attack_speed += 0.5f * level;
		sm.defense += 0.1f * level;
	}
}
