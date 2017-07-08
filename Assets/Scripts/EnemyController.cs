﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

	private Transform target;
	private GameObject GOTarget;
	private float e_speed = 5f;
	private float e_range = 1f;
	private float e_field = 5f; //campo de visao - circulo ao redor do inimigo

	private float damage = 1.0f;
	private bool attack = false;
	private float attack_speed = 1.0f;
	private float next_attack = 0.0f;

	private float defense = 0.0f;

	private bool facingRight = true;

	// Use this for initialization
	void Start () {
		target = GameObject.FindGameObjectWithTag("Player").transform;
		GOTarget = GameObject.FindGameObjectWithTag ("Player");

		gameObject.GetComponent<HPManager> ().HP = 10; //setando 10 de hp para o inimigo
	}
	
	// Update is called once per frame
	void Update () {
		move();

		if (Time.time > next_attack) {
			attack_gido ();
		}
	}

	/*public float range{
		get { return e_range; }
		set { e_range = value; }
	}*/

	void move() {

		var distance = Vector2.Distance(transform.position, target.position);

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

	void attack_gido(){
		if (attack) {
			GOTarget.gameObject.GetComponent<GidoController>().CalculateDamage (damage);

			next_attack = Time.time + attack_speed;
		}
	}

	public void CalculateDamage(float damage){
		float final = damage - defense;

		if (final < 0)
			final = 0;

		if (!gameObject.GetComponent<HPManager> ().decreaseHP (final)) {
			Destroy (gameObject);
		}
	}
}
