using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseChanger : MonoBehaviour {

	public Texture2D padraoTextura;
	public CursorMode curMode = CursorMode.Auto;
	public Vector2 hotSpot = Vector2.zero;

	// Use this for initialization
	void Start () {
		Cursor.SetCursor (padraoTextura, hotSpot, curMode);	
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
