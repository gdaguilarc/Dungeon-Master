using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDies : MonoBehaviour {
	Animator anim;
	bool life = true;
	int hp = 100;


	void Start () {
		anim = GetComponent<Animator> ();
	}

	// Update is called once per frame
	void OnTriggerEnter2D(Collider2D other){
		if (other.tag == "bulletenemy" && hp <= 0) {
			anim.Play ("Dead");
			Destroy (other.gameObject);
			life = false;
			transform.GetComponent<Rigidbody2D> ().bodyType = RigidbodyType2D.Static;
		} else if (hp > 0 && other.tag == "bulletenemy") {
			hp = hp - 5;
		}
	}
	public bool GetLife(){
		return life;
	}
	public int Gethp (){
		return hp;
	}
	public void Sethp(int hp){
		this.hp = hp;
	}
}
