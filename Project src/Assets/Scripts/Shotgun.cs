using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotgun : MonoBehaviour {

	Animator anim;
	float delay = 2f;
	float currentTime = 0f;
	public int ammunition = 12;
	private int magazine = 4;
	public Rigidbody2D bullet;
	public float maxSpeed;
	public float spreadFactor = 0.01f;
	public GameObject cannon;
	public AudioClip shootSound;
	public AudioClip reloadSound;
	private AudioSource source;
	private float volLowRange = .75f;
	private float volHighRange = 1.2f;

	public GameObject player;

	void Awake () {

		source = GetComponent <AudioSource>();
	}
	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
	}
	public int getAmmo(){
		return ammunition;
	}
	public int getMagazine(){
		return magazine;
	}

	// Update is called once per frame
	void Update () {
		if (currentTime <= 0) {
			PlayerMovement other = player.gameObject.GetComponent<PlayerMovement> ();
			PlayerCollider other2 = player.gameObject.GetComponent<PlayerCollider> ();
			bool scale_x = other.GetSide ();

			if (Input.GetButtonDown ("Fire1") && ammunition > 0 && magazine > 0) {

				float vol = Random.Range (volLowRange, volHighRange);
				source.PlayOneShot(shootSound,vol);

				ammunition--;
				magazine--;


				Vector3 shootDirection;
				Vector3 shootDirection2;
				Vector3 shootDirection3;


				if (!scale_x) {
					//...Spread one

					shootDirection.z = 0.0f;
					shootDirection.y = 0.04f;
					shootDirection.x = 0.1f;

					//....Spread two

					shootDirection2.z = 0.0f;
					shootDirection2.y = -0.04f;
					shootDirection2.x = 0.1f;

					shootDirection3.z = 0f;
					shootDirection3.y = 0f;
					shootDirection3.x = 0.1f;


				} else {
					//...Spread one

					shootDirection.z = 0.0f;
					shootDirection.y = 0.04f;
					shootDirection.x = -0.1f;

					//....Spread two
					shootDirection2.z = 0.0f;
					shootDirection2.y = -0.04f;
					shootDirection2.x = -0.1f;

					shootDirection3.z = 0f;
					shootDirection3.y = 0f;
					shootDirection3.x = -0.1f;

				}



				//Three shots from shotgun
				Rigidbody2D bulletInstance = Instantiate (bullet, new Vector3 (cannon.transform.position.x, cannon.transform.position.y), Quaternion.Euler (new Vector3 (cannon.transform.eulerAngles.x, cannon.transform.eulerAngles.y, cannon.transform.eulerAngles.z))) as Rigidbody2D;
				bulletInstance.AddRelativeForce (shootDirection3 * maxSpeed * 10f);

				Rigidbody2D bulletInstance2 = Instantiate (bullet, new Vector3 (cannon.transform.position.x, cannon.transform.position.y), Quaternion.Euler (new Vector3 (transform.eulerAngles.x, transform.eulerAngles.y, transform.eulerAngles.z))) as Rigidbody2D;
				bulletInstance2.AddRelativeForce (shootDirection * maxSpeed * 10f);

				Rigidbody2D bulletInstance3 = Instantiate (bullet, new Vector3 (cannon.transform.position.x, cannon.transform.position.y), Quaternion.Euler (new Vector3 (transform.eulerAngles.x, transform.eulerAngles.y, transform.eulerAngles.z))) as Rigidbody2D;
				bulletInstance3.AddRelativeForce (shootDirection2 * maxSpeed * 10f);


				anim.Play ("Shot");

			}






			if (magazine == 0 || Input.GetKeyDown (KeyCode.R)) {
				magazine = 4;
				currentTime = delay;
			}
			if (ammunition == 0) {
				other2.ResetWeapons (1);
				ammunition = 12;
			}

		}else{
			currentTime -= Time.deltaTime;
		}


	}

}
