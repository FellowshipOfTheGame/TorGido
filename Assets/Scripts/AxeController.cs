using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxeController : MonoBehaviour {

	public float Speed;
	public float MoreDist; // Distancia que o machado percorrerá a mais da distancia original do Gido
	public Vector2 BossPos;
	public Vector2 GidoPos;
	private Vector2 Direction;

	private Rigidbody2D Rigid;
	private float acceleration;
	private float DescrutingTime;

	// Use this for initialization
	void Start () {
		Rigid = gameObject.GetComponent<Rigidbody2D> ();
		Direction = GidoPos - BossPos;
		Rigid.velocity = (Vector2)Vector3.Normalize (Direction) * Speed;
		acceleration = (-Mathf.Pow (Speed, 2)) / (2 * (Vector2.Distance (BossPos, GidoPos) + MoreDist));	// Eq. de Torricelli :D
		DescrutingTime = (-2 * Speed / acceleration);	// Função horária do MUV :D
		Debug.Log ("Destructing time = " + DescrutingTime);
		Destroy (gameObject, DescrutingTime);
	}
	
	// Update is called once per frame
	void Update () {
		Rigid.AddForce ((Vector2)Vector3.Normalize (Direction) * acceleration);
//		Rigid.velocity += (Vector2)Vector3.Normalize (Direction) * acceleration * Time.fixedDeltaTime;
	}
}
