using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

	private Transform target;
	private GameObject GOTarget;
	private Rigidbody2D Rigid;
	private SpriteRenderer spriteRend;
	private float e_speed = 5f;
	private float e_range = 1f;
	private float e_field = 5f; //campo de visao - circulo ao redor do inimigo

	private float damage = 1.0f;
	private bool attack = false;
	private float attack_speed = 1.0f;
	private float next_attack = 0.0f;

	private float defense = 0.0f;

	private bool facingRight = true;
	private bool canMove = true;

	// Use this for initialization
	void Start () {
		target = GameObject.FindGameObjectWithTag("Player").transform;
		GOTarget = GameObject.FindGameObjectWithTag ("Player");

		Rigid = gameObject.GetComponent<Rigidbody2D>();
		spriteRend = gameObject.GetComponent<SpriteRenderer> ();

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

			if (e_range < distance && canMove) {
				attack = false;
				//transform.position = Vector2.MoveTowards(transform.position, target.position, e_speed * Time.deltaTime);
				Vector2 direction = new Vector2( target.position.x - transform.position.x, target.position.y - transform.position.y);

				Rigid.velocity = direction.normalized * e_speed;

			} else {
				Rigid.velocity = new Vector2 (0f, 0f);
				attack = true;
			}

		}
	}

	void OnCollisionEnter2D(Collision2D coll){
		if (coll.gameObject.tag == "Player") {
			canMove = false;
			//Debug.Log ("entrei na colisao");
		}
	}

	void OnCollisionExit2D(Collision2D coll){
		if (coll.gameObject.tag == "Player") {
			canMove = true;
			//Debug.Log ("sai na colisao");
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


		if (!gameObject.GetComponent<HPManager> ().DealDamage(final)) {
			Destroy (gameObject);
		}
		//if (!gameObject.GetComponent<HPManager> ().decreaseHP (final)) {
		//	Destroy (gameObject);
		//}
	}
}
