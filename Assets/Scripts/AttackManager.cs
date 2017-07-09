using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackManager : MonoBehaviour {

	private StatusManager sm;

	// Use this for initialization
	void Start () {
		sm = gameObject.GetComponent<StatusManager> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void CalculateDamage(float damage){
		//formulado dano/defesa

		float final = damage - sm.defense;

		if (final < 0)
			final = 0;

		if (!gameObject.GetComponent<HPManager> ().DealDamage (final)) {
			if(gameObject.tag == "Enemy")
				Destroy (gameObject);
		}
	}
}
