using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fruitsRndom : MonoBehaviour {

	public GameObject fruit;
	public Sprite[] fruitsMuch;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D other){

		if (other.tag == "player") {
			Destroy (gameObject);
		}
	}
}
