using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemies : MonoBehaviour {

	//move things
	public float speed;

	//scales for the enemy
	public float scale_X;
	public float scale_Y;

	//sprites for enemy
	public Sprite frontSprite;
	public Sprite backSprite;

	//sides
	public bool right = true;
	public bool front = true;

	//anim for enemy
	Animator anim;
	const float timeout = 4.0f;

	//the player that is following
	public GameObject player;

	//life
	int life = 2;
	int  destroyTime = 3;

	//dar disparo
	bool disparo;
	bool dead = false;



	void Start () {

		player = GameObject.FindGameObjectWithTag ("Player");
		anim = gameObject.GetComponent<Animator> ();

	}


	void Update () {

		Vector3 mov = new Vector3 (
			0.01f,
			0.01f,
			0
		);

		//movement   >
		if (!dead){
			if (Vector2.Distance (transform.localPosition, player.transform.position) < 5){
				disparo = true;
				speed = 0;
				anim.SetBool ("stand", false);
			}

			//  <
			else if (Vector2.Distance (transform.localPosition, player.transform.position) > 5 && Vector2.Distance (transform.localPosition, player.transform.position) < 15) {
				disparo = true;
				speed = 2.0f;
				transform.position = Vector3.MoveTowards (transform.localPosition, player.transform.localPosition + mov, speed * Time.deltaTime);
				anim.SetBool ("stand", false);

			}
			else{
				disparo = false;
				anim.SetBool ("stand", true);
			}
		}else{
			speed = 0;
		}
		anim.SetFloat ("Axis_X", mov.x);
		anim.SetFloat ("Axis_Y", mov.y);

		//animations .

		//vertical
		if (mov.y < 0) {
			front = true;
			right = false;
			GetComponent<SpriteRenderer>().sprite = frontSprite;
			anim.SetBool("front", front);
			anim.SetBool("right", right);

		} else if (mov.y > 0) {
			front = false;
			right = false;
			GetComponent<SpriteRenderer>().sprite = backSprite;
			anim.SetBool("front", front);
			anim.SetBool("right", right);
		}
		if (mov.x < 0) {
			if (player.transform.position.x < transform.position.x) {
				transform.localScale = new Vector3 (-scale_X, scale_Y, 1);
				right = false;
				front = false;
			} else {
				transform.localScale = new Vector3 (scale_X, scale_Y, 1);
				right = true;
				front = false;
			}
			anim.SetBool("right", right);
			anim.SetBool("front", front);

		}
		else if(mov.x > 0){
			if (player.transform.position.x > transform.position.x) {
				transform.localScale = new Vector3 (scale_X, scale_Y,1);
				right = true;
				front = false;
			} else {
				transform.localScale = new Vector3 (-scale_X, scale_Y, 1);
				right = false;
				front = false;
			}
			anim.SetBool("right", right);
			anim.SetBool("front", front);
		}



	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.name == "Bullet2(Clone)") {
			Destroy (other.gameObject);
			if (life == 0) {
				dead = true;
				disparo = false;
				anim.Play("jdead");
				Destroy (gameObject, destroyTime);
			} else {
				life--;
			}
		}
	}

	public bool GetSide(){
		return right;
	}
	public bool GetFront(){
		return front;
	}
	public bool GetDisparo(){
		return disparo;
	}


}
