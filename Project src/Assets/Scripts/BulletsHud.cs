using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BulletsHud : MonoBehaviour {

	public GameObject player;
	bool magazineComplete = true;
	public Image bullets;
	GameObject weapon;
	int selected;
	int magazine;
	int remainingBullets;
	public GameObject [] weapons;

	// Use this for initialization
	void Start () {

	}



	// Update is called once per frame
	void Update () {
		PlayerCollider other = player.GetComponent<PlayerCollider> ();
		selected = other.getWeaponIndex ();

		if (selected == 0 && magazineComplete){
			Revolver rev = weapons [0].GetComponent<Revolver>();
			magazine = rev.getMagazine ();
			bullets.fillAmount = (magazine * 0.0625f);
		}
		else if (selected == 1 && magazineComplete){
			Shotgun other2 = weapons [1].GetComponent<Shotgun>();
			magazine = other2.getMagazine ();
			bullets.fillAmount = (magazine * 0.0625f);
			remainingBullets = other2.getAmmo ();
		}

		


	}
}
