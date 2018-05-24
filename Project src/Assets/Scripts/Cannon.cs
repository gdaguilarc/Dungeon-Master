using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour {

	//shooting
	private float speed = 600;
	public GameObject enemy;

	//time 4 each shoot
	private float forshots;
	public float startime;

	//
	public Rigidbody2D bullet;
	public GameObject player;
	bool shoot;


	// Use this for initialization
	void Start () {
		forshots = startime;
		player = GameObject.FindGameObjectWithTag ("Player");


	}

	// Update is called once per frame
	void Update (){



		if (Vector2.Distance (transform.localPosition, player.transform.localPosition) > 3) {
			
			// Obtener el lado del enemigo (JAKY)
			Enemies enemies = enemy.gameObject.GetComponent<Enemies> ();
			bool right = enemies.GetSide ();

			shoot = enemies.GetDisparo ();


			//Disparar
			if (shoot) {
				if (forshots <= 0) {
					Rigidbody2D bala = Instantiate (bullet, new Vector3 (transform.position.x, transform.position.y), Quaternion.Euler (new Vector3 (transform.eulerAngles.x, transform.eulerAngles.y, transform.eulerAngles.z)));
					if (!right) {
						bala.AddRelativeForce (new Vector2 (1f, 0f) * speed);
					} else {
						bala.AddRelativeForce (new Vector2 (1f, 0f) * speed);
					}
					forshots = startime;
				} else {
					forshots -= Time.deltaTime;
				}
			}
		}





	}
}
