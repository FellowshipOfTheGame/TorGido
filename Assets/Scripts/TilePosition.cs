using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TilePosition : MonoBehaviour {

	private float k = 100f; //constante para posicionamento das tiles do background (profundidade)

	// Use this for initialization
	void Start () {
		transform.position = new Vector3 (transform.position.x, transform.position.y, k + transform.position.y);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
