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
	private float Invulnerability = 2;	// Evitar que o Gido apanhe sucessivas vezes, em um curto espaço de tempo, do mesmo machado
	private float counter2 = 0;

	// Use this for initialization
	void Start () {
		Rigid = gameObject.GetComponent<Rigidbody2D> ();
		Boss = GameObject.FindGameObjectWithTag ("Boss");

		AxisZ = new Vector3 (0, 0, 1);
		AxeDamage = Boss.gameObject.GetComponent<StatsManager> ().damage + 2;
		Direction = GidoPos - BossPos;
		Perpendicular = Vector3.Cross (Direction, AxisZ);
		Perpendicular = Vector3.Normalize (Perpendicular);

		InitialVelocity = Vector3.Normalize (Direction) * Speed;
		Rigid.velocity = InitialVelocity + (Vector2)(Perpendicular * Speed / 2.0f);

		Distancia = Vector3.Distance (BossPos, GidoPos) + MoreDist;
		acceleration = (-Mathf.Pow (Speed, 2)) / (2 * Distancia);	// Eq. de Torricelli :D
		DescrutingTime = (-Speed / acceleration);					// Função horária do MUV :D

//		Debug.Log ("Destructing time = " + DescrutingTime);
//		Destroy (gameObject, DescrutingTime);
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		timeCounter += Time.deltaTime;
		Rigid.AddForce (Vector3.Normalize (Direction) * acceleration);
		if ((Vector3.Distance (BossPos, gameObject.transform.position) <= 0.5f) && (timeCounter >= DescrutingTime)) {
			Boss.gameObject.GetComponent<MovementManager> ().canMove = true;
			Destroy (gameObject);
		}
		if (timeCounter <= DescrutingTime) //|| timeCounter >= (DescrutingTime * 7/6))*/(Vector3.Distance (BossPos, gameObject.transform.position) <= (Distancia / 2))
//			Rigid.velocity += (Vector2)Perpendicular * Time.fixedDeltaTime;
			Rigid.AddForce (Perpendicular*acceleration);
		else 
//			Rigid.velocity -= (Vector2)Perpendicular * Time.fixedDeltaTime;
		Rigid.AddForce (-Perpendicular*acceleration);


//		if (Vector2.SqrMagnitude (Rigid.velocity) > Vector2.SqrMagnitude (InitialVelocity)) {
//			Destroy (gameObject);
//		}
//		DestroyAxe ();
//		Rigid.velocity += (Vector2)Vector3.Normalize (Direction) * acceleration * Time.fixedDeltaTime;
	}

/*	public bool DestroyAxe() {
		if (Time.time >= DescrutingTime) {
			Destroy (gameObject);
			return true;
		}
		return false;
	}*/

	void OnTriggerEnter2D(Collider2D col) {
		if (col.gameObject.tag == "Player" && timeCounter >= counter2) {
			counter2 = timeCounter + Invulnerability;
			Boss.gameObject.GetComponent<BossController> ().Attack (AxeDamage, Rigid.position);
		}
	}

}