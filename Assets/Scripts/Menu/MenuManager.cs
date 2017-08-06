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

	public void Jogar() {
		BotaoSom.GetComponent<ClickSound> ().PlaySound ();
		//SceneManager.LoadScene ("Game");
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
