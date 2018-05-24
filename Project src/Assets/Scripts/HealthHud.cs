using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthHud : MonoBehaviour {

	public GameObject player;
	public Image gameover;
	public Image health;
	int life;
	bool isAlive;

	private AudioSource source;
	public AudioClip playerDead;
	private float volLowRange = .75F;
	private float volHighRange = 1.5F;

	float delay = 2f;
	float currentTime = 0f;

	void Awake () {
		source = GetComponent<AudioSource>();
	}


	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		PlayerCollider other = player.GetComponent<PlayerCollider> ();
		life = other.getLife ();

		if (life == 0) {

			if(currentTime == 0f){
				currentTime = delay;

				float vol = Random.Range (volLowRange, volHighRange);
				source.PlayOneShot(playerDead,vol);
				currentTime = 2f;
			}else{
				currentTime = 2f;
			}
			isAlive = false;
			gameover.gameObject.SetActive (true);
			//Destroy (player.GetComponent<Animator>());
		} else {
			health.fillAmount = ((int)(life/4)*0.25f);
		}
	}
}
