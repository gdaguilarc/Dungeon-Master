using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollider : MonoBehaviour {


	int life = 8;
	public GameObject [] weapons;
	int selected = 0;

	public AudioClip playerHit;
	private AudioSource source;
	private float volLowRange = .75F;
	private float volHighRange = 1.5F;




	void Update(){


	}

	void Awake () {

		source = GetComponent<AudioSource>();
	}
	// Use this for initialization
	void Start () {
		selected = 0;
	}
	void OnTriggerEnter2D(Collider2D other){

		if (other.gameObject.name == "Bullet" || other.gameObject.name == "Bullet(Clone)"){
			float vol = Random.Range (volLowRange, volHighRange);
			source.PlayOneShot(playerHit,vol);
			life--;
			Destroy (other.gameObject);
		}
		if (other.gameObject.name == "Item shotgun" || other.gameObject.name == "Item shotgun(Clone)"){
			weapons[0].SetActive(false);
			weapons[1].SetActive(true);
			selected = 1;
			Destroy (other.gameObject);
		}
	}
	public void ResetWeapons(int child){
		transform.GetChild (child).gameObject.SetActive (false);
		transform.GetChild (0).gameObject.SetActive (true);

		selected = 0;
	}
	public int getWeaponIndex(){
		return selected;
	}

	public GameObject getWeapon(){
		return weapons[selected];
	}
	public int getLife(){
		return life;
	}
	void OnCollisionEnter2D(Collision2D other){

		if (other.gameObject.name == "Bottle-life" || other.gameObject.name == "Bottle-life(Clone)"){
			life = life + 4;
		}
	}

}
