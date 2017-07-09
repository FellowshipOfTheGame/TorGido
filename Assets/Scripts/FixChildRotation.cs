using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixChildRotation : MonoBehaviour {
	Quaternion rotation;
	void Awake(){
		rotation = transform.rotation;
	}
	void LateUpdate(){
		transform.rotation = rotation;
	}
}
