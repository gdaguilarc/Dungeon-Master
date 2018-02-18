using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDetection : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	}
	void OnTriggerEnter2D(Collider2D other){
		
		if (other.tag == "fruit") {
			PlayerDies player = GetComponent<PlayerDies> ();	
			bool life = player.GetLife ();
			if (life) {
				player.Sethp (player.Gethp () + 10);
			}
		}
	}
}
