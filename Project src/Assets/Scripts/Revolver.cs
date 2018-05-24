using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Revolver : MonoBehaviour {

	public AudioClip shootSound;
	public AudioClip reloadSound;
	private AudioSource source;
	private float volLowRange = .75f;
	private float volHighRange = 1.2f;
	Animator anim;
	float delay = 2f;
	float currentTime = 0;
	public Rigidbody2D bullet;
	public float maxSpeed;
	public float spreadFactor = 0.01f;
	public GameObject cannon;
	public int magazine = 8;
	public GameObject player;

	void Awake () {

		source = GetComponent <AudioSource>();

	}
	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
	}

	IEnumerator ExecuteAfterTime(float time){
		yield return new WaitForSeconds (time);
		Time.timeScale = 0;
	}



	public int getMagazine(){
		return magazine;
	}

	// Update is called once per frame
	void Update () {
		if(currentTime <= 0){
			PlayerMovement other = player.gameObject.GetComponent<PlayerMovement> ();
			bool scale_x = other.GetSide ();

			if (Input.GetButtonDown("Fire1") && magazine > 0) {

				float vol = Random.Range (volLowRange, volHighRange);
				source.PlayOneShot(shootSound,vol);

				magazine--;
				Vector3 shootDirection3;


				if (!scale_x) {
					//...Spread one
					shootDirection3.z = 0f;
					shootDirection3.y = 0f;
					shootDirection3.x = 0.1f;


				} else {
					//...Spread one
					shootDirection3.z = 0f;
					shootDirection3.y = 0f;
					shootDirection3.x = -0.1f;

				}



				//Three shots from shotgun
				Rigidbody2D bulletInstance = Instantiate (bullet, new Vector3 (cannon.transform.position.x, cannon.transform.position.y), Quaternion.Euler (new Vector3 (cannon.transform.eulerAngles.x, cannon.transform.eulerAngles.y, cannon.transform.eulerAngles.z))) as Rigidbody2D;
				bulletInstance.AddRelativeForce (shootDirection3 * maxSpeed * 10f);



				anim.Play("shot");
			}


			if (Input.GetKeyDown (KeyCode.R) || magazine == 0){
				magazine = 8;
				currentTime = delay;
				float vol = Random.Range (volLowRange, volHighRange);
				source.PlayOneShot(reloadSound,vol);
			}

		}else{
			currentTime -= Time.deltaTime;
		}
	}
}
