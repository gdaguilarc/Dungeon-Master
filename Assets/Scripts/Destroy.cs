using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour {
	Animator anim;
	bool life = true;
	public GameObject ob;
	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
	}

	// Update is called once per frame
	void OnTriggerEnter2D(Collider2D other){
		if (other.tag == "bullet") {
			anim.Play("Death");
			Destroy (other.gameObject);
			life = false;
			transform.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
		}
	}
	public bool GetLife(){
		return life;
	}
}

