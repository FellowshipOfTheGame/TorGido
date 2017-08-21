using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateArena : MonoBehaviour {

	public GameObject[] tiles;

	private int rows = 18;
	//private int columns = 10;

	private float Xinit = 10.5f;
	private float Yinit = 5.25f;

	private float incX = 0.7f;
	private float incY = 0.35f;

	private float k = -1f;

	// Use this for initialization
	void Start () {

		Vector3 newPosition;

		GameObject newTile;

		float Xmax = (rows - 1) * incX; //(rows / 2) * incX;
		float Ymax = rows * incY; //(rows / 2) * incY;


		for (int x = 0; x < rows; x++) {
			for (float y = 0; y < rows; y++) {
				Xinit = -Xmax + x*incX + y*incX;
				Yinit = 0 + x*incY - y*incY + k;

				newPosition = new Vector3 (Xinit, Yinit, 0f);

				newTile = tiles [Random.Range (0, tiles.Length)];

				Instantiate (newTile, newPosition, Quaternion.identity);
			}
		}

	}


	
	// Update is called once per frame
	void Update () {
		
	}
}
