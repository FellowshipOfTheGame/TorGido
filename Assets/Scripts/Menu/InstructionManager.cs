using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstructionManager : MonoBehaviour {
	public GameObject Panel1;
	public GameObject Panel2;
	public GameObject Panel3;
	public GameObject Panel4;

	//Panel Atual : 1
	public void Next_Panel2(){
		Panel1.SetActive (false);
		Panel3.SetActive (false);
		Panel4.SetActive (false);
		Panel2.SetActive (true);
	
	}
	// Panel atual : 2
	public void Prev_Panel1(){
		Panel2.SetActive (false);
		Panel3.SetActive (false);
		Panel4.SetActive (false);
		Panel1.SetActive (true);

	}
	public void Next_Panel3(){
		Panel1.SetActive (false);
		Panel2.SetActive (false);
		Panel4.SetActive (false);
		Panel3.SetActive (true);

	}
	//Panel Atual : 3
	public void Next_Panel4(){
		Panel1.SetActive (false);
		Panel2.SetActive (false);
		Panel3.SetActive (false);
		Panel4.SetActive (true);

	}
	public void Prev_Panel2(){
		Panel1.SetActive (false);
		Panel3.SetActive (false);
		Panel4.SetActive (false);
		Panel2.SetActive (true);

	}
	//Panel Atual : 4
	public void Prev_Panel3(){
		Panel1.SetActive (false);
		Panel2.SetActive (false);
		Panel4.SetActive (false);
		Panel3.SetActive (true);

	}


}
