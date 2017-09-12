using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxeController : MonoBehaviour {

	public GameObject Boss;
	public float Speed;
	public float MoreDist; // Distancia que o machado percorrerá a mais da distancia original do Gido
	public Vector3 BossPos;
	public Vector3 GidoPos;

	private float AxeDamage;

	private Vector3 Direction;
	private Vector3 AxisZ;
	private Vector3 Perpendicular;
	private float Distancia;
	private Rigidbody2D Rigid;
	private float acceleration;
	private float DescrutingTime;
	private float timeCounter = 0;
	private Vector2 InitialVelocity;

	// Use this for initialization
	void Start () {
		Rigid = gameObject.GetComponent<Rigidbody2D> ();
		Boss = GameObject.FindGameObjectWithTag ("Boss");

		AxisZ = new Vector3 (0, 0, 1);
		AxeDamage = Boss.gameObject.GetComponent<StatsManager> ().damage * 1.2f;
		Direction = GidoPos - BossPos;
		Perpendicular = Vector3.Cross (Direction, AxisZ);
		Perpendicular = Vector3.Normalize (Perpendicular);

		InitialVelocity = Vector3.Normalize (Direction) * Speed;
		Rigid.velocity = InitialVelocity + (Vector2)(Perpendicular * Speed / 2.0f);

		Distancia = Vector3.Distance (BossPos, GidoPos) + MoreDist;
		acceleration = (-Mathf.Pow (Speed, 2)) / (2 * Distancia);	// Eq. de Torricelli :D
		DescrutingTime = (-Speed / acceleration);					// Função horária do MUV :D

//		Debug.Log ("Destructing time = " + DescrutingTime);
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		timeCounter += Time.deltaTime;
		Rigid.AddForce (Vector3.Normalize (Direction) * acceleration);
		if ((Vector3.Distance (BossPos, gameObject.transform.position) <= 0.5f) && (timeCounter >= DescrutingTime)) {
			if(Boss != null)
				Boss.gameObject.GetComponent<MovementManager> ().canMove = true;
			Destroy (gameObject);
		}
		if (timeCounter <= DescrutingTime)
			Rigid.AddForce (Perpendicular * acceleration);
		else
			Rigid.AddForce (-Perpendicular * acceleration);
	}

	void OnTriggerEnter2D(Collider2D col) {
		if (col.gameObject.tag == "Player")
			Boss.gameObject.GetComponent<BossController> ().Attack (AxeDamage, Rigid.position);
	}

}