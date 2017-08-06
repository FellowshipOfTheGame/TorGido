using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseMove : MonoBehaviour {
	private float distancia = 0f;
	private float MAX = 20f;
	private bool direita;
	public Transform image;

	// Use this for initialization
	void Start () {
		direita = true;
	}
	
	// Update is called once per frame
	void Update () {

		if (distancia < MAX && direita == true) {
			image.transform.position = new Vector3(image.transform.position.x + 1, image.transform.position.y,image.transform.position.z);
			distancia++;

		} else {
			direita = false;
		}
		if ((distancia > MAX * (-1)) && direita == false) {
			image.transform.position = new Vector3(image.transform.position.x - 1, image.transform.position.y,image.transform.position.z);

			distancia--;
		} else {
			direita = true;
		}
	}
}
