using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour {
	public GameObject MenuPrincipal;
	public GameObject MenuCreditos;
	public GameObject MenuConfiguracoes;
	public GameObject MenuInstrucoes;
	// Use this for initialization

	public Slider volumeSlider;
	public Toggle fullscreenToggle;
	public int[] screenWidths;

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Jogar() {
		//SceneManager.LoadScene ("Game");
	}

	public void Sair() {
		Application.Quit ();
	}
	public void Pricipal() {
		MenuCreditos.SetActive (false);
		MenuInstrucoes.SetActive (false);
		MenuConfiguracoes.SetActive (false);
		MenuPrincipal.SetActive (true);
	}
	public void Creditos() {
		MenuPrincipal.SetActive (false);
		MenuInstrucoes.SetActive (false);
		MenuConfiguracoes.SetActive (false);
		MenuCreditos.SetActive (true);
	}
	public void Configuracoes() {
		MenuPrincipal.SetActive (false);
		MenuCreditos.SetActive (false);
		MenuInstrucoes.SetActive (false);
		MenuConfiguracoes.SetActive (true);
	}
	public void Instruções() {
		MenuPrincipal.SetActive (false);
		MenuCreditos.SetActive (false);
		MenuConfiguracoes.SetActive (false);
		MenuInstrucoes.SetActive (true);

	}


}
