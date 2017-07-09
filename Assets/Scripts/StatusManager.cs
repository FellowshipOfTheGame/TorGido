using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatusManager : MonoBehaviour {

	private float kSpeed = 0f;
	private float kDamage = 0f;
	private float kDefense = 0f;
	private float kAttack_speed = 0f;
	private float kRange = 0f;
	private float kField = 0f; //campo de visão

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public float speed{
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
	}
}
