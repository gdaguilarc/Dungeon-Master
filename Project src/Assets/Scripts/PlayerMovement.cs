﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {



	public float scale_x;
	public float scale_y;

	public Sprite frontSprite;
	public Sprite backSprite;

	public bool right = true;
	public bool front = true;

	public float topspeed = 4f;
	Animator anim;
	const float timeout = 4.0f;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
	}

	// Update is called once per frame
	void Update () {

		Vector3 mov = new Vector3 (
			Input.GetAxisRaw("Horizontal"),
			Input.GetAxisRaw("Vertical"),
			0
		);
		transform.position = Vector3.MoveTowards (

			transform.position,
			transform.position+ mov,
			topspeed * Time.deltaTime

		);

		anim.SetFloat ("Axis_x", mov.x);
		anim.SetFloat("Axis_y", mov.y);
		if (mov.y < 0) {
			front = true;
			GetComponent<SpriteRenderer>().sprite = frontSprite;
		} else if (mov.y > 0) {
			front = false;
			GetComponent<SpriteRenderer>().sprite = backSprite;
		}
		if (mov.x < 0) {
			transform.localScale = new Vector3 (-scale_x, scale_y,1);
			right = true;
			front = true;

		}
		else if(mov.x > 0){
			transform.localScale = new Vector3 (scale_x, scale_y,1);
			right = false;
			front = true;
		}


		anim.SetBool("Front", front);

		anim.SetBool("Right", right);

	}

	public float GetX(){
		float x = Input.GetAxisRaw("Horizontal");
		return x;
	}
	public float GetY(){
		float y = Input.GetAxisRaw("Vertical");
		return y;
	}
	//.....Metodo para obtener el lado
	public bool GetSide(){
		return right;
	}
	public bool GetFront(){
		return front;
	}
	public void transformScales(){
		transform.localScale = new Vector3 (-scale_x, scale_y,1);
	}
	public void transformScalesReverse(){
		transform.localScale = new Vector3 (scale_x, scale_y,1);
	}
	public void SetFront(bool front){
		this.front = front;
	}
	public void SetSide(bool right){
		this.right = right;
	}
}
