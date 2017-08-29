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

	void Start () {

		gameObject.GetComponent<MovementManager> ().Target = GameObject.FindGameObjectWithTag ("Mouse"); 

		sm = gameObject.GetComponent<StatsManager> ();

		//sm.speed = 10f;
		//sm.damage = 1f;
		//sm.range = 0.2f; // para movimentação
	}

	void Update () {
		transform.position = new Vector3 (transform.position.x, transform.position.y, transform.position.y);

		rangex = 3f;
		rangey = 3f;
		Move ();

		if (Input.GetMouseButton (0)) {
			if (Time.time > next_attack) {
				NormalAttack ();
				next_attack = Time.time + (float)(1f/(sm.attack_speed));
			}
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
			offset = -1f;
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


