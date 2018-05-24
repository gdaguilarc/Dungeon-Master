using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossControl : MonoBehaviour {
	int boss = 1;
	int bossesAlive = 1;

	public Image win;

	void Start(){
	}
	public void killABoss() {
		bossesAlive--;
	}

	public int getBossesLeft () {
		return boss;
	}
	public int getBosseAlive () {
		return bossesAlive;
	}

	public void UpdateBossesLeft(){
		boss--;
	}
	public bool isBoss(){
		int i = getBossesLeft();
		if (i > 0){
			return true;
		}
		else{
			return false;
		}
	}
	public void isGame(){
		killABoss();
		int i = getBosseAlive();
		if (i <= 0){
			win.gameObject.SetActive (true);
		}
	}

}
