using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowController : MonoBehaviour {

//	public GameObject Skeleton;
	public GidoController GidoControl;
	public float Speed;
	public Vector3 SkelPos;
	public Vector3 GidoPos;

	public float ArrowDamage;
	private Vector3 Direction;
	private Rigidbody2D Rigid;

	// Use this for initialization
	void Start () {
		Rigid = gameObject.GetComponent<Rigidbody2D> ();
		Direction = GidoPos - SkelPos;
		float angle = Mathf.Atan2 (Direction.y, Direction.x) * Mathf.Rad2Deg;

//		ArrowDamage = Skeleton.gameObject.GetComponent<StatsManager> ().damage;

		transform.rotation = Quaternion.Euler (0f, 0f, angle - 138f);
		Rigid.velocity = Vector3.Normalize (Direction) * Speed;
	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnTriggerEnter2D(Collider2D col) {
		if (col.gameObject.tag == "Player") {
//			Skeleton.GetComponent<BossController> ().Attack (ArrowDamage, Rigid.position);
			GidoControl.CalculateDamage (ArrowDamage, Rigid.position);
			Destroy (gameObject);
		}
	}
}
