using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coffer : MonoBehaviour {

	bool open = false;
	int  destroyTime = 3;
	Animator anim;

	// Use this for initialization
	void Start () {
		
		anim = gameObject.GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter2D(Collision2D coll){
		
		if (coll.gameObject.CompareTag ("Player"))  {
	
			open = true;
			anim.SetBool ("open",open);
			Destroy (gameObject, destroyTime);

		}
	}
}
