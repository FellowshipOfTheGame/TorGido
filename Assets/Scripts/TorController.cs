using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorController : MonoBehaviour {
	[SerializeField] private LayerMask m_WhatIsEnemy;
	private Vector3 UltimatePosition = new Vector3(0,0,0);

	private float rangex = 3.0f;
	private float rangey = 3.0f;
	private float next_attack = 0.0f;

	private StatsManager sm;

	public float CDspecialAttack = 5f;
	public float rangeSpecialAttack = 5f;
	private float nextSpecialAttack = 0f;

	public Vector3 MousePos;
	public Vector3 TorPos;

	private Vector3 Direction;
	private Vector2 InitialVelocity;
	private Rigidbody2D Rigid;

	public float Speed;

	void Start () {

		gameObject.GetComponent<MovementManager> ().Target = GameObject.FindGameObjectWithTag ("Mouse"); 

		sm = gameObject.GetComponent<StatsManager> ();

		Rigid = gameObject.GetComponent<Rigidbody2D> ();

		//sm.speed = 10f;
		//sm.damage = 1f;
		//sm.range = 0.2f; // para movimentação
	}

	void Update () {
		transform.position = new Vector3 (transform.position.x, transform.position.y, transform.position.y);

		rangex = 3f;
		rangey = 3f;


		if (Input.GetMouseButton (1) && Time.time > nextSpecialAttack) {
			nextSpecialAttack = Time.time + CDspecialAttack;

			Howl();

			//proximo ataque normal, somente quando acabar animação do dash
			//next_attack = Time.time + (float)(1f / (sm.attack_speed));
		} else {
			Move ();

			if (Input.GetMouseButton (0)) {
				if (Time.time > next_attack) {
					Debug.Log ("ataque normal do tor");
					gameObject.GetComponent<Animator> ().SetTrigger ("Attack");
					NormalAttack ();
					next_attack = Time.time + (float)(1f / (sm.attack_speed));
				}
			}
		}

	}

	void Howl(){
		Debug.Log ("ataque especial do tor");

		//MousePos = gameObject.GetComponent<MovementManager> ().Target.gameObject.transform.position;
		//TorPos = gameObject.transform.position;

		//Direction = MousePos - TorPos;
		//InitialVelocity = Vector3.Normalize (Direction) * Speed;
		//Rigid.velocity = InitialVelocity;

		Vector2 Center = new Vector2 (transform.position.x, transform.position.y);

		Collider2D[] colliders = Physics2D.OverlapCircleAll (Center, 5f, m_WhatIsEnemy);

		for (int i = 0; i < colliders.Length; i++)
		{

			GameObject enemy = colliders [i].gameObject;

			//enemy.gameObject.GetComponent<EnemyTestController> ().GetComponent<HPManager> ().DealDamage (damage);
			enemy.gameObject.GetComponent<EnemyController> ().CalculateDamage(sm.damage * 2, gameObject.GetComponent<Rigidbody2D>().position);
			Debug.Log ("ataquei o " + i + " inimigo ");

		}
	}

	void Move(){
		gameObject.GetComponent<MovementManager> ().move();
	}

	void NormalAttack(){
		//verificação da area do ataque
		Vector3 wayPointPos = GameObject.FindGameObjectWithTag ("Mouse").transform.position;

		float side = 1f;
		float offset = 0.5f;

		if (transform.position.x > wayPointPos.x)
			offset = -0.5f;
		//if (transform.position.y > wayPointPos.y)
		//	offset = -1f;
		

		rangex = 1.5f;
		rangey = 1.5f;

		Vector2 LeftBottom = new Vector2 (transform.position.x - rangex + offset * side, transform.position.y - rangey);
		Vector2 RightUp = new Vector2 (transform.position.x + rangex + offset * side, transform.position.y + rangey);
		Collider2D[] colliders = Physics2D.OverlapAreaAll( LeftBottom, RightUp,m_WhatIsEnemy);
		for (int i = 0; i < colliders.Length; i++)
		{

			GameObject enemy = colliders [i].gameObject;

			//enemy.gameObject.GetComponent<EnemyTestController> ().GetComponent<HPManager> ().DealDamage (damage);
			enemy.gameObject.GetComponent<EnemyController> ().CalculateDamage(sm.damage, gameObject.GetComponent<Rigidbody2D>().position);
			Debug.Log ("ataquei o " + i + " inimigo ");

		}
	
	
	}
}


