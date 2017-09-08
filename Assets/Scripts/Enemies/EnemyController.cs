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

/*	public GameObject Special;
	private Vector3 EnemyPosition;
	private Timer t;
	private bool attacking = false;
	private bool normal_atk = false;
	private float anim_time;
*/
//	private Dictionary<EnemyType, StatsManager> EnemyList = new List<int> ();

	// Use this for initialization
	void Start () {
		Move = gameObject.GetComponent<MovementManager> ();
		Rigid = gameObject.GetComponent<Rigidbody2D>();
//		t = gameObject.GetComponent<Timer> ();

//		anim_time = 25.0f / 60.0f;

		gameObject.GetComponent<MovementManager> ().Target = GameObject.FindGameObjectWithTag ("Player"); 

		if (sm == null) {
			sm = gameObject.GetComponent<StatsManager> ();
		}
	}

	// Update is called once per frame
	void Update () {
		transform.position = new Vector3 (transform.position.x, transform.position.y, transform.position.y);

		move();

/*		if (Time.time > next_attack && gameObject.tag == "Enemy") {
			if (!attacking)
				attack_gido ();
			else if (normal_atk && t.Finished)
				NormalAttack ();
		}
*/		gameObject.GetComponent<Animator> ().SetBool ("IsWalking", Move.canMove);
	}

	public bool attack{
		get { return kAttack; }
		set { kAttack = value; }
	}

	void move() {
		gameObject.GetComponent<MovementManager> ().move();

	}

/*	void attack_gido(){
		if (kAttack) {
			gameObject.GetComponent<Animator> ().SetTrigger ("Attack");
			attacking = true;
			normal_atk = true;
			t.Begin (anim_time);
		}
	}
*/
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

/*	private void NormalAttack() {
		EnemyPosition = gameObject.transform.position;
		Instantiate (Special, EnemyPosition, Quaternion.identity);
		gameObject.GetComponent<MovementManager> ().Target.gameObject.GetComponent<GidoController> ().CalculateDamage (sm.damage, Rigid.position);
		next_attack = Time.time + (float)(1f / (sm.attack_speed));
		attacking = false;
		normal_atk = false;
	}*/
}