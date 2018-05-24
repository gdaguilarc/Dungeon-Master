using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Random = UnityEngine.Random;

public class Rooms: MonoBehaviour {


    //Int number of enemies
    public int numberEnemy = 0;

    //Things for change of room
    private bool ACTIVE = false;
    public GameObject [] enemies;
    public GameObject arrowUP;
    public GameObject arrowDOWN;
    public GameObject arrowLEFT;
    public GameObject arrowRIGHT;



    private GameObject arrows;

    //Type of FENG SHUI
    private int typeShui;
    private int numberMethods = 17;

    // Base size of each room
    private int rows = 21;
    private int columns = 23;

    // POSITION OF THE ROOM
    public Vector2 gridPos;

    // Type of room
    public bool UP, DOWN, RIGHT, LEFT;
    private String type;
    private int spritesType; // This variable is 0 until we have more sprites

    // The control of each position
    private Transform boardHolder;
    private List <Vector3> gridPositions = new List <Vector3> ();


    public int a;

    //The heroe of our game
    //public GameObject player;

    /*
        All the sprites
            position in the arrays
                0. Technologic sprites
                1. Pirate sprites
    */

	public GameObject[] floorTiles;
	public GameObject[] wallInPerspective;
	public GameObject[] verticalWall;
	public GameObject[] horizontalWall;
    public GameObject[] door;
    public GameObject[] chests;
    public GameObject[] table;
    public GameObject[] bottles;
    public GameObject[] box;
	public GameObject[] boxes;
    public GameObject[] barriles;
    public GameObject[] weapon;
	public GameObject[] wallDecorations;
    public GameObject[] bosses;

    public GameObject generator;


    // Clear & Initialize the list of positions
    void InitializeList() {
        gridPositions.Clear();
        for (int i = 0; i < columns; i++) {
            for (int j = 0; j < rows; j++) {
                gridPositions.Add(new Vector3 (i, j, 0f));
            }
        }
    }

    void Start(){
        generator = GameObject.FindGameObjectWithTag ("Gen");
        spritesType = Random.Range(0, floorTiles.Length);
        InitializeList();
        choiceRoom();
        InstantiateArrows();
        FENGSHUI();
    }

    void Update (){

    }

    void FENGSHUI(){


        typeShui = Random.Range(2, numberMethods+1);

        //root always is empty
        if (transform.position.x == 0 && transform.position.y == 0){
            typeShui =  0;
        }
        if ((UP && !DOWN && !LEFT && !RIGHT) || (!UP && !DOWN && !LEFT && RIGHT)){
            typeShui = 1;
        }
        if ((UP && !DOWN && !LEFT && !RIGHT) || (!UP && !DOWN && !LEFT && RIGHT) || (!UP && !DOWN && LEFT && !RIGHT) || (!UP && DOWN && !LEFT && !RIGHT)){
            BossControl one = generator.gameObject.GetComponent<BossControl> ();
            bool yeti = one.isBoss();

            if (yeti) {
                typeShui = 800;
                one.UpdateBossesLeft(); 
            }
        }


        // Make different types of rooms
        if (typeShui == 0){
            roomEMPTY();
        }
        if (typeShui == 1){
			roomCHEST();
        }
        if (typeShui == 2){
			roomRandom2();
        }
        if (typeShui == 3){
			roomShotgun();
        }
        if (typeShui == 4){
            roomRESUPPLY();
        }
        if (typeShui == 5){
			roomRandom1();
        }
		if (typeShui == 6){
			roomBASIC1();
		}
        if (typeShui == 7){
			roomBASIC2();
        }
        if (typeShui == 8){
			roomBASIC3();
        }
		if (typeShui == 9){
			roomBASIC4();
		}
		if (typeShui == 10){
			roomBASIC5();
		}
		if (typeShui == 11) {
			roomBASIC6();
		}
		if (typeShui == 12) {
			roomBASIC7();
		}
		if (typeShui == 13) {
			roomBASIC8();
		}
		if (typeShui == 14) {
			roomBASIC9();
		}
		if (typeShui == 15) {
			roomBASIC10();
		}
		if (typeShui == 16) {
			roomBASIC11();
		}
		if (typeShui == 17) {
			roomBASIC12();
		}
        if (typeShui == 800) {
			Boss();
		}
    }
    void Boss(){
        for (int i = 1; i < 8; i++) {
            GameObject bottle1 = Instantiate(bottles[spritesType], new Vector2 (transform.position.x+i, transform.position.y+1.5f), Quaternion.Euler(0,0, 0));
            bottle1.transform.SetParent (boardHolder);
        }

        for (int i = 14; i < 21; i++) {
            GameObject bottle1 = Instantiate(bottles[spritesType], new Vector2 (transform.position.x+i, transform.position.y+15 ), Quaternion.Euler(0,0, 0));
            bottle1.transform.SetParent (boardHolder);
        }

		int rand = Random.Range (0, 3);
        GameObject boss = Instantiate(bosses[rand], new Vector2 (transform.position.x+11f, transform.position.y+10f), Quaternion.Euler(0,0, 0));
        boss.transform.SetParent (boardHolder);

        for (int j = 0; j < 1; j++){
            GameObject box1 = Instantiate(weapon[0], new Vector2 (transform.position.x + Random.Range(2, 20), transform.position.y+ Random.Range(2, 14)), Quaternion.Euler(0,0, 0));
            box1.transform.SetParent (boardHolder);
        }

        GameObject table1 = Instantiate(table[spritesType], new Vector2 (transform.position.x+15, transform.position.y+6f), Quaternion.Euler(0,0, 0));
        table1.transform.SetParent (boardHolder);
        GameObject table2 = Instantiate(table[spritesType], new Vector2 (transform.position.x+6, transform.position.y+6f), Quaternion.Euler(0,0, 0));
        table2.transform.SetParent (boardHolder);
        GameObject table3 = Instantiate(table[spritesType], new Vector2 (transform.position.x+6, transform.position.y+12f), Quaternion.Euler(0,0, 0));
        table3.transform.SetParent (boardHolder);
        GameObject table4 = Instantiate(table[spritesType], new Vector2 (transform.position.x+15, transform.position.y+12f), Quaternion.Euler(0,0, 0));
        table4.transform.SetParent (boardHolder);



    }
    void roomRandom2(){

        for (int j = 0; j < Random.Range(5, 20); j++){
            if (j%2 == 0){
                GameObject barril1 = Instantiate(barriles[spritesType], new Vector2 (transform.position.x + Random.Range(2, 20), transform.position.y + Random.Range(2, 14)), Quaternion.Euler(0,0, 0));
                barril1.transform.SetParent (boardHolder);
            }else{
                GameObject enemies1 = Instantiate(enemies[Random.Range(0, enemies.Length)], new Vector2 (transform.position.x + Random.Range(2, 20), transform.position.y+ Random.Range(2, 14)), Quaternion.Euler(0,0, 0));
                enemies1.transform.SetParent (boardHolder);
            }
        }
    }
    void roomShotgun(){

        for (int i = 1; i < 6; i++) {
            int rand = Random.Range(1, 4);
            GameObject barril1 = Instantiate(barriles[spritesType], new Vector2 (transform.position.x+i+rand, transform.position.y+1.5f), Quaternion.Euler(0,0, 0));
            barril1.transform.SetParent (boardHolder);
        }

        for (int i = 16; i < 21; i++) {
            int rand = Random.Range(1, 4);
            GameObject barril1 = Instantiate(barriles[spritesType], new Vector2 (transform.position.x+i-rand, transform.position.y+15f), Quaternion.Euler(0,0, 0));
            barril1.transform.SetParent (boardHolder);
        }

        for (int j = 0; j < 1; j++){
            GameObject box1 = Instantiate(weapon[0], new Vector2 (transform.position.x + Random.Range(2, 20), transform.position.y+ Random.Range(2, 14)), Quaternion.Euler(0,0, 0));
            box1.transform.SetParent (boardHolder);
        }
    }
    void roomRandom1(){
        for (int i = 1; i < 6; i++) {
            int rand = Random.Range(1, 4);
            GameObject barril1 = Instantiate(barriles[spritesType], new Vector2 (transform.position.x+i+rand, transform.position.y+1.5f), Quaternion.Euler(0,0, 0));
            barril1.transform.SetParent (boardHolder);
        }

        for (int i = 16; i < 21; i++) {
            int rand = Random.Range(1, 4);
            GameObject barril1 = Instantiate(barriles[spritesType], new Vector2 (transform.position.x+i-rand, transform.position.y+15f), Quaternion.Euler(0,0, 0));
            barril1.transform.SetParent (boardHolder);
        }

        for (int j = 0; j < Random.Range(1, 4); j++){
            GameObject enemies1 = Instantiate(enemies[Random.Range(0, enemies.Length)], new Vector2 (transform.position.x + Random.Range(2, 20), transform.position.y+ Random.Range(2, 14)), Quaternion.Euler(0,0, 0));
            enemies1.transform.SetParent (boardHolder);
        }
    }
    void roomRESUPPLY(){
        for (int i = 1; i < 8; i++) {
            GameObject bottle1 = Instantiate(bottles[spritesType], new Vector2 (transform.position.x+i, transform.position.y+1.5f), Quaternion.Euler(0,0, 0));
            bottle1.transform.SetParent (boardHolder);
        }

        for (int i = 14; i < 21; i++) {
            GameObject bottle1 = Instantiate(bottles[spritesType], new Vector2 (transform.position.x+i, transform.position.y+15 ), Quaternion.Euler(0,0, 0));
            bottle1.transform.SetParent (boardHolder);
        }

        for (int j = 0; j < 5; j++){
            GameObject box1 = Instantiate(box[spritesType], new Vector2 (transform.position.x + Random.Range(2, 20), transform.position.y+ Random.Range(2, 14)), Quaternion.Euler(0,0, 0));
            box1.transform.SetParent (boardHolder);
        }
    }


