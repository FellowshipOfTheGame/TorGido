using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TilePosition : MonoBehaviour {

	private float k = 100f; //constante para posicionamento das tiles do background (profundidade)

	// Use this for initialization
	void Start () {
		//if (gameObject.tag == "Wall") {
		//	transform.position = new Vector3 (transform.position.x, transform.position.y, k - transform.position.y);
		//} else {
		transform.position = new Vector3 (transform.position.x, transform.position.y, transform.position.z + k + transform.position.y);
		//}
		transform.localScale = new Vector3 (5, 5, 1);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
