using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barril : MonoBehaviour {

	bool broke= false;
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

		if (coll.gameObject.name == "Bullet2(Clone)" || coll.gameObject.name == "Bullet(Clone)")  {
			broke = true;
			anim.SetBool ("broke", broke);
			Destroy (gameObject, destroyTime);
			Destroy(coll.gameObject);

		}
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.name == "Bullet2(Clone)" || other.gameObject.name == "Bullet(Clone)") {
			broke = true;
			anim.SetBool ("broke", broke);
			Destroy (gameObject, destroyTime);

		}
	}
}