    /*void roomBASIC3(){
        GameObject enemy1 = Instantiate(enem[spritesType], new Vector2 (transform.position.x+15, transform.position.y+6f), Quaternion.Euler(0,0, 0));
        enemy1.transform.SetParent (boardHolder);
    }*/
    void roomBASIC2(){
        GameObject table1 = Instantiate(table[spritesType], new Vector2 (transform.position.x+15, transform.position.y+6f), Quaternion.Euler(0,0, 0));
        table1.transform.SetParent (boardHolder);
        GameObject table2 = Instantiate(table[spritesType], new Vector2 (transform.position.x+6, transform.position.y+6f), Quaternion.Euler(0,0, 0));
        table2.transform.SetParent (boardHolder);
        GameObject table3 = Instantiate(table[spritesType], new Vector2 (transform.position.x+6, transform.position.y+12f), Quaternion.Euler(0,0, 0));
        table3.transform.SetParent (boardHolder);
        GameObject table4 = Instantiate(table[spritesType], new Vector2 (transform.position.x+15, transform.position.y+12f), Quaternion.Euler(0,0, 0));
        table4.transform.SetParent (boardHolder);

        GameObject enemy1 = Instantiate(enemies[0], new Vector2 (transform.position.x + 10, transform.position.y + 9), Quaternion.Euler(0,0, 0));
        enemy1.transform.SetParent (boardHolder);
        GameObject enemy2 = Instantiate(enemies[0], new Vector2 (transform.position.x + 3, transform.position.y + 13), Quaternion.Euler(0,0, 0));
        enemy2.transform.SetParent (boardHolder);
        GameObject enemy3 = Instantiate(enemies[0], new Vector2 (transform.position.x + 3, transform.position.y + 2), Quaternion.Euler(0,0, 0));
        enemy3.transform.SetParent (boardHolder);
        GameObject enemy4 = Instantiate(enemies[0], new Vector2 (transform.position.x + 20, transform.position.y + 2), Quaternion.Euler(0,0, 0));
        enemy4.transform.SetParent (boardHolder);
        GameObject enemy5 = Instantiate(enemies[0], new Vector2 (transform.position.x + 20, transform.position.y + 14), Quaternion.Euler(0,0, 0));
        enemy5.transform.SetParent (boardHolder);

		GameObject wallDecor = Instantiate(wallDecorations[spritesType], new Vector2(transform.position.x + Random.Range(3, 8), transform.position.y+18), Quaternion.Euler(0,0, 0));
		wallDecor.transform.SetParent (boardHolder);
    }
    void roomEMPTY(){
        return;
    }
    void roomCHEST(){
        GameObject chest = Instantiate(chests[spritesType], new Vector2 (transform.position.x+11f, transform.position.y+10f), Quaternion.Euler(0,0, 0));
        chest.transform.SetParent (boardHolder);
    }
    void roomBASIC1(){
        // Walls
        for (int i = 15; i < 22; i++) {
            GameObject wall1 = Instantiate(verticalWall[spritesType], new Vector2 (transform.position.x + i, transform.position.y + 12f), Quaternion.Euler(0,0, 0));
            wall1.transform.SetParent (boardHolder);
        }

        for (int j = 1; j < 8; j++) {
            GameObject wall2 = Instantiate(verticalWall[spritesType], new Vector2 (transform.position.x + j, transform.position.y + 12f), Quaternion.Euler(0,0, 0));
            wall2.transform.SetParent (boardHolder);
        }

        for (int k = 15; k < 22; k++) {
            GameObject wall3 = Instantiate(verticalWall[spritesType], new Vector2 (transform.position.x + k, transform.position.y + 6f), Quaternion.Euler(0,0, 0));
            wall3.transform.SetParent (boardHolder);
        }

        for (int z = 1; z < 8; z++) {
            GameObject wall4 = Instantiate(verticalWall[spritesType], new Vector2 (transform.position.x + z, transform.position.y + 6f), Quaternion.Euler(0,0, 0));
            wall4.transform.SetParent (boardHolder);
        }

        GameObject enemy1 = Instantiate(enemies[0], new Vector2 (transform.position.x + 20, transform.position.y + 14), Quaternion.Euler(0,0, 0));
        enemy1.transform.SetParent (boardHolder);
        GameObject enemy2 = Instantiate(enemies[0], new Vector2 (transform.position.x + 3, transform.position.y + 13), Quaternion.Euler(0,0, 0));
        enemy2.transform.SetParent (boardHolder);
        GameObject enemy3 = Instantiate(enemies[0], new Vector2 (transform.position.x + 3, transform.position.y + 2), Quaternion.Euler(0,0, 0));
        enemy3.transform.SetParent (boardHolder);
        GameObject enemy4 = Instantiate(enemies[0], new Vector2 (transform.position.x + 20, transform.position.y + 2), Quaternion.Euler(0,0, 0));
        enemy4.transform.SetParent (boardHolder);

		GameObject wallDecor = Instantiate(wallDecorations[spritesType], new Vector2(transform.position.x + Random.Range(3, 8), transform.position.y+18), Quaternion.Euler(0,0, 0));
		wallDecor.transform.SetParent (boardHolder);
    }

	void roomBASIC3(){// room with the stair-like walls
		// Walls
		for (int t = 7; t > 0 ; t--) {
			for (int z = 22; z > (13+t); z--) {
				GameObject wall4 = Instantiate(verticalWall[spritesType], new Vector2 (transform.position.x + z, transform.position.y + t), Quaternion.Euler(0,0, 0));
				wall4.transform.SetParent (boardHolder);
			}
		}
		for (int t = 7; t > 0 ; t--) {
			for (int z = 1; z < (9-t); z++) {
				GameObject wall4 = Instantiate(verticalWall[spritesType], new Vector2 (transform.position.x + z, transform.position.y + t), Quaternion.Euler(0,0, 0));
				wall4.transform.SetParent (boardHolder);
			}
		}

		GameObject barril1 = Instantiate(barriles[spritesType], new Vector2 (transform.position.x + 2, transform.position.y + 16), Quaternion.Euler(0,0, 0));
		barril1.transform.SetParent (boardHolder);
		GameObject barril2 = Instantiate(barriles[spritesType], new Vector2 (transform.position.x + 4, transform.position.y + 16), Quaternion.Euler(0,0, 0));
		barril2.transform.SetParent (boardHolder);
		GameObject barril3 = Instantiate(barriles[spritesType], new Vector2 (transform.position.x + 3, transform.position.y + 14), Quaternion.Euler(0,0, 0));
		barril3.transform.SetParent (boardHolder);
		GameObject barril4 = Instantiate(barriles[spritesType], new Vector2 (transform.position.x + 20, transform.position.y + 16), Quaternion.Euler(0,0, 0));
		barril4.transform.SetParent (boardHolder);
		GameObject barril5 = Instantiate(barriles[spritesType], new Vector2 (transform.position.x + 18, transform.position.y + 16), Quaternion.Euler(0,0, 0));
		barril5.transform.SetParent (boardHolder);
		GameObject barril6 = Instantiate(barriles[spritesType], new Vector2 (transform.position.x + 19, transform.position.y + 14), Quaternion.Euler(0,0, 0));
		barril6.transform.SetParent (boardHolder);
		GameObject enemy1 = Instantiate(enemies[0], new Vector2 (transform.position.x + 5, transform.position.y + 15), Quaternion.Euler(0,0, 0));
		enemy1.transform.SetParent (boardHolder);
		GameObject enemy2 = Instantiate(enemies[0], new Vector2 (transform.position.x + 17, transform.position.y + 15), Quaternion.Euler(0,0, 0));
		enemy2.transform.SetParent (boardHolder);

		GameObject wallDecor = Instantiate(wallDecorations[spritesType], new Vector2(transform.position.x + Random.Range(3, 8), transform.position.y+18), Quaternion.Euler(0,0, 0));
		wallDecor.transform.SetParent (boardHolder);

	}

	void roomBASIC4(){// room with the cross in the middle
		// Walls
		for (int i = 8; i < 15; i++) {
			GameObject wall1 = Instantiate(verticalWall[spritesType], new Vector2 (transform.position.x + i, transform.position.y + 8), Quaternion.Euler(0,0, 0));
			wall1.transform.SetParent (boardHolder);
		}

		for (int i = 5; i < 12; i++) {
			GameObject wall1 = Instantiate(verticalWall[spritesType], new Vector2 (transform.position.x + 11, transform.position.y + i), Quaternion.Euler(0,0, 0));
			wall1.transform.SetParent (boardHolder);
		}


		GameObject barril1 = Instantiate(barriles[spritesType], new Vector2 (transform.position.x + 1, transform.position.y + 16), Quaternion.Euler(0,0, 0));
		barril1.transform.SetParent (boardHolder);
		GameObject barril2 = Instantiate(barriles[spritesType], new Vector2 (transform.position.x + 21, transform.position.y + 1), Quaternion.Euler(0,0, 0));
		barril2.transform.SetParent (boardHolder);
		GameObject enemy1 = Instantiate(enemies[0], new Vector2 (transform.position.x + 9, transform.position.y + 7), Quaternion.Euler(0,0, 0));
		enemy1.transform.SetParent (boardHolder);
		GameObject enemy2 = Instantiate(enemies[0], new Vector2 (transform.position.x + 12, transform.position.y + 9), Quaternion.Euler(0,0, 0));
		enemy2.transform.SetParent (boardHolder);
		GameObject box1 = Instantiate(boxes[spritesType], new Vector2 (transform.position.x + 9, transform.position.y + 9), Quaternion.Euler(0,0, 0));
		box1.transform.SetParent (boardHolder);
		GameObject bottle1 = Instantiate(bottles[spritesType], new Vector2 (transform.position.x + 12, transform.position.y + 7), Quaternion.Euler(0,0, 0));
		bottle1.transform.SetParent (boardHolder);

		GameObject wallDecor = Instantiate(wallDecorations[spritesType], new Vector2(transform.position.x + Random.Range(3, 8), transform.position.y+18), Quaternion.Euler(0,0, 0));
		wallDecor.transform.SetParent (boardHolder);

	}

