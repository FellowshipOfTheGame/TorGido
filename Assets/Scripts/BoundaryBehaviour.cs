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
			//gameObject.transform.position = new Vector2 (0, MaxVerticalPosition () + Offset);
			gameObject.transform.position = new Vector2 (-4.75f, 3.635f);
			gameObject.transform.localScale = new Vector2 (1, MaxHorizontalPosition () - MinHorizontalPosition () + _ScaleOffset);

			gameObject.transform.Rotate (0, 0, -63.43f, Space.World);
		}
		else if (gameObject.name == "BoundaryD") {
			//gameObject.transform.position = new Vector2 (0, MinVerticalPosition () - Offset);
			gameObject.transform.position = new Vector2 (6.23f, -4.65f);
			gameObject.transform.localScale = new Vector2 (1, MaxHorizontalPosition () - MinHorizontalPosition () + _ScaleOffset);

			gameObject.transform.Rotate (0, 0, -63.43f, Space.World);
		}
		else if (gameObject.name == "BoundaryR") {
			//gameObject.transform.position = new Vector2 (MaxHorizontalPosition () + Offset, 0);
			gameObject.transform.position = new Vector2 (6.15f, 2.92f);
			gameObject.transform.localScale = new Vector2 (1, MaxVerticalPosition () - MinVerticalPosition () + _ScaleOffset);

			gameObject.transform.Rotate (0, 0, 63.43f, Space.World);
		}
		else if (gameObject.name == "BoundaryL") {
			//gameObject.transform.position = new Vector2 (MinHorizontalPosition () - Offset, 0);
			gameObject.transform.position = new Vector2 (-6.6f, -4.45f);
			gameObject.transform.localScale = new Vector2 (1, MaxVerticalPosition () - MinVerticalPosition () + _ScaleOffset);

			gameObject.transform.Rotate (0, 0, 63.43f, Space.World);
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
