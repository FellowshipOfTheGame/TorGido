using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Movimentacao do Tor e do inimigo
public class MovementManager : MonoBehaviour {

	private Transform tTarget;
	private GameObject goTarget;
	private Rigidbody2D Rigid;
	private SpriteRenderer spriteRend;
	private StatsManager sm;

	private bool facingRight = true;
	//private bool attack = false;
	public bool canMove = true;

	private bool isOnPush = false;
	private float timeOnPush = 0.2f;
	private float nextMoveTime = 0f;

	public AudioClip[] audioClip;
	private AudioSource audio;

	// Use this for initialization
	void Start () {
		audio =  gameObject.GetComponent<AudioSource> ();
		Rigid = gameObject.GetComponent<Rigidbody2D>();
		spriteRend = gameObject.GetComponent<SpriteRenderer> ();
		sm = gameObject.GetComponent<StatsManager> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.time > nextMoveTime) {
			isOnPush = false;
		}
	}
	
	public GameObject Target{
		get { return goTarget; }
		set { 
			goTarget = value;
			tTarget = goTarget.transform;
		}
	}

	public void move(){
		float distance = Vector2.Distance (transform.position, tTarget.position);

		if (!isOnPush && distance <= sm.field) {
			gameObject.GetComponent<Animator> ().SetBool ("IsWalking", canMove);
			sm.SetFieldGlobal ();

			//verificacao da orientacao do sprite
			if (transform.position.x < tTarget.position.x) {
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

			//movimento
			if (sm.range < distance && canMove) {
				if(gameObject.tag == "Enemy" /*|| gameObject.tag == "Boss"*/)
					gameObject.GetComponent<EnemyController>().attack = false;
				//transform.position = Vector2.MoveTowards(transform.position, target.position, e_speed * Time.deltaTime);
				Vector2 direction = new Vector2 (tTarget.position.x - transform.position.x, tTarget.position.y - transform.position.y);

				if (gameObject.tag == "Tor")
					gameObject.GetComponent<Animator> ().SetBool ("IsWalking", true);

				Rigid.velocity = direction.normalized * sm.speed;
				if (audio != null) {
					if (!audio.isPlaying) {
						PlaySound (0);
					}
				}

			} else {
				Rigid.velocity = new Vector2 (0f, 0f);
				if(gameObject.tag == "Enemy" || gameObject.tag == "Boss")
					gameObject.GetComponent<EnemyController>().attack = true;
				if (gameObject.tag == "Tor")
					gameObject.GetComponent<Animator> ().SetBool ("IsWalking", false);
			}
		}
	}

	//inimmigo nao move quando colide com o player
	void OnCollisionEnter2D(Collision2D coll){
		if (gameObject.tag == "Enemy" || gameObject.tag == "Boss") {
			if (coll.gameObject.tag == "Player" ) {
				canMove = false;
				gameObject.GetComponent<Animator> ().SetBool ("IsWalking", canMove);
			} else {
				Rigid.velocity = new Vector2 (0f, 0f);
			}
		}
	}

	//inimmigo pode mover quando sai da colisao com o player
	void OnCollisionExit2D(Collision2D coll){
		if (gameObject.tag == "Enemy" || gameObject.tag == "Boss") {
			if (coll.gameObject.tag == "Player") {
				canMove = true;
			} else {
				Rigid.velocity = new Vector2 (0f, 0f);
			}
		}
	}

	public void push(Vector2 direction){
		isOnPush = true;
		nextMoveTime = Time.time + timeOnPush;

		Rigid.velocity = new Vector2(0f, 0f);

		//Rigid.AddForce (direction*1);
		if(gameObject.tag == "Player")
			Rigid.AddForce (direction*500 );
		else
			Rigid.AddForce (direction*40 );
	}
	public void PlaySound(int clip){
		if (audio != null) {
			audio.clip = audioClip [clip];
			audio.Play ();
		}

	}
}