	void roomBASIC5(){ //Room with 1 enemy in each corner
		for (int i = 1; i < 5; i++) {
			GameObject wall1 = Instantiate(verticalWall[spritesType], new Vector2 (transform.position.x + i, transform.position.y + 7), Quaternion.Euler(0,0, 0));
			wall1.transform.SetParent (boardHolder);
		}
		for (int i = 1; i < 5; i++) {
			GameObject wall1 = Instantiate(verticalWall[spritesType], new Vector2 (transform.position.x + i, transform.position.y + 11), Quaternion.Euler(0,0, 0));
			wall1.transform.SetParent (boardHolder);
		}
		for (int i = 18; i < 22; i++) {
			GameObject wall1 = Instantiate(verticalWall[spritesType], new Vector2 (transform.position.x + i, transform.position.y + 7), Quaternion.Euler(0,0, 0));
			wall1.transform.SetParent (boardHolder);
		}
		for (int i = 18; i < 22; i++) {
			GameObject wall1 = Instantiate(verticalWall[spritesType], new Vector2 (transform.position.x + i, transform.position.y + 11), Quaternion.Euler(0,0, 0));
			wall1.transform.SetParent (boardHolder);
		}
		for (int j = 1; j < 6; j++) {
			GameObject wall1 = Instantiate(verticalWall[spritesType], new Vector2 (transform.position.x + 9, transform.position.y + j), Quaternion.Euler(0,0, 0));
			wall1.transform.SetParent (boardHolder);
		}
		for (int j = 1; j < 6; j++) {
			GameObject wall1 = Instantiate(verticalWall[spritesType], new Vector2 (transform.position.x + 13, transform.position.y + j), Quaternion.Euler(0,0, 0));
			wall1.transform.SetParent (boardHolder);
		}
		for (int j = 11; j < 16; j++) {
			GameObject wall1 = Instantiate(verticalWall[spritesType], new Vector2 (transform.position.x + 9, transform.position.y + j), Quaternion.Euler(0,0, 0));
			wall1.transform.SetParent (boardHolder);
		}
		for (int j = 11; j < 16; j++) {
			GameObject wall1 = Instantiate(verticalWall[spritesType], new Vector2 (transform.position.x + 13, transform.position.y + j), Quaternion.Euler(0,0, 0));
			wall1.transform.SetParent (boardHolder);
		}
		GameObject enemy1 = Instantiate(enemies[0], new Vector2 (transform.position.x + 8, transform.position.y + 1), Quaternion.Euler(0,0, 0));
		enemy1.transform.SetParent (boardHolder);
		GameObject enemy2 = Instantiate(enemies[0], new Vector2 (transform.position.x + 14, transform.position.y + 1), Quaternion.Euler(0,0, 0));
		enemy2.transform.SetParent (boardHolder);
		GameObject enemy3 = Instantiate(enemies[0], new Vector2 (transform.position.x + 8, transform.position.y + 16), Quaternion.Euler(0,0, 0));
		enemy3.transform.SetParent (boardHolder);
		GameObject enemy4 = Instantiate(enemies[0], new Vector2 (transform.position.x + 14, transform.position.y + 16), Quaternion.Euler(0,0, 0));
		enemy4.transform.SetParent (boardHolder);
		GameObject barril1 = Instantiate(barriles[spritesType], new Vector2 (transform.position.x + 1, transform.position.y + 1), Quaternion.Euler(0,0, 0));
		barril1.transform.SetParent (boardHolder);
		GameObject barril2 = Instantiate(barriles[spritesType], new Vector2 (transform.position.x + 21, transform.position.y + 16), Quaternion.Euler(0,0, 0));
		barril2.transform.SetParent (boardHolder);
		GameObject box1 = Instantiate(boxes[spritesType], new Vector2 (transform.position.x + 1, transform.position.y + 15), Quaternion.Euler(0,0, 0));
		box1.transform.SetParent (boardHolder);
		GameObject bottle1 = Instantiate(bottles[spritesType], new Vector2 (transform.position.x + 21, transform.position.y + 1), Quaternion.Euler(0,0, 0));
		bottle1.transform.SetParent (boardHolder);

		GameObject wallDecor = Instantiate(wallDecorations[spritesType], new Vector2(transform.position.x + Random.Range(3, 8), transform.position.y+18), Quaternion.Euler(0,0, 0));
		wallDecor.transform.SetParent (boardHolder);

	}

	void roomBASIC6(){ // weapon in the middle
		GameObject wall1 = Instantiate(verticalWall[spritesType], new Vector2 (transform.position.x + 9, transform.position.y + 7), Quaternion.Euler(0,0, 0));
		wall1.transform.SetParent (boardHolder);
		GameObject wall2 = Instantiate(verticalWall[spritesType], new Vector2 (transform.position.x + 13, transform.position.y + 7), Quaternion.Euler(0,0, 0));
		wall2.transform.SetParent (boardHolder);
		GameObject wall3 = Instantiate(verticalWall[spritesType], new Vector2 (transform.position.x + 9, transform.position.y + 11), Quaternion.Euler(0,0, 0));
		wall3.transform.SetParent (boardHolder);
		GameObject wall4 = Instantiate(verticalWall[spritesType], new Vector2 (transform.position.x + 13, transform.position.y + 11), Quaternion.Euler(0,0, 0));
		wall4.transform.SetParent (boardHolder);

		GameObject box1 = Instantiate(weapon[0], new Vector2 (transform.position.x + 11, transform.position.y + 9), Quaternion.Euler(0,0, 0));
		box1.transform.SetParent (boardHolder);
		GameObject barril1 = Instantiate(barriles[spritesType], new Vector2 (transform.position.x + 11, transform.position.y + 7), Quaternion.Euler(0,0, 0));
		barril1.transform.SetParent (boardHolder);
		GameObject barril2 = Instantiate(barriles[spritesType], new Vector2 (transform.position.x + 11, transform.position.y + 11), Quaternion.Euler(0,0, 0));
		barril2.transform.SetParent (boardHolder);
		GameObject barril3 = Instantiate(barriles[spritesType], new Vector2 (transform.position.x + 9, transform.position.y + 9), Quaternion.Euler(0,0, 0));
		barril3.transform.SetParent (boardHolder);
		GameObject barril4 = Instantiate(barriles[spritesType], new Vector2 (transform.position.x + 13, transform.position.y + 9), Quaternion.Euler(0,0, 0));
		barril4.transform.SetParent (boardHolder);

		GameObject box2 = Instantiate(box[spritesType], new Vector2 (transform.position.x + 20, transform.position.y + 15), Quaternion.Euler(0,0, 0));
		box2.transform.SetParent (boardHolder);
		GameObject box3 = Instantiate(box[spritesType], new Vector2 (transform.position.x + 18, transform.position.y + 15), Quaternion.Euler(0,0, 0));
		box3.transform.SetParent (boardHolder);
		GameObject box4 = Instantiate(boxes[spritesType], new Vector2 (transform.position.x + 19, transform.position.y + 13), Quaternion.Euler(0,0, 0));
		box4.transform.SetParent (boardHolder);

		GameObject wallDecor = Instantiate(wallDecorations[spritesType], new Vector2(transform.position.x + Random.Range(3, 8), transform.position.y+18), Quaternion.Euler(0,0, 0));
		wallDecor.transform.SetParent (boardHolder);
	}

