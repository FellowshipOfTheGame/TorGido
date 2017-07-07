using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

	private Transform target;
	private float e_speed = 5f;
	private float e_range = 1f;
	private float e_field = 5f; //campo de visao - circulo ao redor do inimigo

	private bool attack = false;

	private bool facingRight = true;

	// Use this for initialization
	void Start () {
		target = GameObject.FindGameObjectWithTag("Player").transform;
	}
	
	// Update is called once per frame
	void Update () {
		move();
	}

	/*public float range{
		get { return e_range; }
		set { e_range = value; }
	}*/

	void move() {

		var distance = Vector2.Distance(transform.position, target.position);
			
		Debug.Log ("Distancia = " + distance + ", field: "+ e_field);

		if (distance <= e_field) {

			if (transform.position.x > target.position.x) {
				if (!facingRight) {
					transform.localScale = new Vector3 (transform.localScale.x * (-1), transform.localScale.y, transform.localScale.z);
					facingRight = true;
				}
			} else {
				if (facingRight) {
					transform.localScale = new Vector3 (transform.localScale.x * (-1), transform.localScale.y, transform.localScale.z);
					facingRight = false;
				}
			}

			if (e_range < distance) {
				attack = false;
				transform.position = Vector2.MoveTowards(transform.position, target.position, e_speed * Time.deltaTime);
			} else {
				attack = true;
			}

		}


	}
}
