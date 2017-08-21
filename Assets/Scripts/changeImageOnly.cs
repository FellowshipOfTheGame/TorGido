using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class changeImageOnly : MonoBehaviour {

	Image myImageComponent;
	public Sprite myFirstImage; //Drag your first sprite here in inspector.
	public Sprite mySecondImage; //Drag your second sprite here in inspector.
	private float _time;
	int i;

	void Start () {
		myImageComponent = GetComponent<Image>(); //Our image component is the one attached to this gameObject.
		_time = 0;
		i = 0;
	}
	
	void Update(){
		if (_time <= 0.5f) {
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
		void SetImage1() 
		{
			myImageComponent.sprite = myFirstImage;

		}
		void SetImage2(){
			myImageComponent.sprite = mySecondImage;
		
		}
	
	}
