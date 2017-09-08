using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialEffects : MonoBehaviour {

	private SpriteRenderer sprite;
	private Color alpha;

	// Use this for initialization
	void Start () {
		sprite = gameObject.GetComponent<SpriteRenderer> ();
		alpha = sprite.color;
		}
	
	// Update is called once per frame
	void Update () {
		alpha.a -= 0.05f;
		sprite.color = alpha;
		if (alpha.a <= 0.0f)
			Destroy (gameObject);
	}
}
