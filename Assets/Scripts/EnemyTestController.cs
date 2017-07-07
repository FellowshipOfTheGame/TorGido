using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTestController : MonoBehaviour {
	HPManager hp;

	private Rigidbody2D rigid;
	private float enemyHP;
	// Use this for initialization
	void Start () {
		rigid = GetComponent<Rigidbody2D> ();
		hp = transform.GetComponent<HPManager>();
		if (hp) {
			enemyHP = hp.HP;
		}
	}
	
	// Update is called once per frame
	void Update () {
		ColorControl ();
	}
	void ColorControl(){
		if (enemyHP == 3f) {
			gameObject.GetComponent<SpriteRenderer> ().color = Color.magenta;
		} else if (enemyHP == 2f) {
			gameObject.GetComponent<SpriteRenderer> ().color = Color.yellow;
		} else if (enemyHP == 1f) {
			gameObject.GetComponent<SpriteRenderer> ().color = Color.red;
		}



		//gameObject.GetComponent<Renderer> ().material.SetColor
	
	}
	void OnTriggerEnter2D(Collider2D col){
		if(col.tag == "Player"){ 
			enemyHP = enemyHP - 1;
			if (enemyHP <= 0) {
				GameObject.Destroy(gameObject);
			}

		} 
	}
}
