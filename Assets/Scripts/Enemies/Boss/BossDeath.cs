using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossDeath : MonoBehaviour {

	public GameObject PU;

	public void Die() {
		Instantiate (PU, gameObject.transform.position, Quaternion.identity);
		Destroy (gameObject);
	}
}
