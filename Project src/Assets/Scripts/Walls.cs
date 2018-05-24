using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walls : MonoBehaviour {


	//Destruct bullets
	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.name == "Bullet2(Clone)" || other.gameObject.name == "Bullet(Clone)") {
			Destroy (other.gameObject);
		}
	}



}
