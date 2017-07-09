﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorController : MonoBehaviour {
	[SerializeField] private LayerMask m_WhatIsEnemy;
	private Vector3 UltimatePosition = new Vector3(0,0,0);
	private GameObject wayPoint; 
	private Rigidbody2D Rigid;

	private float speed = 5.0f;
	private Vector3 wayPointPos;
	public float damage = 1.0f;
	private float rangex = 3.0f;
	private float rangey = 3.0f;



	void Start () {
		wayPoint = GameObject.Find("wayPoint");
		Rigid = gameObject.GetComponent<Rigidbody2D>();
	}

	void Update () {
		rangex = 3f;
		Move ();

		if (Input.GetMouseButtonDown (0)) {
			
			NormalAttack();

		}

	}

	void Move(){
		
			if (wayPointPos.x != wayPoint.transform.position.x || wayPointPos.y != wayPoint.transform.position.y || wayPointPos.z != wayPoint.transform.position.z ) {

				wayPointPos = new Vector3 (wayPoint.transform.position.x,wayPoint.transform.position.y, wayPoint.transform.position.z);
			}
			
			if (transform.position.x > wayPointPos.x) {  // player esta a direita do Mouse 
				transform.eulerAngles = new Vector3 (0, 0, 0);
				rangex = -3f;
			} else {
				transform.eulerAngles = new Vector3 (0, 180, 0);

				
			}
			if (transform.position.y > wayPointPos.y) { // player esta numa posicao acima do Mouse
			
				rangey = -3.0f;
			} else { // player esta numa posicao a baixo do Mouse
				
				rangey = 3.0f;

			}
			
			var distance = Vector3.Distance(transform.position, wayPointPos);
			
			if (distance > 0.2f) {
				Vector2 direction = new Vector2 (wayPointPos.x - transform.position.x, wayPointPos.y - transform.position.y);
				Rigid.velocity = direction.normalized * speed;
				//transform.position = Vector3.MoveTowards (transform.position, wayPointPos, speed * Time.deltaTime);
			} else {
				Rigid.velocity = new Vector2 (0, 0);
			}
		}

	void NormalAttack(){
		Vector2 Boxcenter = new Vector2 (transform.position.x, transform.position.y);
		Vector2 Boxsize = new Vector2 (transform.position.x + rangex, transform.position.y + rangey);
		Collider2D[] colliders = Physics2D.OverlapAreaAll( Boxcenter, Boxsize,m_WhatIsEnemy);
		for (int i = 0; i < colliders.Length; i++)
		{

			GameObject enemy = colliders [i].gameObject;

			//enemy.gameObject.GetComponent<EnemyTestController> ().GetComponent<HPManager> ().DealDamage (damage);
			enemy.gameObject.GetComponent<EnemyController> ().CalculateDamage(damage);
			Debug.Log ("ataquei o " + i + " inimigo ");

		}
	
	
	}
}


