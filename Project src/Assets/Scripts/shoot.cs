using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shoot : MonoBehaviour {

	public float speed;
	private Transform enemy;
	private Vector2 target;

	// Use this for initialization
	void Start() {

		enemy = GameObject.FindGameObjectWithTag("Enemy").transform;
		target = new Vector2 (enemy.position.x, enemy.position.y);
	}
	


	void OnTriggerEnter2D(Collider2D other){
		if (other.tag == "Bullet2(Clone)") {
			Destroy (gameObject);
		}
	}
}
