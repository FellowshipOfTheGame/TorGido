using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundaryBehaviour : CameraLimits {
	private float Offset;
	private float _ScaleOffset;

	// Use this for initialization
	void Start () {
		Offset = 0.5f;
		_ScaleOffset = (Offset + 0.5f) * 2;
		if (gameObject.name == "BoundaryU") {
			gameObject.transform.position = new Vector2 (0, MaxVerticalPosition () + Offset);
			gameObject.transform.localScale = new Vector2 (MaxHorizontalPosition () - MinHorizontalPosition () + _ScaleOffset, 1);
		}
		else if (gameObject.name == "BoundaryD") {
			gameObject.transform.position = new Vector2 (0, MinVerticalPosition () - Offset);
			gameObject.transform.localScale = new Vector2 (MaxHorizontalPosition () - MinHorizontalPosition () + _ScaleOffset, 1);
		}
		else if (gameObject.name == "BoundaryR") {
			gameObject.transform.position = new Vector2 (MaxHorizontalPosition () + Offset, 0);
			gameObject.transform.localScale = new Vector2 (1, MaxVerticalPosition () - MinVerticalPosition () + _ScaleOffset);
		}
		else if (gameObject.name == "BoundaryL") {
			gameObject.transform.position = new Vector2 (MinHorizontalPosition () - Offset, 0);
			gameObject.transform.localScale = new Vector2 (1, MaxVerticalPosition () - MinVerticalPosition () + _ScaleOffset);
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
