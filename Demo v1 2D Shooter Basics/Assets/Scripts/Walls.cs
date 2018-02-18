using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walls : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	void OnTriggerEnter2D(Collider2D other){
		if (other.tag == "bullet" || other.tag == "bulletenemy") {
			Destroy (other.gameObject);
		}
	}
}
