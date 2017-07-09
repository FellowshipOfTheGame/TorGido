using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementManager : MonoBehaviour {

	private Transform tTarget;
	private GameObject goTarget;
	private Rigidbody2D Rigid;
	private SpriteRenderer spriteRend;
	private StatusManager sm;

	private bool facingRight = true;
	//private bool attack = false;
	private bool canMove = true;

	// Use this for initialization
	void Start () {
		Rigid = gameObject.GetComponent<Rigidbody2D>();
		spriteRend = gameObject.GetComponent<SpriteRenderer> ();
		sm = gameObject.GetComponent<StatusManager> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public GameObject Target{
		get { return goTarget; }
		set { 
			goTarget = value;
			tTarget = goTarget.transform;
		}
	}

	public void move(){
		var distance = Vector2.Distance (transform.position, tTarget.position);

		if (distance <= sm.field) {

			if (transform.position.x > tTarget.position.x) {
				if (!facingRight) {
					//transform.localScale = new Vector3 (transform.localScale.x * (-1), transform.localScale.y, transform.localScale.z);
					facingRight = true;
					spriteRend.flipX = false;
				}
			} else {
				if (facingRight) {
					//transform.localScale = new Vector3 (transform.localScale.x * (-1), transform.localScale.y, transform.localScale.z);
					facingRight = false;
					spriteRend.flipX = true;
				}
			}

			if (sm.range < distance && canMove) {
				if(gameObject.tag == "Enemy")
					gameObject.GetComponent<EnemyController>().attack = false;
				//transform.position = Vector2.MoveTowards(transform.position, target.position, e_speed * Time.deltaTime);
				Vector2 direction = new Vector2 (tTarget.position.x - transform.position.x, tTarget.position.y - transform.position.y);

				Rigid.velocity = direction.normalized * sm.speed;

			} else {
				Rigid.velocity = new Vector2 (0f, 0f);
				if(gameObject.tag == "Enemy")
					gameObject.GetComponent<EnemyController>().attack = true;
			}
		}
	}

	void OnCollisionEnter2D(Collision2D coll){
		if (gameObject.tag == "Enemy") {
			if (coll.gameObject.tag == "Player") {
				canMove = false;
				//Debug.Log ("entrei na colisao");
			} else {
				Rigid.velocity = new Vector2 (0f, 0f);
			}
		}
	}

	void OnCollisionExit2D(Collision2D coll){
		if (gameObject.tag == "Enemy") {
			if (coll.gameObject.tag == "Player") {
				canMove = true;
				//Debug.Log ("sai na colisao");
			} else {
				Rigid.velocity = new Vector2 (0f, 0f);
			}
		}
	}
}
