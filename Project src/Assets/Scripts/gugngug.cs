using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gugngug : MonoBehaviour {

	// Jugador o heroe del juego
	public GameObject player;
	public GameObject enemigo;

	// Use this for initialization
	void Start () {

		//al que sigue
		player = GameObject.FindGameObjectWithTag ("Player");
	}

	// Calcular la diferencia del angulo
	float AngleBetweenTwoPoints(Vector3 a, Vector3 b) {
		return Mathf.Atan2(a.y - b.y, a.x - b.x) * Mathf.Rad2Deg;

	}

	// Update is called once per frame
	void Update () {

		// Trae la clase del enemigo
		Enemies enemy = enemigo.gameObject.GetComponent<Enemies> ();
		PlayerMovement hola = player.GetComponent<PlayerMovement> ();
		Vector2 positionOnScreen = transform.position;
		bool right = enemy.GetSide ();
		bool front = enemy.GetFront ();
		//Get the Screen position of the mouse
		Vector2 playerOnScreen = player.transform.position;
		float randomx = Random.Range (0, 2);
		float randomy = Random.Range (0, 2);


		float angle = AngleBetweenTwoPoints (playerOnScreen, positionOnScreen);

		if (right) {
			if (angle < 90 && angle > -90) {
				transform.localScale = new Vector3 (1f, 1);
				transform.rotation = Quaternion.Euler (new Vector3 (0f, 0f, angle));

			} else {
				transform.localScale = new Vector3 (-1f, 1f);
				angle = AngleBetweenTwoPoints (positionOnScreen, playerOnScreen);
				transform.rotation = Quaternion.Euler (new Vector3 (0f, 0f, angle));
			}
		} else {
			if (angle < 90 && angle > -90) {
				transform.localScale = new Vector3 (1f, -1f);
				AngleBetweenTwoPoints (positionOnScreen, playerOnScreen);
				transform.rotation = Quaternion.Euler (new Vector3 (0f, 0f, angle));

			} else {
				transform.localScale = new Vector3 (-1f, -1f);
				angle = AngleBetweenTwoPoints (playerOnScreen, positionOnScreen );
				transform.rotation = Quaternion.Euler (new Vector3 (0f, 0f, angle));
			}




		}
	}
}
