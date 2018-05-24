using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowLEFT : MonoBehaviour {

    public bool ACTIVE = false;
    public GameObject player;
    public GameObject camera;


    void Start (){
        player = GameObject.Find("Player");
        camera = GameObject.Find("Main Camera");
    }
    void OnTriggerEnter2D(Collider2D other) {
        if (ACTIVE && other.gameObject.name == "Player"){
            player.SetActive(false);
            player.transform.position = new Vector2 (player.transform.position.x -14.436f, player.transform.position.y);
            player.SetActive(true);
            camera.transform.position = new Vector3 (camera.transform.position.x - 32.64f , camera.transform.position.y, -10f);
            
        }
    }

    void changeState(){
        ACTIVE = true;
    }
}
