using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDies : MonoBehaviour {
	Animator anim;
	bool life = true;
	bool once = false;


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
			GameMaster master = GetComponent<GameMaster> ();
			if (!once) {
				//for the win
				//master.UpdateEnemies ();
			}
			once = true;


		}
	}
	public bool GetLife(){
		return life;
	}
}
