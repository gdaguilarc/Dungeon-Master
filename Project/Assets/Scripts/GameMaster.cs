using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameMaster : MonoBehaviour {

	public Text text;
	int enemies = 11;
	bool heroe;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		PlayerDies player = GetComponent<PlayerDies> ();	
		bool life = player.GetLife ();
		if (life) {
			if (enemies > 0) {
				text.text = "Vida: " + player.Gethp ();
			} else {
				text.text = "YOU WIN";
			}

		} else {
			text.text = "YOU LOSE";
		}
	}
	public void UpdateEnemies(){
		enemies--;
	}
}
