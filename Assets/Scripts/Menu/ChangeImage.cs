using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeImage : MonoBehaviour {
	Image myImageComponent;
	public Sprite myFirstImage; //Drag your first sprite here in inspector.
	public Sprite mySecondImage; //Drag your second sprite here in inspector.
	private float _time;
	public ImageRotate ir;
	int i;


	void Start() //Lets start by getting a reference to our image component.
	{
		myImageComponent = GetComponent<Image>(); //Our image component is the one attached to this gameObject.
		_time = 0;
		i = 0;
	}

	void Update(){
		if (_time <= 2f) {
			_time += Time.deltaTime;
		} else {
			if (i == 0) {
				i = 1;
				SetImage1 ();

			} else {
				i = 0;
				SetImage2 ();
		
			}


			_time = 0;
		}
	}


	public void SetImage1() //method to set our first image
	{
		myImageComponent.sprite = myFirstImage;
		ir.Rotateto0 ();
	}

	public void SetImage2(){
		myImageComponent.sprite = mySecondImage;
		ir.Rotateto180 ();
	}



}
