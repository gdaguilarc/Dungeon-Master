using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using UnityEngine.UI;
using System; 

public class MainMenu : MonoBehaviour {

	public AudioMixer audioMixer;
	public GameObject loadingScreen; 
	public Slider slider; 


	IEnumerator LoadAsynchronously (int sceneIndex) {

		AsyncOperation operation = SceneManager.LoadSceneAsync (sceneIndex); 

		loadingScreen.SetActive (true); 

		while (!operation.isDone) {

			float progress = Mathf.Clamp01 (operation.progress/.9f); 

			//slider.value = progress; 

			yield return null; 
		}

	}




	public void playGame() {
		SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex + 1);
	}

	public void quitGame() {
		Debug.Log ("Quit");
		Application.Quit ();

	}


	public void setVolume(float Volume) {
		audioMixer.SetFloat ("Volume", Volume);
	}

	public void SetQuality(int qualityIndex) {
		QualitySettings.SetQualityLevel(qualityIndex);
	}

	public void SetFullScreen(bool isFullScreen) {
		Screen.fullScreen = isFullScreen;
	}

	public void LoadLevel(int sceneIndex) {
		StartCoroutine (LoadAsynchronously (sceneIndex)); 

	}
}