	void roomBASIC7(){ //Room with like double walls
		for (int i = 1; i < 10; i++) {
			GameObject wall1 = Instantiate(verticalWall[spritesType], new Vector2 (transform.position.x + i, transform.position.y + 1), Quaternion.Euler(0,0, 0));
			wall1.transform.SetParent (boardHolder);
		}
		for (int i = 13; i < 23; i++) {
			GameObject wall1 = Instantiate(verticalWall[spritesType], new Vector2 (transform.position.x + i, transform.position.y + 1), Quaternion.Euler(0,0, 0));
			wall1.transform.SetParent (boardHolder);
		}
		for (int i = 1; i < 10; i++) {
			GameObject wall1 = Instantiate(verticalWall[spritesType], new Vector2 (transform.position.x + i, transform.position.y + 15), Quaternion.Euler(0,0, 0));
			wall1.transform.SetParent (boardHolder);
		}
		for (int i = 13; i < 23; i++) {
			GameObject wall1 = Instantiate(verticalWall[spritesType], new Vector2 (transform.position.x + i, transform.position.y + 15), Quaternion.Euler(0,0, 0));
			wall1.transform.SetParent (boardHolder);
		}
		for (int j = 2; j < 8; j++) {
			GameObject wall1 = Instantiate(verticalWall[spritesType], new Vector2 (transform.position.x + 1, transform.position.y + j), Quaternion.Euler(0,0, 0));
			wall1.transform.SetParent (boardHolder);
		}
		for (int j = 11; j < 15; j++) {
			GameObject wall1 = Instantiate(verticalWall[spritesType], new Vector2 (transform.position.x + 1, transform.position.y + j), Quaternion.Euler(0,0, 0));
			wall1.transform.SetParent (boardHolder);
		}
		for (int j = 2; j < 8; j++) {
			GameObject wall1 = Instantiate(verticalWall[spritesType], new Vector2 (transform.position.x + 21, transform.position.y + j), Quaternion.Euler(0,0, 0));
			wall1.transform.SetParent (boardHolder);
		}
		for (int j = 11; j < 15; j++) {
			GameObject wall1 = Instantiate(verticalWall[spritesType], new Vector2 (transform.position.x + 21, transform.position.y + j), Quaternion.Euler(0,0, 0));
			wall1.transform.SetParent (boardHolder);
		}
		GameObject wall2 = Instantiate(verticalWall[spritesType], new Vector2 (transform.position.x + 8, transform.position.y + 6), Quaternion.Euler(0,0, 0));
		wall2.transform.SetParent (boardHolder);
		GameObject wall3 = Instantiate(verticalWall[spritesType], new Vector2 (transform.position.x + 8, transform.position.y + 11), Quaternion.Euler(0,0, 0));
		wall3.transform.SetParent (boardHolder);
		GameObject wall4 = Instantiate(verticalWall[spritesType], new Vector2 (transform.position.x + 14, transform.position.y + 6), Quaternion.Euler(0,0, 0));
		wall4.transform.SetParent (boardHolder);
		GameObject wall5 = Instantiate(verticalWall[spritesType], new Vector2 (transform.position.x + 14, transform.position.y + 11), Quaternion.Euler(0,0, 0));
		wall5.transform.SetParent (boardHolder);

		GameObject enemy1 = Instantiate(enemies[0], new Vector2 (transform.position.x + 2, transform.position.y + 2), Quaternion.Euler(0,0, 0));
		enemy1.transform.SetParent (boardHolder);
		GameObject enemy2 = Instantiate(enemies[0], new Vector2 (transform.position.x + 20, transform.position.y + 2), Quaternion.Euler(0,0, 0));
		enemy2.transform.SetParent (boardHolder);
		GameObject enemy3 = Instantiate(enemies[0], new Vector2 (transform.position.x + 2, transform.position.y + 14), Quaternion.Euler(0,0, 0));
		enemy3.transform.SetParent (boardHolder);
		GameObject enemy4 = Instantiate(enemies[0], new Vector2 (transform.position.x + 20, transform.position.y + 14), Quaternion.Euler(0,0, 0));
		enemy4.transform.SetParent (boardHolder);

		GameObject box1 = Instantiate(box[spritesType], new Vector2 (transform.position.x + 11, transform.position.y + 9), Quaternion.Euler(0,0, 0));
		box1.transform.SetParent (boardHolder);

		GameObject wallDecor = Instantiate(wallDecorations[spritesType], new Vector2(transform.position.x + Random.Range(3, 8), transform.position.y+18), Quaternion.Euler(0,0, 0));
		wallDecor.transform.SetParent (boardHolder);
	}

	void roomBASIC8(){ //el que parece un pequeño laberinto
		for (int i = 10; i < 13; i++) {
			GameObject wall1 = Instantiate(verticalWall[spritesType], new Vector2 (transform.position.x + i, transform.position.y + 4), Quaternion.Euler(0,0, 0));
			wall1.transform.SetParent (boardHolder);
		}
		for (int i = 6; i < 9; i++) {
			GameObject wall1 = Instantiate(verticalWall[spritesType], new Vector2 (transform.position.x + i, transform.position.y + 12), Quaternion.Euler(0,0, 0));
			wall1.transform.SetParent (boardHolder);
		}
		for (int i = 14; i < 17; i++) {
			GameObject wall1 = Instantiate(verticalWall[spritesType], new Vector2 (transform.position.x + i, transform.position.y + 12), Quaternion.Euler(0,0, 0));
			wall1.transform.SetParent (boardHolder);
		}
		for (int j = 4; j < 13; j++) {
			GameObject wall1 = Instantiate(verticalWall[spritesType], new Vector2 (transform.position.x + 5, transform.position.y + j), Quaternion.Euler(0,0, 0));
			wall1.transform.SetParent (boardHolder);
		}
		for (int j = 4; j < 13; j++) {
			GameObject wall1 = Instantiate(verticalWall[spritesType], new Vector2 (transform.position.x + 9, transform.position.y + j), Quaternion.Euler(0,0, 0));
			wall1.transform.SetParent (boardHolder);
		}
		for (int j = 4; j < 13; j++) {
			GameObject wall1 = Instantiate(verticalWall[spritesType], new Vector2 (transform.position.x + 13, transform.position.y + j), Quaternion.Euler(0,0, 0));
			wall1.transform.SetParent (boardHolder);
		}
		for (int j = 4; j < 13; j++) {
			GameObject wall1 = Instantiate(verticalWall[spritesType], new Vector2 (transform.position.x + 17, transform.position.y + j), Quaternion.Euler(0,0, 0));
			wall1.transform.SetParent (boardHolder);
		}

		GameObject barril1 = Instantiate(barriles[spritesType], new Vector2 (transform.position.x + 7, transform.position.y + 5), Quaternion.Euler(0,0, 0));
		barril1.transform.SetParent (boardHolder);
		GameObject barril2 = Instantiate(barriles[spritesType], new Vector2 (transform.position.x + 15, transform.position.y + 5), Quaternion.Euler(0,0, 0));
		barril2.transform.SetParent (boardHolder);
		GameObject barril3 = Instantiate(barriles[spritesType], new Vector2 (transform.position.x + 11, transform.position.y + 11), Quaternion.Euler(0,0, 0));
		barril3.transform.SetParent (boardHolder);

		GameObject bottle1 = Instantiate(bottles[spritesType], new Vector2 (transform.position.x + 11, transform.position.y + 5), Quaternion.Euler(0,0, 0));
		bottle1.transform.SetParent (boardHolder);
		GameObject bottle2 = Instantiate(bottles[spritesType], new Vector2 (transform.position.x + 7, transform.position.y + 11), Quaternion.Euler(0,0, 0));
		bottle2.transform.SetParent (boardHolder);
		GameObject bottle3 = Instantiate(bottles[spritesType], new Vector2 (transform.position.x + 15, transform.position.y + 11), Quaternion.Euler(0,0, 0));
		bottle3.transform.SetParent (boardHolder);

		GameObject wallDecor = Instantiate(wallDecorations[spritesType], new Vector2(transform.position.x + Random.Range(3, 8), transform.position.y+18), Quaternion.Euler(0,0, 0));
		wallDecor.transform.SetParent (boardHolder);
	}

