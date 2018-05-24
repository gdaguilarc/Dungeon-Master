using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using UnityEngine.UI;

public class GameOver : MonoBehaviour {


	int time = 200;
	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		time--;
		if (time == 5){
			SceneManager.LoadScene (0);
		}
	}

	void OnMouseDown(){
	   // this object was clicked - do something


	}
}
