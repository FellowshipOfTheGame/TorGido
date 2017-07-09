   using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GidoController : MonoBehaviour {

	private Rigidbody2D Rigid;
	private Animator anim;
	private SpriteRenderer spriteRend;
	private bool facingRight = true;

	private StatsManager sm;

	// Use this for initialization
	void Start () {
		Rigid = gameObject.GetComponent<Rigidbody2D>();
		anim = gameObject.GetComponent<Animator> ();
		spriteRend = gameObject.GetComponent<SpriteRenderer> ();

		gameObject.GetComponent<HPManager> ().HP = 10; //setando 10 de hp para o gido

		sm = gameObject.GetComponent<StatsManager> ();
		sm.defense = 0f;
		sm.speed = 6f;
	}
	
	// Update is called once per frame
	void Update () {
		Move ();
	}

	void Move() {
		float h = Input.GetAxis ("Horizontal");
		float v = Input.GetAxis ("Vertical");

		if (h != 0.0f || v != 0.0f) {
			if (h > 0.0f && !facingRight) {
				facingRight = true;
				//transform.localScale = new Vector3 (transform.localScale.x * (-1), transform.localScale.y, transform.localScale.z);
				spriteRend.flipX = false;
			} else if (h < 0.0f && facingRight) {
				facingRight = false;
				//transform.localScale = new Vector3 (transform.localScale.x * (-1), transform.localScale.y, transform.localScale.z);
				spriteRend.flipX = true;
			}
			anim.SetBool ("isWalking", true);
		} else 
			anim.SetBool ("isWalking", false);

		Vector2 movement= new Vector2 (h, v);

		Rigid.velocity = movement.normalized * sm.speed;
	}

	public void CalculateDamage(float damage){
		gameObject.GetComponent<AttackManager> ().CalculateDamage (damage);

		anim.SetTrigger ("Damage");
	}
}