	void roomBASIC9(){ // Donde parece que hay rocas en las esquinas y centro
		//Las de las esquinas
		for (int i = 1; i < 3; i++) {
			GameObject wall1 = Instantiate(verticalWall[spritesType], new Vector2 (transform.position.x + i, transform.position.y + 1), Quaternion.Euler(0,0, 0));
			wall1.transform.SetParent (boardHolder);
		}
		for (int i = 1; i < 3; i++) {
			GameObject wall1 = Instantiate(verticalWall[spritesType], new Vector2 (transform.position.x + i, transform.position.y + 2), Quaternion.Euler(0,0, 0));
			wall1.transform.SetParent (boardHolder);
		}
		for (int i = 1; i < 3; i++) {
			GameObject wall1 = Instantiate(verticalWall[spritesType], new Vector2 (transform.position.x + i, transform.position.y + 14), Quaternion.Euler(0,0, 0));
			wall1.transform.SetParent (boardHolder);
		}
		for (int i = 1; i < 3; i++) {
			GameObject wall1 = Instantiate(verticalWall[spritesType], new Vector2 (transform.position.x + i, transform.position.y + 15), Quaternion.Euler(0,0, 0));
			wall1.transform.SetParent (boardHolder);
		}
		for (int i = 20; i < 22; i++) {
			GameObject wall1 = Instantiate(verticalWall[spritesType], new Vector2 (transform.position.x + i, transform.position.y + 1), Quaternion.Euler(0,0, 0));
			wall1.transform.SetParent (boardHolder);
		}
		for (int i = 20; i < 22; i++) {
			GameObject wall1 = Instantiate(verticalWall[spritesType], new Vector2 (transform.position.x + i, transform.position.y + 2), Quaternion.Euler(0,0, 0));
			wall1.transform.SetParent (boardHolder);
		}
		for (int i = 20; i < 22; i++) {
			GameObject wall1 = Instantiate(verticalWall[spritesType], new Vector2 (transform.position.x + i, transform.position.y + 14), Quaternion.Euler(0,0, 0));
			wall1.transform.SetParent (boardHolder);
		}
		for (int i = 20; i < 22; i++) {
			GameObject wall1 = Instantiate(verticalWall[spritesType], new Vector2 (transform.position.x + i, transform.position.y + 15), Quaternion.Euler(0,0, 0));
			wall1.transform.SetParent (boardHolder);
		}
		//Las del centro
		for (int i = 7; i < 9; i++) {
			GameObject wall1 = Instantiate(verticalWall[spritesType], new Vector2 (transform.position.x + i, transform.position.y + 4), Quaternion.Euler(0,0, 0));
			wall1.transform.SetParent (boardHolder);
		}
		for (int i = 7; i < 9; i++) {
			GameObject wall1 = Instantiate(verticalWall[spritesType], new Vector2 (transform.position.x + i, transform.position.y + 5), Quaternion.Euler(0,0, 0));
			wall1.transform.SetParent (boardHolder);
		}
		for (int i = 7; i < 9; i++) {
			GameObject wall1 = Instantiate(verticalWall[spritesType], new Vector2 (transform.position.x + i, transform.position.y + 11), Quaternion.Euler(0,0, 0));
			wall1.transform.SetParent (boardHolder);
		}
		for (int i = 7; i < 9; i++) {
			GameObject wall1 = Instantiate(verticalWall[spritesType], new Vector2 (transform.position.x + i, transform.position.y + 12), Quaternion.Euler(0,0, 0));
			wall1.transform.SetParent (boardHolder);
		}
		for (int i = 14; i < 16; i++) {
			GameObject wall1 = Instantiate(verticalWall[spritesType], new Vector2 (transform.position.x + i, transform.position.y + 4), Quaternion.Euler(0,0, 0));
			wall1.transform.SetParent (boardHolder);
		}
		for (int i = 14; i < 16; i++) {
			GameObject wall1 = Instantiate(verticalWall[spritesType], new Vector2 (transform.position.x + i, transform.position.y + 5), Quaternion.Euler(0,0, 0));
			wall1.transform.SetParent (boardHolder);
		}
		for (int i = 14; i < 16; i++) {
			GameObject wall1 = Instantiate(verticalWall[spritesType], new Vector2 (transform.position.x + i, transform.position.y + 11), Quaternion.Euler(0,0, 0));
			wall1.transform.SetParent (boardHolder);
		}
		for (int i = 14; i < 16; i++) {
			GameObject wall1 = Instantiate(verticalWall[spritesType], new Vector2 (transform.position.x + i, transform.position.y + 12), Quaternion.Euler(0,0, 0));
			wall1.transform.SetParent (boardHolder);
		}
		GameObject enemy1 = Instantiate(enemies[0], new Vector2 (transform.position.x + 11, transform.position.y + 8), Quaternion.Euler(0,0, 0));
		enemy1.transform.SetParent (boardHolder);
		GameObject enemy2 = Instantiate(enemies[0], new Vector2 (transform.position.x + 8, transform.position.y + 8), Quaternion.Euler(0,0, 0));
		enemy2.transform.SetParent (boardHolder);
		GameObject enemy3 = Instantiate(enemies[0], new Vector2 (transform.position.x + 14, transform.position.y + 8), Quaternion.Euler(0,0, 0));
		enemy3.transform.SetParent (boardHolder);

		GameObject box1 = Instantiate(boxes[spritesType], new Vector2 (transform.position.x + 18, transform.position.y + 15), Quaternion.Euler(0,0, 0));
		box1.transform.SetParent (boardHolder);
		GameObject box2 = Instantiate(box[spritesType], new Vector2 (transform.position.x + 3, transform.position.y + 15), Quaternion.Euler(0,0, 0));
		box2.transform.SetParent (boardHolder);
		GameObject box3 = Instantiate(boxes[spritesType], new Vector2 (transform.position.x + 3, transform.position.y + 1), Quaternion.Euler(0,0, 0));
		box3.transform.SetParent (boardHolder);
		GameObject box4 = Instantiate(box[spritesType], new Vector2 (transform.position.x + 18, transform.position.y + 1), Quaternion.Euler(0,0, 0));
		box4.transform.SetParent (boardHolder);

		GameObject wallDecor = Instantiate(wallDecorations[spritesType], new Vector2(transform.position.x + Random.Range(3, 8), transform.position.y+18), Quaternion.Euler(0,0, 0));
		wallDecor.transform.SetParent (boardHolder);
	}

	void roomBASIC10(){ //has double walls and stair-like walls
		for (int i = 1; i < 10; i++) {
			GameObject wall1 = Instantiate(verticalWall[spritesType], new Vector2 (transform.position.x + i, transform.position.y + 1), Quaternion.Euler(0,0, 0));
			wall1.transform.SetParent (boardHolder);
		}
		for (int i = 13; i < 23; i++) {
			GameObject wall1 = Instantiate(verticalWall[spritesType], new Vector2 (transform.position.x + i, transform.position.y + 15), Quaternion.Euler(0,0, 0));
			wall1.transform.SetParent (boardHolder);
		}
		for (int j = 2; j < 8; j++) {
			GameObject wall1 = Instantiate(verticalWall[spritesType], new Vector2 (transform.position.x + 1, transform.position.y + j), Quaternion.Euler(0,0, 0));
			wall1.transform.SetParent (boardHolder);
		}
		for (int j = 11; j < 15; j++) {
			GameObject wall1 = Instantiate(verticalWall[spritesType], new Vector2 (transform.position.x + 21, transform.position.y + j), Quaternion.Euler(0,0, 0));
			wall1.transform.SetParent (boardHolder);
		}
		for (int t = 7; t > 0 ; t--) {
			for (int z = 22; z > (13+t); z--) {
				GameObject wall4 = Instantiate(verticalWall[spritesType], new Vector2 (transform.position.x + z, transform.position.y + t), Quaternion.Euler(0,0, 0));
				wall4.transform.SetParent (boardHolder);
			}
		}
		for (int t = 15; t > 0 ; t--) {
			for (int z = 1; z < (t-9); z++) {
				GameObject wall4 = Instantiate(verticalWall[spritesType], new Vector2 (transform.position.x + z, transform.position.y + t), Quaternion.Euler(0,0, 0));
				wall4.transform.SetParent (boardHolder);
			}
		}

		GameObject barril1 = Instantiate(barriles[spritesType], new Vector2 (transform.position.x + 13, transform.position.y + 1), Quaternion.Euler(0,0, 0));
		barril1.transform.SetParent (boardHolder);
		GameObject enemy1 = Instantiate(enemies[0], new Vector2 (transform.position.x + 2, transform.position.y + 2), Quaternion.Euler(0,0, 0));
		enemy1.transform.SetParent (boardHolder);
		GameObject enemy2 = Instantiate(enemies[0], new Vector2 (transform.position.x + 19, transform.position.y + 14), Quaternion.Euler(0,0, 0));
		enemy2.transform.SetParent (boardHolder);
		GameObject box1 = Instantiate(box[spritesType], new Vector2 (transform.position.x + 8, transform.position.y + 15), Quaternion.Euler(0,0, 0));
		box1.transform.SetParent (boardHolder);

		GameObject wallDecor = Instantiate(wallDecorations[spritesType], new Vector2(transform.position.x + Random.Range(3, 8), transform.position.y+18), Quaternion.Euler(0,0, 0));
		wallDecor.transform.SetParent (boardHolder);
	}

	void roomBASIC11(){// El que es como un rectangulo
		for (int i = 6; i < 17; i++) {
			GameObject wall1 = Instantiate(verticalWall[spritesType], new Vector2 (transform.position.x + i, transform.position.y + 12), Quaternion.Euler(0,0, 0));
			wall1.transform.SetParent (boardHolder);
		}
		for (int i = 6; i < 9; i++) {
			GameObject wall1 = Instantiate(verticalWall[spritesType], new Vector2 (transform.position.x + i, transform.position.y + 5), Quaternion.Euler(0,0, 0));
			wall1.transform.SetParent (boardHolder);
		}
		for (int i = 14; i < 17; i++) {
			GameObject wall1 = Instantiate(verticalWall[spritesType], new Vector2 (transform.position.x + i, transform.position.y + 5), Quaternion.Euler(0,0, 0));
			wall1.transform.SetParent (boardHolder);
		}
		for (int i = 5; i < 13; i++) {
			GameObject wall1 = Instantiate(verticalWall[spritesType], new Vector2 (transform.position.x + 5, transform.position.y + i), Quaternion.Euler(0,0, 0));
			wall1.transform.SetParent (boardHolder);
		}
		for (int i = 5; i < 13; i++) {
			GameObject wall1 = Instantiate(verticalWall[spritesType], new Vector2 (transform.position.x + 17, transform.position.y + i), Quaternion.Euler(0,0, 0));
			wall1.transform.SetParent (boardHolder);
		}

		GameObject barril1 = Instantiate(barriles[spritesType], new Vector2 (transform.position.x + 9, transform.position.y + 5), Quaternion.Euler(0,0, 0));
		barril1.transform.SetParent (boardHolder);
		GameObject barril2 = Instantiate(barriles[spritesType], new Vector2 (transform.position.x + 13, transform.position.y + 5), Quaternion.Euler(0,0, 0));
		barril2.transform.SetParent (boardHolder);
		GameObject barril3 = Instantiate(barriles[spritesType], new Vector2 (transform.position.x + 11, transform.position.y + 5), Quaternion.Euler(0,0, 0));
		barril3.transform.SetParent (boardHolder);

		GameObject box1 = Instantiate(weapon[0], new Vector2 (transform.position.x + 11, transform.position.y + 8), Quaternion.Euler(0,0, 0));
		box1.transform.SetParent (boardHolder);

		GameObject box2 = Instantiate(box[spritesType], new Vector2 (transform.position.x + 20, transform.position.y + 15), Quaternion.Euler(0,0, 0));
		box2.transform.SetParent (boardHolder);
		GameObject box3 = Instantiate(boxes[spritesType], new Vector2 (transform.position.x + 2, transform.position.y + 2), Quaternion.Euler(0,0, 0));
		box3.transform.SetParent (boardHolder);


		GameObject enemy1 = Instantiate(enemies[0], new Vector2 (transform.position.x + 7, transform.position.y + 6), Quaternion.Euler(0,0, 0));
		enemy1.transform.SetParent (boardHolder);
		GameObject enemy2 = Instantiate(enemies[0], new Vector2 (transform.position.x + 16, transform.position.y + 6), Quaternion.Euler(0,0, 0));
		enemy2.transform.SetParent (boardHolder);
		GameObject enemy3 = Instantiate(enemies[0], new Vector2 (transform.position.x + 11, transform.position.y + 11), Quaternion.Euler(0,0, 0));
		enemy3.transform.SetParent (boardHolder);

		GameObject wallDecor = Instantiate(wallDecorations[spritesType], new Vector2(transform.position.x + Random.Range(3, 8), transform.position.y+18), Quaternion.Euler(0,0, 0));
		wallDecor.transform.SetParent (boardHolder);
	}

