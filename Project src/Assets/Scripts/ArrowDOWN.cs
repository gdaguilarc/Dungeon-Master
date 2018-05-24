using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowDOWN : MonoBehaviour {

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
            player.transform.position = new Vector2 (player.transform.position.x , player.transform.position.y - 22.214f);
            player.SetActive(true);
            camera.transform.position = new Vector3 (camera.transform.position.x , camera.transform.position.y - 32.52f, -10f);
        }
    }

    void changeState(){
        ACTIVE = true;
    }
}
