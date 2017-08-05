using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//script que contem os stats base do gido, tor e inimigos.
//Os efeitos dos itens serao tratados nesse script
public class StatsManager : MonoBehaviour {

	public float speed = 0f;
	public float damage = 0f;
	public float defense = 0f;
	public float attack_speed = 0f;
	public float range = 0f;
	public float field = 1000f; //campo de visão

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	/*public float speed{
		get { return kSpeed; }
		set { kSpeed = value; }
	}

	public float damage{
		get { return kDamage; }
		set { kDamage = value; }
	}

	public float defense{
		get { return kDefense; }
		set { kDefense = value; }
	}

	public float attack_speed{
		get { return kAttack_speed; }
		set { kAttack_speed = value; }
	}

	public float range{
		get { return kRange; }
		set { kRange = value; }
	}

	public float field{
		get { return kField; }
		set { kField = value; }
	}*/
}
