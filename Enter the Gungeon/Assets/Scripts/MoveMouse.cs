using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveMouse : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		         //Get the Screen positions of the object
         Vector2 positionOnScreen = Camera.main.WorldToViewportPoint (transform.position);
         
         //Get the Screen position of the mouse
         Vector2 mouseOnScreen = (Vector2)Camera.main.ScreenToViewportPoint(Input.mousePosition);
         
         //Get the angle between the points
         //float angle = AngleBetweenTwoPoints(positionOnScreen, mouseOnScreen);
		float angle = AngleBetweenTwoPoints(mouseOnScreen, positionOnScreen);
         //Ta Daaa
		if (angle < 90 && angle > -90) {
			transform.localScale = new Vector3 (1f, 1);
			transform.rotation = Quaternion.Euler (new Vector3 (0f, 0f, angle));
		} else {
			transform.localScale = new Vector3 (-1f, 1);
			angle = AngleBetweenTwoPoints(positionOnScreen, mouseOnScreen);
			transform.rotation = Quaternion.Euler (new Vector3 (0f, 0f, angle));
		}

     }
	float AngleBetweenTwoPoints(Vector3 a, Vector3 b) {
		return Mathf.Atan2(a.y - b.y, a.x - b.x) * Mathf.Rad2Deg;

	}
}
	

