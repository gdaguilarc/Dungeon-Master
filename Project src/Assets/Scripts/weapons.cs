using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weapons : MonoBehaviour {

	public GameObject player;

	// Use this for initialization
	void Start () {

	}

	float AngleBetweenTwoPoints(Vector3 a, Vector3 b) {
		return Mathf.Atan2(a.y - b.y, a.x - b.x) * Mathf.Rad2Deg;

	}



	// Update is called once per frame
	void Update () {



		PlayerMovement other = player.gameObject.GetComponent<PlayerMovement> ();
		bool scale_x = other.GetSide ();
		bool front = other.GetFront ();

		if (front) {
			transform.localPosition = new Vector3 (transform.localPosition.x, transform.localPosition.y, 0);
		} else {
			transform.localPosition = new Vector3 (transform.localPosition.x, transform.localPosition.y, 2);
		}


		Vector2 positionOnScreen = Camera.main.WorldToViewportPoint (transform.position);

		//Get the Screen position of the mouse
		Vector2 mouseOnScreen = (Vector2)Camera.main.ScreenToViewportPoint(Input.mousePosition);


		float angle = transform.eulerAngles.z;

		if(scale_x){
			angle = AngleBetweenTwoPoints (positionOnScreen, mouseOnScreen);
			if(angle > 0 && angle < 180){
				other.SetFront(true);
				if (angle >	90){
					other.SetSide(false);
					other.transformScalesReverse();
				}
			}else{
				other.SetFront(false);
				if (angle <	-90){
					other.SetSide(false);
					other.transformScalesReverse();

				}
			}
		}else{
			angle = AngleBetweenTwoPoints (mouseOnScreen, positionOnScreen);
			if(angle > 0 && angle < 180){
				other.SetFront(false);
				if (angle > 90){
					other.SetSide(true);
					other.transformScales();

				}
			}else{
				other.SetFront(true);
				if (angle <	 -90){
					other.SetSide(true);
					other.transformScales();

				}
			}
		}


		transform.rotation = Quaternion.Euler (new Vector3 (0f, 0f, angle));






	}
}
