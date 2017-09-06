using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour {

	public GameObject MenuPrincipal;
	public GameObject MenuCreditos;
	public GameObject MenuConfiguracoes;
	public GameObject MenuInstrucoes;
	public GameObject BotaoSom;

	public GameObject InstructionPanel1;
	public GameObject InstructionPanel2;
	public GameObject InstructionPanel3;
	public GameObject InstructionPanel4;
	public GameObject InstructionPanel5;

	public void Jogar() {
		BotaoSom.GetComponent<ClickSound> ().PlaySound ();
		SceneManager.LoadScene ("Arena");
	}

	public void Sair() {
		BotaoSom.GetComponent<ClickSound> ().PlaySound ();
		Application.Quit ();
	}
	public void Pricipal() {
		BotaoSom.GetComponent<ClickSound> ().PlaySound ();
			MenuCreditos.SetActive (false);
			MenuInstrucoes.SetActive (false);
			MenuConfiguracoes.SetActive (false);
			MenuPrincipal.SetActive (true);
			

	}

	public void PricipalInstructions() {
		
		BotaoSom.GetComponent<ClickSound> ().PlaySound ();
		MenuCreditos.SetActive (false);
		MenuInstrucoes.SetActive (false);
		MenuConfiguracoes.SetActive (false);
		MenuPrincipal.SetActive (true);
		InstructionPanel5.SetActive (false);
		InstructionPanel4.SetActive (false);
		InstructionPanel3.SetActive (false);
		InstructionPanel2.SetActive (false);
		InstructionPanel1.SetActive (true);


	}

	public void Creditos() {
		BotaoSom.GetComponent<ClickSound> ().PlaySound ();
		MenuPrincipal.SetActive (false);
		MenuInstrucoes.SetActive (false);
		MenuConfiguracoes.SetActive (false);
		MenuCreditos.SetActive (true);

	}
	public void Configuracoes() {
		BotaoSom.GetComponent<ClickSound> ().PlaySound ();
		MenuPrincipal.SetActive (false);
		MenuCreditos.SetActive (false);
		MenuInstrucoes.SetActive (false);
		MenuConfiguracoes.SetActive (true);

	}
	public void Instruções() {
		BotaoSom.GetComponent<ClickSound> ().PlaySound ();
		MenuPrincipal.SetActive (false);
		MenuCreditos.SetActive (false);
		MenuConfiguracoes.SetActive (false);
		MenuInstrucoes.SetActive (true);
		
	}


}