	void roomBASIC12(){ //Wall with three cubes
		for (int i = 4; i < 7; i++) {
			GameObject wall1 = Instantiate(verticalWall[spritesType], new Vector2 (transform.position.x + i, transform.position.y + 12), Quaternion.Euler(0,0, 0));
			wall1.transform.SetParent (boardHolder);
		}
		GameObject wall2 = Instantiate(verticalWall[spritesType], new Vector2 (transform.position.x + 4, transform.position.y + 11), Quaternion.Euler(0,0, 0));
		wall2.transform.SetParent (boardHolder);
		GameObject wall3 = Instantiate(verticalWall[spritesType], new Vector2 (transform.position.x + 6, transform.position.y + 11), Quaternion.Euler(0,0, 0));
		wall3.transform.SetParent (boardHolder);
		for (int i = 4; i < 7; i++) {
			GameObject wall1 = Instantiate(verticalWall[spritesType], new Vector2 (transform.position.x + i, transform.position.y + 10), Quaternion.Euler(0,0, 0));
			wall1.transform.SetParent (boardHolder);
		}

		for (int i = 10; i < 13; i++) {
			GameObject wall1 = Instantiate(verticalWall[spritesType], new Vector2 (transform.position.x + i, transform.position.y + 9), Quaternion.Euler(0,0, 0));
			wall1.transform.SetParent (boardHolder);
		}
		GameObject wall4 = Instantiate(verticalWall[spritesType], new Vector2 (transform.position.x + 10, transform.position.y + 8), Quaternion.Euler(0,0, 0));
		wall4.transform.SetParent (boardHolder);
		GameObject wall5 = Instantiate(verticalWall[spritesType], new Vector2 (transform.position.x + 12, transform.position.y + 8), Quaternion.Euler(0,0, 0));
		wall5.transform.SetParent (boardHolder);
		for (int i = 10; i < 13; i++) {
			GameObject wall1 = Instantiate(verticalWall[spritesType], new Vector2 (transform.position.x + i, transform.position.y + 7), Quaternion.Euler(0,0, 0));
			wall1.transform.SetParent (boardHolder);
		}

		for (int i = 16; i < 19; i++) {
			GameObject wall1 = Instantiate(verticalWall[spritesType], new Vector2 (transform.position.x + i, transform.position.y + 6), Quaternion.Euler(0,0, 0));
			wall1.transform.SetParent (boardHolder);
		}
		GameObject wall6 = Instantiate(verticalWall[spritesType], new Vector2 (transform.position.x + 16, transform.position.y + 5), Quaternion.Euler(0,0, 0));
		wall6.transform.SetParent (boardHolder);
		GameObject wall7 = Instantiate(verticalWall[spritesType], new Vector2 (transform.position.x + 18, transform.position.y + 5), Quaternion.Euler(0,0, 0));
		wall7.transform.SetParent (boardHolder);
		for (int i = 16; i < 19; i++) {
			GameObject wall1 = Instantiate(verticalWall[spritesType], new Vector2 (transform.position.x + i, transform.position.y + 4), Quaternion.Euler(0,0, 0));
			wall1.transform.SetParent (boardHolder);
		}

		GameObject barril1 = Instantiate(barriles[spritesType], new Vector2 (transform.position.x + 5, transform.position.y + 5), Quaternion.Euler(0,0, 0));
		barril1.transform.SetParent (boardHolder);
		GameObject barril2 = Instantiate(barriles[spritesType], new Vector2 (transform.position.x + 4, transform.position.y + 3), Quaternion.Euler(0,0, 0));
		barril2.transform.SetParent (boardHolder);
		GameObject barril3 = Instantiate(barriles[spritesType], new Vector2 (transform.position.x + 6, transform.position.y + 3), Quaternion.Euler(0,0, 0));
		barril3.transform.SetParent (boardHolder);

		GameObject barril4 = Instantiate(barriles[spritesType], new Vector2 (transform.position.x + 17, transform.position.y + 13), Quaternion.Euler(0,0, 0));
		barril4.transform.SetParent (boardHolder);
		GameObject barril5 = Instantiate(barriles[spritesType], new Vector2 (transform.position.x + 16, transform.position.y + 11), Quaternion.Euler(0,0, 0));
		barril5.transform.SetParent (boardHolder);
		GameObject barril6 = Instantiate(barriles[spritesType], new Vector2 (transform.position.x + 18, transform.position.y + 11), Quaternion.Euler(0,0, 0));
		barril6.transform.SetParent (boardHolder);

		GameObject box1 = Instantiate(boxes[spritesType], new Vector2 (transform.position.x + 20, transform.position.y + 1), Quaternion.Euler(0,0, 0));
		box1.transform.SetParent (boardHolder);

		GameObject enemy1 = Instantiate(enemies[0], new Vector2 (transform.position.x + 8, transform.position.y + 8), Quaternion.Euler(0,0, 0));
		enemy1.transform.SetParent (boardHolder);
		GameObject enemy2 = Instantiate(enemies[0], new Vector2 (transform.position.x + 14, transform.position.y + 8), Quaternion.Euler(0,0, 0));
		enemy2.transform.SetParent (boardHolder);

		GameObject wallDecor = Instantiate(wallDecorations[spritesType], new Vector2(transform.position.x + Random.Range(3, 8), transform.position.y+18), Quaternion.Euler(0,0, 0));
		wallDecor.transform.SetParent (boardHolder);
	}

    void InstantiateArrows(){
        if (UP){

            GameObject arrow1 = Instantiate(arrowUP, new Vector2 (transform.position.x+11.12f, transform.position.y+14.82f), Quaternion.Euler(0,0,-90));
            arrow1.transform.SetParent (boardHolder);
        }
        if (DOWN){
            GameObject arrow2 = Instantiate(arrowDOWN, new Vector2 (transform.position.x+10.97f,transform.position.y+1.13f), Quaternion.Euler(0,0,90));
            arrow2.transform.SetParent (boardHolder);
        }
        if (LEFT){
            GameObject arrow3 = Instantiate(arrowLEFT, new Vector2 (transform.position.x + 1.12f,transform.position.y+9.05f), Quaternion.Euler(0,0,0));
            arrow3.transform.SetParent (boardHolder);
        }
        if (RIGHT){
            GameObject arrow4 = Instantiate(arrowRIGHT, new Vector2 (transform.position.x+ 20.86f,transform.position.y+9.03f ), Quaternion.Euler(0,0,180));
            arrow4.transform.SetParent (boardHolder);
        }
    }
    void UDRL(){
        boardHolder = new GameObject ("Board").transform;

        for (int i = 0; i < columns; i++){
            for (int j = 0; j < rows; j++){

                GameObject toInstantiate = floorTiles [spritesType];

                if(i == 0 || i == columns - 1){
                    if(j == 9){
                        toInstantiate = floorTiles [spritesType];
                    }else{
                        toInstantiate = verticalWall [spritesType];
                    }

                }else if (j == 0 || j == rows - 1 ){
                    if (j == 0 && i == 11){
                        toInstantiate = floorTiles [spritesType];
                    }else{
                        toInstantiate = horizontalWall [spritesType];
                    }

                }
                else if((j == rows - 2 && i > 0 && i < columns - 1) || (j == rows - 3 && i > 0 && i < columns - 1) || (j == rows - 4 && i > 0 && i < columns - 1) || (j == rows - 5 && i > 0 && i < columns - 1)){
                    toInstantiate = wallInPerspective [spritesType];
                }
                else{
                    toInstantiate = floorTiles [spritesType];
                }

				GameObject instance = (GameObject)Instantiate (toInstantiate, new Vector3 (transform.position.x + i, transform.position.y + j, 0f), Quaternion.identity) as GameObject;
				instance.transform.SetParent (boardHolder);


            }
        }


        //Instantiate (player, new Vector2(transform.position.x, transform.position.y), Quaternion.identity);
        GameObject doorInstance = Instantiate (door[spritesType], new Vector2(transform.position.x + 11.04f, transform.position.y + 16.97f), Quaternion.identity);
        doorInstance.transform.SetParent (boardHolder);
    }

