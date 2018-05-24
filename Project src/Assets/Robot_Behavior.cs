using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Robot_Behavior : MonoBehaviour {

	//Player vars
	private Transform player;

	//Variables used for the different attack types
	private bool midLifeAttack;
	private bool specialAttack;

	//Variables used for the shooting of any type of attack
	private float speed;
	public Rigidbody2D bullet;
	public GameObject weapon;
	public GameObject weaponCannon;
	public GameObject generator;

	//Variable for keeping track of life
	private int life;

	//Variables to make boss stop/retreat
	private float stoppingDistance;
	private float retreatDistance;

	//Variables used for the different animations
	Animator anim;
	public Sprite frontSprite;
	public float scale_X;
	public float scale_Y;
	public bool front;
	public bool right;
	int deadTime;
	bool dead;

	void Start () {

		generator = GameObject.FindGameObjectWithTag ("Gen");
		player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform> ();

		speed = 3;
		midLifeAttack = false;
		specialAttack = false;

		stoppingDistance = 5;
		retreatDistance = 5;

		anim = gameObject.GetComponent<Animator> ();
		deadTime = 3;
		dead = false;
		life = 10;

		InvokeRepeating("normalShoot", 2.0f, 0.6f);
		InvokeRepeating("specialAttackBossPart2", 2.0f, 1.5f);
		InvokeRepeating("midLifeAttackBoss", 2.0f, 0.5f);
	}

	void Update () {
		if (!dead) {
			if (isInRange()) {
				movement ();
				animations ();
				weaponAngle ();
			}
		}
	}

	bool isInRange() {

		float distance = Vector3.Distance (player.transform.position, transform.position);
		if (distance < 17) {
			return true;
		}

		return false;
	}

	void specialAttackBoss() {
		if (!dead && isInRange()) {
			if(specialAttack && !midLifeAttack) {

				rightWall ();
				leftWall ();
				upperWall ();
				bottomWall ();
				retreatDistance = 0;
				stoppingDistance = 0;


			}
		}
	}

	void specialAttackBossPart2() {
		if (!dead && isInRange()) {
			if(specialAttack && !midLifeAttack) {

				rightWallPart2 ();
				leftWallPart2 ();
				upperWallPart2 ();
				bottomWallPart2 ();
				retreatDistance = 0;
				stoppingDistance = 0;
			}
		}
	}

	void bottomWallPart2() {
		for (int i = -1; i < 1; i++) {
			Rigidbody2D bulletInstanceBot = Instantiate (bullet, new Vector3 (transform.position.x + i, transform.position.y - 1f), Quaternion.Euler (new Vector3 (transform.eulerAngles.x, transform.eulerAngles.y, transform.eulerAngles.z))) as Rigidbody2D;
			bulletInstanceBot.velocity = magnitudeBossToPlayer();
		}
	}

	void upperWallPart2() {
		for (int i = -1; i < 1; i++) {
			Rigidbody2D bulletInstanceTop = Instantiate (bullet, new Vector3 (transform.position.x + i, transform.position.y + 1f), Quaternion.Euler (new Vector3 (transform.eulerAngles.x, transform.eulerAngles.y, transform.eulerAngles.z))) as Rigidbody2D;
			bulletInstanceTop.velocity = magnitudeBossToPlayer();
		}
	}

	void leftWallPart2() {

		for (int i = -1; i < 1; i++) {
			Rigidbody2D bulletInstanceLeft = Instantiate (bullet, new Vector3 (transform.position.x - 1f, transform.position.y + i), Quaternion.Euler (new Vector3 (transform.eulerAngles.x, transform.eulerAngles.y, transform.eulerAngles.z))) as Rigidbody2D;
			bulletInstanceLeft.velocity = magnitudeBossToPlayer();
		}
	}

	void rightWallPart2() {
		for (int i = -1; i < 1; i++) {
			Rigidbody2D bulletInstanceRight = Instantiate (bullet, new Vector3 (transform.position.x + 1f, transform.position.y + i), Quaternion.Euler (new Vector3 (transform.eulerAngles.x, transform.eulerAngles.y, transform.eulerAngles.z))) as Rigidbody2D;
			bulletInstanceRight.velocity = magnitudeBossToPlayer();
		}
	}

	void bottomWall() {
		for (int i = -1; i < 2; i++) {
			Rigidbody2D bulletInstanceBot = Instantiate (bullet, new Vector3 (transform.position.x + i, transform.position.y - 2f), Quaternion.Euler (new Vector3 (transform.eulerAngles.x, transform.eulerAngles.y, transform.eulerAngles.z))) as Rigidbody2D;
			bulletInstanceBot.velocity = magnitudeBossToPlayer();
		}
	}

	void upperWall() {
		for (int i = -1; i < 2; i++) {
			Rigidbody2D bulletInstanceTop = Instantiate (bullet, new Vector3 (transform.position.x + i, transform.position.y + 2f), Quaternion.Euler (new Vector3 (transform.eulerAngles.x, transform.eulerAngles.y, transform.eulerAngles.z))) as Rigidbody2D;
			bulletInstanceTop.velocity = magnitudeBossToPlayer();
		}
	}

	void leftWall() {

		for (int i = -1; i < 2; i++) {
			Rigidbody2D bulletInstanceLeft = Instantiate (bullet, new Vector3 (transform.position.x - 2f, transform.position.y + i), Quaternion.Euler (new Vector3 (transform.eulerAngles.x, transform.eulerAngles.y, transform.eulerAngles.z))) as Rigidbody2D;
			bulletInstanceLeft.velocity = magnitudeBossToPlayer();
		}
	}

	void rightWall() {
		for (int i = -1; i < 2; i++) {
			Rigidbody2D bulletInstanceRight = Instantiate (bullet, new Vector3 (transform.position.x + 2f, transform.position.y + i), Quaternion.Euler (new Vector3 (transform.eulerAngles.x, transform.eulerAngles.y, transform.eulerAngles.z))) as Rigidbody2D;
			bulletInstanceRight.velocity = magnitudeBossToPlayer();
		}
	}


	void midLifeAttackBoss() {
		if (!dead && isInRange()) {
			if (midLifeAttack && !specialAttack) {

				int rand = Random.Range (0, 2);

				if (rand == 0) {
					horizontalWall ();
				} else {
					verticalWall ();
				}
				retreatDistance = 0;
				stoppingDistance = 0;
			}
		}
	}

	void verticalWall() {
		for (int i = -3; i < 3; i++) {
			Rigidbody2D bulletInstance = Instantiate (bullet, new Vector3 (transform.position.x, transform.position.y + i), Quaternion.Euler (new Vector3 (transform.eulerAngles.x, transform.eulerAngles.y, transform.eulerAngles.z))) as Rigidbody2D;
			bulletInstance.velocity = magnitudeBossToPlayer ();
		}
	}

	void horizontalWall() {
		for (int i = -3; i < 3; i++) {
			Rigidbody2D bulletInstance = Instantiate (bullet, new Vector3 (transform.position.x + i, transform.position.y), Quaternion.Euler (new Vector3 (transform.eulerAngles.x, transform.eulerAngles.y, transform.eulerAngles.z))) as Rigidbody2D;
			bulletInstance.velocity = magnitudeBossToPlayer ();
		}
	}


	Vector3 magnitudeBossToPlayer() {
		Vector3 magnitudeBossToPlayer = (targetPositionCubeAttack() - transform.position).normalized * speed * 3;
		return magnitudeBossToPlayer;
	}

	Vector3 targetPositionCubeAttack() {

		if (specialAttack) {
			Vector3 targetPositionCubeAttack = new Vector3 (player.transform.position.x, player.transform.position.y, player.transform.position.z);
			return targetPositionCubeAttack;
		} else {

			int rand = Random.Range (0, 2);
			int randDirection = Random.Range (0, 2);
			float modifier;

			if (rand == 0) {
				modifier = 10f;
			} else {
				modifier = -10f;
			}

			if (randDirection == 0) {
				Vector3 targetPositionCubeAttack = new Vector3 (transform.position.x, transform.position.y + modifier, transform.position.z);
				return targetPositionCubeAttack;
			} else {
				Vector3 targetPositionCubeAttack = new Vector3 (transform.position.x + modifier, transform.position.y, transform.position.z);
				return targetPositionCubeAttack;
			}
		}
	}

	void normalShoot() {
		if (!dead && isInRange()) {
			if (!specialAttack && !midLifeAttack) {
				Vector3 dir = (playerPosition() - weapon.transform.position).normalized * speed * 3;
				Rigidbody2D bulletInstance = Instantiate (bullet, new Vector3 (weaponCannon.transform.position.x, weaponCannon.transform.position.y), Quaternion.Euler (new Vector3 (weaponCannon.transform.eulerAngles.x, weaponCannon.transform.eulerAngles.y, weaponCannon.transform.eulerAngles.z))) as Rigidbody2D;
				bulletInstance.velocity = dir;
			}
		}
	}

	Vector3 playerPosition() {
		return player.transform.position;
	}

	public bool GetSide(){
		return right;
	}
	public bool GetFront(){
		return front;
	}

	float AngleBetweenTwoPoints(Vector3 a, Vector3 b) {
		return Mathf.Atan2(a.y - b.y, a.x - b.x) * Mathf.Rad2Deg;
	}

	void OnTriggerEnter2D(Collider2D other){
		Debug.Log ("Life is" + life);
		if (other.gameObject.name == "Bullet2(Clone)" || other.gameObject.name == "Bullet2") {
			Destroy (other.gameObject);
			Debug.Log ("Destroyed Bullet");
			if (life <= 0) {
				dead = true;
				anim.Play("Robotjdead");
				BossControl one = generator.gameObject.GetComponent<BossControl> ();
				one.isGame ();
				Destroy (gameObject, deadTime);
			} else {
				life--;
			}
		}

		if (life == 6) {
			specialAttack = true;
		}

		if (life == 3) {
			midLifeAttack = true;
			specialAttack = false;
		}
	}

	void weaponAngle() {

		float angle = AngleBetweenTwoPoints (playerPosition(), weapon.transform.position);

		if (player.transform.position.x < gameObject.transform.position.x) {
			if (angle < 90 && angle > -90) {
				weapon.transform.localScale = new Vector3 (-0.2f, 0.2f);
				weapon.transform.rotation = Quaternion.Euler (new Vector3 (0f, 0f, angle));
			} else {
				weapon.transform.localScale = new Vector3 (-0.2f, -0.2f);
				angle = AngleBetweenTwoPoints (player.transform.position, weapon.transform.position);
				weapon.transform.rotation = Quaternion.Euler (new Vector3 (0f, 0f, angle));
			}
		} else {
			if (angle < 90 && angle > -90) {
				weapon.transform.localScale = new Vector3 (0.2f, 0.2f);
				angle = AngleBetweenTwoPoints (player.transform.position, weapon.transform.position);
				weapon.transform.rotation = Quaternion.Euler (new Vector3 (0f, 0f, angle));

			} else {
				weapon.transform.localScale = new Vector3 (0.2f, 0.2f);
				angle = AngleBetweenTwoPoints (player.transform.position, weapon.transform.position);
				weapon.transform.rotation = Quaternion.Euler (new Vector3 (0f, 0f, angle));
			}
		}
	}

	void animations() {

		Vector3 mov = new Vector3 (
			transform.position.x,
			transform.position.y,
			0
		);

		anim.SetFloat ("Axis_X", mov.x);
		anim.SetFloat ("Axis_Y", mov.y);

		if (mov.y < 0) {
			front = true;
			right = false;
			GetComponent<SpriteRenderer>().sprite = frontSprite;
			anim.SetBool("front", front);
			anim.SetBool("right", right);

		} else if (mov.y > 0) {
			front = false;
			right = false;
			anim.SetBool("front", front);
			anim.SetBool("right", right);
		}
		if (mov.x < 0) {
			if (player.transform.position.x < transform.position.x) {
				transform.localScale = new Vector3 (-scale_X, scale_Y, 1);
				right = false;
				front = false;
			} else {
				transform.localScale = new Vector3 (scale_X, scale_Y, 1);
				right = true;
				front = false;
			}
			anim.SetBool("right", right);
			anim.SetBool("front", front);

		}
		else if(mov.x > 0){
			if (player.transform.position.x > transform.position.x) {
				transform.localScale = new Vector3 (scale_X, scale_Y,1);
				right = true;
				front = false;
			} else {
				transform.localScale = new Vector3 (-scale_X, scale_Y, 1);
				right = false;
				front = false;
			}
			anim.SetBool("right", right);
			anim.SetBool("front", front);
		}
	}

	void movement() {

		if (Vector2.Distance (transform.position, player.position) > stoppingDistance) {
			transform.position = Vector2.MoveTowards (transform.position, player.position, speed * Time.deltaTime);
		} else if (Vector2.Distance (transform.position, player.position) < stoppingDistance && Vector2.Distance (transform.position, player.position) > retreatDistance){
			transform.position = this.transform.position;
		} else if (Vector2.Distance (transform.position, player.position) < retreatDistance){
			transform.position = Vector2.MoveTowards (transform.position, player.position, -speed * Time.deltaTime);
		}
	}
}
