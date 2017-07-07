using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorController : MonoBehaviour {

	private Vector3 UltimatePosition = new Vector3(0,0,0);
	//float X, Y;
	private GameObject wayPoint; 
	private float speed = 3.0f;
	private Vector3 wayPointPos;
	public float damage;
	void Start () {
		wayPoint = GameObject.Find("wayPoint");
	}
	void Update () {
		if (wayPointPos.x != wayPoint.transform.position.x || wayPointPos.y != wayPoint.transform.position.y || wayPointPos.z != wayPoint.transform.position.z ) {
			
			wayPointPos = new Vector3 (wayPoint.transform.position.x,wayPoint.transform.position.y, wayPoint.transform.position.z);
		}
		if (transform.position.x > wayPointPos.x) { //se o player estiver a esquerda do zombie, zombie vai virar de lado
			transform.eulerAngles = new Vector3 (0, 0, 0);

		} else { // se nao zombie nao vira
			
			transform.eulerAngles = new Vector3 (0, 180, 0);
		}
		transform.position = Vector3.MoveTowards (transform.position,wayPointPos, speed * Time.deltaTime);

	}


}