    void UDR(){
        boardHolder = new GameObject ("Board").transform;

        for (int i = 0; i < columns; i++){
            for (int j = 0; j < rows; j++){

                GameObject toInstantiate = floorTiles [spritesType];

                if(i == 0 || i == columns - 1){
                    if(j == 9 && i == columns - 1){
                        toInstantiate = floorTiles [spritesType];
                    }else{
                        toInstantiate = verticalWall [spritesType];
                    }

                }else if (j == 0 || j == rows - 1 ){
                    if (j == 0 && i == 11){
                        toInstantiate = floorTiles [spritesType];
                    }else{
                        toInstantiate = horizontalWall [spritesType];
                    }

                }
                else if((j == rows - 2 && i > 0 && i < columns - 1) || (j == rows - 3 && i > 0 && i < columns - 1) || (j == rows - 4 && i > 0 && i < columns - 1) || (j == rows - 5 && i > 0 && i < columns - 1)){
                    toInstantiate = wallInPerspective [spritesType];
                }
                else{
                    toInstantiate = floorTiles [spritesType];
                }

				GameObject instance = (GameObject)Instantiate (toInstantiate, new Vector3 (transform.position.x + i, transform.position.y + j, 0f), Quaternion.identity) as GameObject;
				instance.transform.SetParent (boardHolder);


            }
        }


        //Instantiate (player, new Vector2(transform.position.x, transform.position.y), Quaternion.identity);
        GameObject doorInstance = Instantiate (door[spritesType], new Vector2(transform.position.x + 11.04f, transform.position.y + 16.97f), Quaternion.identity);
        doorInstance.transform.SetParent (boardHolder);
    }
    void UDL(){
        boardHolder = new GameObject ("Board").transform;

        for (int i = 0; i < columns; i++){
            for (int j = 0; j < rows; j++){

                GameObject toInstantiate = floorTiles [spritesType];

                if(i == 0 || i == columns - 1){
                    if(j == 9 && i == 0){
                        toInstantiate = floorTiles [spritesType];
                    }else{
                        toInstantiate = verticalWall [spritesType];
                    }

                }else if (j == 0 || j == rows - 1 ){
                    if (j == 0 && i == 11){
                        toInstantiate = floorTiles [spritesType];
                    }else{
                        toInstantiate = horizontalWall [spritesType];
                    }

                }
                else if((j == rows - 2 && i > 0 && i < columns - 1) || (j == rows - 3 && i > 0 && i < columns - 1) || (j == rows - 4 && i > 0 && i < columns - 1) || (j == rows - 5 && i > 0 && i < columns - 1)){
                    toInstantiate = wallInPerspective [spritesType];
                }
                else{
                    toInstantiate = floorTiles [spritesType];
                }

                GameObject instance = (GameObject)Instantiate (toInstantiate, new Vector3 (transform.position.x + i, transform.position.y + j, 0f), Quaternion.identity) as GameObject;
                instance.transform.SetParent (boardHolder);


            }
        }


        //Instantiate (player, new Vector2(transform.position.x, transform.position.y), Quaternion.identity);
        GameObject doorInstance = Instantiate (door[spritesType], new Vector2(transform.position.x + 11.04f, transform.position.y + 16.97f), Quaternion.identity);
        doorInstance.transform.SetParent (boardHolder);
    }
    void URL(){
        boardHolder = new GameObject ("Board").transform;

        for (int i = 0; i < columns; i++){
            for (int j = 0; j < rows; j++){

                GameObject toInstantiate = floorTiles [spritesType];

                if(i == 0 || i == columns - 1){
                    if(j == 9){
                        toInstantiate = floorTiles [spritesType];
                    }else{
                        toInstantiate = verticalWall [spritesType];
                    }

                }else if (j == 0 || j == rows - 1 ){
                        toInstantiate = horizontalWall [spritesType];
                }
                else if((j == rows - 2 && i > 0 && i < columns - 1) || (j == rows - 3 && i > 0 && i < columns - 1) || (j == rows - 4 && i > 0 && i < columns - 1) || (j == rows - 5 && i > 0 && i < columns - 1)){
                    toInstantiate = wallInPerspective [spritesType];
                }
                else{
                    toInstantiate = floorTiles [spritesType];
                }

				GameObject instance = (GameObject)Instantiate (toInstantiate, new Vector3 (transform.position.x + i, transform.position.y + j, 0f), Quaternion.identity) as GameObject;
				instance.transform.SetParent (boardHolder);


            }
        }


        //Instantiate (player, new Vector2(transform.position.x, transform.position.y), Quaternion.identity);
        GameObject doorInstance = Instantiate (door[spritesType], new Vector2(transform.position.x + 11.04f, transform.position.y + 16.97f), Quaternion.identity);
        doorInstance.transform.SetParent (boardHolder);
    }
    void DRL(){
        boardHolder = new GameObject ("Board").transform;

        for (int i = 0; i < columns; i++){
            for (int j = 0; j < rows; j++){

                GameObject toInstantiate = floorTiles [spritesType];

                if(i == 0 || i == columns - 1){
                    if(j == 9){
                        toInstantiate = floorTiles [spritesType];
                    }else{
                        toInstantiate = verticalWall [spritesType];
                    }

                }else if (j == 0 || j == rows - 1 ){
                    if (j == 0 && i == 11){
                        toInstantiate = floorTiles [spritesType];
                    }else{
                        toInstantiate = horizontalWall [spritesType];
                    }

                }
                else if((j == rows - 2 && i > 0 && i < columns - 1) || (j == rows - 3 && i > 0 && i < columns - 1) || (j == rows - 4 && i > 0 && i < columns - 1) || (j == rows - 5 && i > 0 && i < columns - 1)){
                    toInstantiate = wallInPerspective [spritesType];
                }
                else{
                    toInstantiate = floorTiles [spritesType];
                }

				GameObject instance = (GameObject)Instantiate (toInstantiate, new Vector3 (transform.position.x + i, transform.position.y + j, 0f), Quaternion.identity) as GameObject;
				instance.transform.SetParent (boardHolder);


            }
        }
    }
    void UD(){
        boardHolder = new GameObject ("Board").transform;

        for (int i = 0; i < columns; i++){
            for (int j = 0; j < rows; j++){

                GameObject toInstantiate = floorTiles [spritesType];

                if(i == 0 || i == columns - 1){
                        toInstantiate = verticalWall [spritesType];
                }else if (j == 0 || j == rows - 1 ){
                    if (j == 0 && i == 11){
                        toInstantiate = floorTiles [spritesType];
                    }else{
                        toInstantiate = horizontalWall [spritesType];
                    }

                }
                else if((j == rows - 2 && i > 0 && i < columns - 1) || (j == rows - 3 && i > 0 && i < columns - 1) || (j == rows - 4 && i > 0 && i < columns - 1) || (j == rows - 5 && i > 0 && i < columns - 1)){
                    toInstantiate = wallInPerspective [spritesType];
                }
                else{
                    toInstantiate = floorTiles [spritesType];
                }

				GameObject instance = (GameObject)Instantiate (toInstantiate, new Vector3 (transform.position.x + i, transform.position.y + j, 0f), Quaternion.identity) as GameObject;
				instance.transform.SetParent (boardHolder);


            }
        }


        //Instantiate (player, new Vector2(transform.position.x, transform.position.y), Quaternion.identity);
        GameObject doorInstance = Instantiate (door[spritesType], new Vector2(transform.position.x + 11.04f, transform.position.y + 16.97f), Quaternion.identity);
        doorInstance.transform.SetParent (boardHolder);
    }
    void RL(){
        boardHolder = new GameObject ("Board").transform;

        for (int i = 0; i < columns; i++){
            for (int j = 0; j < rows; j++){

                GameObject toInstantiate = floorTiles [spritesType];

                if(i == 0 || i == columns - 1){
                    if(j == 9){
                        toInstantiate = floorTiles [spritesType];
                    }else{
                        toInstantiate = verticalWall [spritesType];
                    }

                }else if (j == 0 || j == rows - 1 ){
                        toInstantiate = horizontalWall [spritesType];
                }
                else if((j == rows - 2 && i > 0 && i < columns - 1) || (j == rows - 3 && i > 0 && i < columns - 1) || (j == rows - 4 && i > 0 && i < columns - 1) || (j == rows - 5 && i > 0 && i < columns - 1)){
                    toInstantiate = wallInPerspective [spritesType];
                }
                else{
                    toInstantiate = floorTiles [spritesType];
                }

				GameObject instance = (GameObject)Instantiate (toInstantiate, new Vector3 (transform.position.x + i, transform.position.y + j, 0f), Quaternion.identity) as GameObject;
				instance.transform.SetParent (boardHolder);


            }
        }
    }
    void UR(){
        boardHolder = new GameObject ("Board").transform;

        for (int i = 0; i < columns; i++){
            for (int j = 0; j < rows; j++){

                GameObject toInstantiate = floorTiles [spritesType];

                if(i == 0 || i == columns - 1){
                    if(j == 9 && i == columns -1){
                        toInstantiate = floorTiles [spritesType];
                    }else{
                        toInstantiate = verticalWall [spritesType];
                    }

                }else if (j == 0 || j == rows - 1 ){
                        toInstantiate = horizontalWall [spritesType];
                }
                else if((j == rows - 2 && i > 0 && i < columns - 1) || (j == rows - 3 && i > 0 && i < columns - 1) || (j == rows - 4 && i > 0 && i < columns - 1) || (j == rows - 5 && i > 0 && i < columns - 1)){
                    toInstantiate = wallInPerspective [spritesType];
                }
                else{
                    toInstantiate = floorTiles [spritesType];
                }

                GameObject instance = (GameObject)Instantiate (toInstantiate, new Vector3 (transform.position.x + i, transform.position.y + j, 0f), Quaternion.identity) as GameObject;
                instance.transform.SetParent (boardHolder);


            }
        }


        //Instantiate (player, new Vector2(transform.position.x, transform.position.y), Quaternion.identity);
        GameObject doorInstance = Instantiate (door[spritesType], new Vector2(transform.position.x + 11.04f, transform.position.y + 16.97f), Quaternion.identity);
        doorInstance.transform.SetParent (boardHolder);
    }
    void UL(){
        boardHolder = new GameObject ("Board").transform;

        for (int i = 0; i < columns; i++){
            for (int j = 0; j < rows; j++){

                GameObject toInstantiate = floorTiles [spritesType];

                if(i == 0 || i == columns - 1){
                    if(j == 9 && i == 0){
                        toInstantiate = floorTiles [spritesType];
                    }else{
                        toInstantiate = verticalWall [spritesType];
                    }

                }else if (j == 0 || j == rows - 1 ){
                        toInstantiate = horizontalWall [spritesType];
                }
                else if((j == rows - 2 && i > 0 && i < columns - 1) || (j == rows - 3 && i > 0 && i < columns - 1) || (j == rows - 4 && i > 0 && i < columns - 1) || (j == rows - 5 && i > 0 && i < columns - 1)){
                    toInstantiate = wallInPerspective [spritesType];
                }
                else{
                    toInstantiate = floorTiles [spritesType];
                }

                GameObject instance = (GameObject)Instantiate (toInstantiate, new Vector3 (transform.position.x + i, transform.position.y + j, 0f), Quaternion.identity) as GameObject;
                instance.transform.SetParent (boardHolder);


            }
        }


        //Instantiate (player, new Vector2(transform.position.x, transform.position.y), Quaternion.identity);
        GameObject doorInstance = Instantiate (door[spritesType], new Vector2(transform.position.x + 11.04f, transform.position.y + 16.97f), Quaternion.identity);
        doorInstance.transform.SetParent (boardHolder);
    }
    void DR(){
        boardHolder = new GameObject ("Board").transform;

        for (int i = 0; i < columns; i++){
            for (int j = 0; j < rows; j++){

                GameObject toInstantiate = floorTiles [spritesType];

                if(i == 0 || i == columns - 1){
                    if(j == 9 && i == columns - 1){
                        toInstantiate = floorTiles [spritesType];
                    }else{
                        toInstantiate = verticalWall [spritesType];
                    }

                }else if (j == 0 || j == rows - 1 ){
                    if (j == 0 && i == 11){
                        toInstantiate = floorTiles [spritesType];
                    }else{
                        toInstantiate = horizontalWall [spritesType];
                    }

                }
                else if((j == rows - 2 && i > 0 && i < columns - 1) || (j == rows - 3 && i > 0 && i < columns - 1) || (j == rows - 4 && i > 0 && i < columns - 1) || (j == rows - 5 && i > 0 && i < columns - 1)){
                    toInstantiate = wallInPerspective [spritesType];
                }
                else{
                    toInstantiate = floorTiles [spritesType];
                }

				GameObject instance = (GameObject)Instantiate (toInstantiate, new Vector3 (transform.position.x + i, transform.position.y + j, 0f), Quaternion.identity) as GameObject;
				instance.transform.SetParent (boardHolder);


            }
        }
    }
    void DL(){
        boardHolder = new GameObject ("Board").transform;

        for (int i = 0; i < columns; i++){
            for (int j = 0; j < rows; j++){

                GameObject toInstantiate = floorTiles [spritesType];

                if(i == 0 || i == columns - 1){
                    if(j == 9 && i == 0){
                        toInstantiate = floorTiles [spritesType];
                    }else{
                        toInstantiate = verticalWall [spritesType];
                    }

                }else if (j == 0 || j == rows - 1 ){
                    if (j == 0 && i == 11){
                        toInstantiate = floorTiles [spritesType];
                    }else{
                        toInstantiate = horizontalWall [spritesType];
                    }

                }
                else if((j == rows - 2 && i > 0 && i < columns - 1) || (j == rows - 3 && i > 0 && i < columns - 1) || (j == rows - 4 && i > 0 && i < columns - 1) || (j == rows - 5 && i > 0 && i < columns - 1)){
                    toInstantiate = wallInPerspective [spritesType];
                }
                else{
                    toInstantiate = floorTiles [spritesType];
                }

				GameObject instance = (GameObject)Instantiate (toInstantiate, new Vector3 (transform.position.x + i, transform.position.y + j, 0f), Quaternion.identity) as GameObject;
				instance.transform.SetParent (boardHolder);


            }
        }
    }
    void U(){
        boardHolder = new GameObject ("Board").transform;

        for (int i = 0; i < columns; i++){
            for (int j = 0; j < rows; j++){

                GameObject toInstantiate = floorTiles [spritesType];

                if(i == 0 || i == columns - 1){
                        toInstantiate = verticalWall [spritesType];

                }else if (j == 0 || j == rows - 1 ){
                        toInstantiate = horizontalWall [spritesType];
                }
                else if((j == rows - 2 && i > 0 && i < columns - 1) || (j == rows - 3 && i > 0 && i < columns - 1) || (j == rows - 4 && i > 0 && i < columns - 1) || (j == rows - 5 && i > 0 && i < columns - 1)){
                    toInstantiate = wallInPerspective [spritesType];
                }
                else{
                    toInstantiate = floorTiles [spritesType];
                }

				GameObject instance = (GameObject)Instantiate (toInstantiate, new Vector3 (transform.position.x + i, transform.position.y + j, 0f), Quaternion.identity) as GameObject;
				instance.transform.SetParent (boardHolder);


            }
        }


        //Instantiate (player, new Vector2(transform.position.x, transform.position.y), Quaternion.identity);
        GameObject doorInstance = Instantiate (door[spritesType], new Vector2(transform.position.x + 11.04f, transform.position.y + 16.97f), Quaternion.identity);
        doorInstance.transform.SetParent (boardHolder);
    }
    void D(){
        boardHolder = new GameObject ("Board").transform;

        for (int i = 0; i < columns; i++){
            for (int j = 0; j < rows; j++){

                GameObject toInstantiate = floorTiles [spritesType];

                if(i == 0 || i == columns - 1){
                        toInstantiate = verticalWall [spritesType];
                }else if (j == 0 || j == rows - 1 ){
                    if (j == 0 && i == 11){
                        toInstantiate = floorTiles [spritesType];
                    }else{
                        toInstantiate = horizontalWall [spritesType];
                    }

                }
                else if((j == rows - 2 && i > 0 && i < columns - 1) || (j == rows - 3 && i > 0 && i < columns - 1) || (j == rows - 4 && i > 0 && i < columns - 1) || (j == rows - 5 && i > 0 && i < columns - 1)){
                    toInstantiate = wallInPerspective [spritesType];
                }
                else{
                    toInstantiate = floorTiles [spritesType];
                }

				GameObject instance = (GameObject)Instantiate (toInstantiate, new Vector3 (transform.position.x + i, transform.position.y + j, 0f), Quaternion.identity) as GameObject;
				instance.transform.SetParent (boardHolder);

            }
        }
    }
    void R(){
        boardHolder = new GameObject ("Board").transform;

        for (int i = 0; i < columns; i++){
            for (int j = 0; j < rows; j++){

                GameObject toInstantiate = floorTiles [spritesType];

                if(i == 0 || i == columns - 1){
                    if(j == 9 && i == columns -1){
                        toInstantiate = floorTiles [spritesType];
                    }else{
                        toInstantiate = verticalWall [spritesType];
                    }

                }else if (j == 0 || j == rows - 1 ){
                        toInstantiate = horizontalWall [spritesType];

                }
                else if((j == rows - 2 && i > 0 && i < columns - 1) || (j == rows - 3 && i > 0 && i < columns - 1) || (j == rows - 4 && i > 0 && i < columns - 1) || (j == rows - 5 && i > 0 && i < columns - 1)){
                    toInstantiate = wallInPerspective [spritesType];
                }
                else{
                    toInstantiate = floorTiles [spritesType];
                }

				GameObject instance = (GameObject)Instantiate (toInstantiate, new Vector3 (transform.position.x + i, transform.position.y + j, 0f), Quaternion.identity) as GameObject;
				instance.transform.SetParent (boardHolder);

            }
        }
    }
    void L(){
        boardHolder = new GameObject ("Board").transform;

        for (int i = 0; i < columns; i++){
            for (int j = 0; j < rows; j++){

                GameObject toInstantiate = floorTiles [spritesType];

                if(i == 0 || i == columns - 1){
                    if(j == 9 && i == 0){
                        toInstantiate = floorTiles [spritesType];
                    }else{
                        toInstantiate = verticalWall [spritesType];
                    }

                }else if (j == 0 || j == rows - 1 ){
                        toInstantiate = horizontalWall [spritesType];

                }
                else if((j == rows - 2 && i > 0 && i < columns - 1) || (j == rows - 3 && i > 0 && i < columns - 1) || (j == rows - 4 && i > 0 && i < columns - 1) || (j == rows - 5 && i > 0 && i < columns - 1)){
                    toInstantiate = wallInPerspective [spritesType];
                }
                else{
                    toInstantiate = floorTiles [spritesType];
                }

				GameObject instance = (GameObject)Instantiate (toInstantiate, new Vector3 (transform.position.x + i, transform.position.y + j, 0f), Quaternion.identity) as GameObject;
				instance.transform.SetParent (boardHolder);

            }
        }
    }

    //Selecciona que metodo utilizar para generar el room
    void choiceRoom (){
        if (UP){
			if (DOWN){
				if (RIGHT){
					if (LEFT){
						UDRL();
					}else{
						UDR();
					}
				}else if (LEFT){
					UDL();
				}else{
					UD();
				}
			}else{
				if (RIGHT){
					if (LEFT){
						URL();
					}else{
						UR();
					}
				}else if (LEFT){
					UL();
				}else{
					U();
				}
			}
			return;
		}
		if (DOWN){
			if (RIGHT){
				if(LEFT){
					DRL();;
				}else{
					DR();
				}
			}else if (LEFT){
				DL();
			}else{
				D();
			}
			return;
		}
		if (RIGHT){
			if (LEFT){
				RL();
			}else{
				R();
			}
		}else{
			L();
		}
    }

    // Asigna las posiciones de las puertas y llama el metodo para escoger el tipo de cuarto
    public void Setup(Vector2 _gridPos, bool _doorTop, bool _doorBot, bool _doorLeft, bool _doorRight){
        gridPos = _gridPos;
        UP = _doorTop;
		DOWN = _doorBot;
		LEFT = _doorLeft;
		RIGHT = _doorRight;
        //choiceRoom();
	}


}
