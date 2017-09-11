using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GidoController : MonoBehaviour {

	private Rigidbody2D Rigid;
	private Animator anim;
	private SpriteRenderer spriteRend;
	private bool facingRight = true;

	private StatsManager sm;

	private float nextDamage = 0.0f;
	private float imunityTime = 1f;

	private float blinkTime = 0.1f;
	private float nextBlink = 0f;

	public AudioClip[] audioClip;
	private AudioSource audio;
	// Use this for initialization
	void Start () {
		audio =  gameObject.GetComponent<AudioSource> ();
		Rigid = gameObject.GetComponent<Rigidbody2D>();
		anim = gameObject.GetComponent<Animator> ();
		spriteRend = gameObject.GetComponent<SpriteRenderer> ();

		//gameObject.GetComponent<HPManager> ().HP = 10; //setando 10 de hp para o gido

		sm = gameObject.GetComponent<StatsManager> ();
		//sm.defense = 0f;
		//sm.speed = 6f;
	}
	
	// Update is called once per frame
	void Update () {
		Move ();

		if (nextDamage >= Time.time) {

			if (nextBlink <= Time.time) {
				nextBlink += blinkTime;
				spriteRend.enabled = !spriteRend.enabled;
			}
		} else if(!spriteRend.enabled){
			spriteRend.enabled = true;
		}
	}

	void Move() {
		transform.position = new Vector3 (transform.position.x, transform.position.y, transform.position.y);

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
			if (!audio.isPlaying) {
				PlaySound (0);
			}

		} else 
			anim.SetBool ("isWalking", false);

		Vector2 movement = new Vector2 (h, v);

		Rigid.velocity = movement.normalized * sm.speed;
	}

	public void PlaySound(int clip){
		audio.clip = audioClip [clip];
		audio.Play ();
		if (clip == 0) {
			Invoke("StopSound", 0.21f);

		}
	}
	void StopSound(){
		audio.Stop();
	}


	public void CalculateDamage(float damage, Vector3 attackDir){
		if (nextDamage < Time.time) {
			if (!gameObject.GetComponent<AttackManager> ().CalculateDamage (damage)) {
				GameObject SpawnerArena = GameObject.FindGameObjectWithTag ("SpawnerArena");
				SpawnerArena.GetComponent<SpawnController> ().FinishArena ();

				//gameObject.SetActive (false);

			} else {

				Vector2 direction = new Vector2 (Rigid.position.x - attackDir.x, Rigid.position.y - attackDir.y);

				gameObject.GetComponent<MovementManager> ().push (direction.normalized);

				anim.SetTrigger ("Damage");

				nextDamage = Time.time + imunityTime;
				nextBlink = Time.time;
			}
		}
	}
}
