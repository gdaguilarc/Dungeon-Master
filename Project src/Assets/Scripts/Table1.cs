using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Table1 : MonoBehaviour {

	bool right;
	bool front;
	bool back;
	bool left;


	float y;
	float x;

	Animator anim;

	//PLayer
	GameObject player;

	// Use this for initialization
	void Start () {
		//change for player

		player = GameObject.FindGameObjectWithTag ("Player");
		PlayerMovement other = player.GetComponent<PlayerMovement>();
		anim = gameObject.GetComponent<Animator> ();
	}

	// Update is called once per frame
	void Update () {


		PlayerMovement other = player.GetComponent<PlayerMovement>();

		right = other.GetSide();
		front = other.GetFront();
		y = other.GetY();
		x = other.GetX();




	}

	void OnCollisionEnter2D(Collision2D coll){


		if (coll.gameObject.CompareTag ("Player")) {
			if (!right) {
				anim.SetBool ("Right", false);
				anim.SetBool("Front", false);
				anim.SetBool("Left", true);
				anim.SetBool("Back", false);
			} else if (front) {
				anim.SetBool("Front", true);
				anim.SetBool("Right", false);
				anim.SetBool("Left", false);
				anim.SetBool("Back", false);
			} else if (x > 0) {
				anim.SetBool("Left", false);
				anim.SetBool("Front", false);
				anim.SetBool("Right", true);
				anim.SetBool("Back", false);
			} else if (y > 0) {
				anim.SetBool("Right", false);
				anim.SetBool("Front", false);
				anim.SetBool("Left", false);
				anim.SetBool("Back", true);
			}
		}

		else if (coll.gameObject.name == "Bullet" || coll.gameObject.name == "Bullet(Clone)" || coll.gameObject.name == "Bullet2(Clone)" || coll.gameObject.name == "Bullet2") {
			Destroy (coll.gameObject);
		}
	}

}
