using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dracula_Behavior : MonoBehaviour {

	//Player vars
	private Transform player;
	public GameObject generator;
	//Variables used for the different attack types
	private bool waveAttack;
	private int waveDirection;
	private bool specialAttack;

	//Variables used for the shooting of any type of attack
	private float speed;
	public Rigidbody2D bullet;
	private GameObject weaponBoss;
	public GameObject weaponCannonBoss;

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
		weaponBoss = GameObject.FindGameObjectWithTag ("weaponBoss");


		speed = 3;
		waveAttack = false;
		specialAttack = false;

		stoppingDistance = 5;
		retreatDistance = 5;

		anim = gameObject.GetComponent<Animator> ();
		deadTime = 3;
		dead = false;
		life = 10;
		waveDirection = 3;

		InvokeRepeating("normalShoot", 2.0f, 1f);
		InvokeRepeating("specialAttackBoss", 2.0f, 0.2f);
		InvokeRepeating("midLifeAttack", 2.0f, 2.5f);
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
	void midLifeAttack() {
		if (!dead && isInRange()) {
			if (waveAttack && !specialAttack) {
				rightWall ();
				leftWall ();
				upperWall ();
				bottomWall ();
				retreatDistance = 0;
				stoppingDistance = 0;
			}
		}
	}

	void bottomWall() {
		Rigidbody2D bulletInstanceTopB = Instantiate (bullet, new Vector3 (transform.position.x + 1f, transform.position.y - 2f), Quaternion.Euler (new Vector3 (transform.eulerAngles.x, transform.eulerAngles.y, transform.eulerAngles.z))) as Rigidbody2D;
		Rigidbody2D bulletInstanceMidB = Instantiate (bullet, new Vector3 (transform.position.x, transform.position.y - 2f), Quaternion.Euler (new Vector3 (transform.eulerAngles.x, transform.eulerAngles.y, transform.eulerAngles.z))) as Rigidbody2D;
		Rigidbody2D bulletInstanceBotB = Instantiate (bullet, new Vector3 (transform.position.x - 1f, transform.position.y - 2f), Quaternion.Euler (new Vector3 (transform.eulerAngles.x, transform.eulerAngles.y, transform.eulerAngles.z))) as Rigidbody2D;

		bulletInstanceTopB.velocity = magnitudeBossToPlayer();
		bulletInstanceMidB.velocity = magnitudeBossToPlayer();
		bulletInstanceBotB.velocity = magnitudeBossToPlayer();
	}

	void upperWall() {
		Rigidbody2D bulletInstanceTopU = Instantiate (bullet, new Vector3 (transform.position.x + 1f, transform.position.y + 2f), Quaternion.Euler (new Vector3 (transform.eulerAngles.x, transform.eulerAngles.y, transform.eulerAngles.z))) as Rigidbody2D;
		Rigidbody2D bulletInstanceMidU = Instantiate (bullet, new Vector3 (transform.position.x, transform.position.y + 2f), Quaternion.Euler (new Vector3 (transform.eulerAngles.x, transform.eulerAngles.y, transform.eulerAngles.z))) as Rigidbody2D;
		Rigidbody2D bulletInstanceBotU = Instantiate (bullet, new Vector3 (transform.position.x - 1f, transform.position.y + 2f), Quaternion.Euler (new Vector3 (transform.eulerAngles.x, transform.eulerAngles.y, transform.eulerAngles.z))) as Rigidbody2D;

		bulletInstanceTopU.velocity = magnitudeBossToPlayer();
		bulletInstanceMidU.velocity = magnitudeBossToPlayer();
		bulletInstanceBotU.velocity = magnitudeBossToPlayer();
	}

	void leftWall() {
		Rigidbody2D bulletInstanceTopL = Instantiate (bullet, new Vector3 (transform.position.x - 2f, transform.position.y + 1f), Quaternion.Euler (new Vector3 (transform.eulerAngles.x, transform.eulerAngles.y, transform.eulerAngles.z))) as Rigidbody2D;
		Rigidbody2D bulletInstanceMidL = Instantiate (bullet, new Vector3 (transform.position.x - 2f, transform.position.y), Quaternion.Euler (new Vector3 (transform.eulerAngles.x, transform.eulerAngles.y, transform.eulerAngles.z))) as Rigidbody2D;
		Rigidbody2D bulletInstanceBotL = Instantiate (bullet, new Vector3 (transform.position.x - 2f, transform.position.y - 1f), Quaternion.Euler (new Vector3 (transform.eulerAngles.x, transform.eulerAngles.y, transform.eulerAngles.z))) as Rigidbody2D;

		bulletInstanceTopL.velocity = magnitudeBossToPlayer();
		bulletInstanceMidL.velocity = magnitudeBossToPlayer();
		bulletInstanceBotL.velocity = magnitudeBossToPlayer();
	}

	void rightWall() {
		Rigidbody2D bulletInstanceTopR = Instantiate (bullet, new Vector3 (transform.position.x + 2f, transform.position.y + 1f), Quaternion.Euler (new Vector3 (transform.eulerAngles.x, transform.eulerAngles.y, transform.eulerAngles.z))) as Rigidbody2D;
		Rigidbody2D bulletInstanceMidR = Instantiate (bullet, new Vector3 (transform.position.x + 2f, transform.position.y), Quaternion.Euler (new Vector3 (transform.eulerAngles.x, transform.eulerAngles.y, transform.eulerAngles.z))) as Rigidbody2D;
		Rigidbody2D bulletInstanceBotR = Instantiate (bullet, new Vector3 (transform.position.x + 2f, transform.position.y - 1f), Quaternion.Euler (new Vector3 (transform.eulerAngles.x, transform.eulerAngles.y, transform.eulerAngles.z))) as Rigidbody2D;

		bulletInstanceTopR.velocity = magnitudeBossToPlayer();
		bulletInstanceMidR.velocity = magnitudeBossToPlayer();
		bulletInstanceBotR.velocity = magnitudeBossToPlayer();
	}

	Vector3 magnitudeBossToPlayer() {
		Vector3 magnitudeBossToPlayer = (targetPositionCubeAttack() - transform.position).normalized * speed * 3;
		return magnitudeBossToPlayer;
	}

	Vector3 targetPositionCubeAttack() {
		Vector3 targetPositionCubeAttack = new Vector3 (player.transform.position.x, player.transform.position.y, player.transform.position.z);
		return targetPositionCubeAttack;
	}

	void specialAttackBoss() {
		if (!dead && isInRange()) {
			if(specialAttack && !waveAttack) {

				Vector3 waveSpread = new Vector3 (player.transform.position.x + waveDirection, player.transform.position.y + waveDirection, player.transform.position.z);
				Vector3 waveSpreadNeg = new Vector3 (player.transform.position.x - waveDirection, player.transform.position.y - waveDirection, player.transform.position.z);
				//Magnitud of Vector
				Vector3 direction = (waveSpread - weaponBoss.transform.position).normalized * speed * 3;
				Vector3 directionNeg = (waveSpreadNeg - weaponBoss.transform.position).normalized * speed * 3;

				//Bullet Instance
				Rigidbody2D bulletInstanceWave = Instantiate (bullet, new Vector3 (weaponCannonBoss.transform.position.x, weaponCannonBoss.transform.position.y), Quaternion.Euler (new Vector3 (weaponCannonBoss.transform.eulerAngles.x, weaponCannonBoss.transform.eulerAngles.y, weaponCannonBoss.transform.eulerAngles.z))) as Rigidbody2D;
				Rigidbody2D bulletInstanceWaveNeg = Instantiate (bullet, new Vector3 (weaponCannonBoss.transform.position.x, weaponCannonBoss.transform.position.y), Quaternion.Euler (new Vector3 (weaponCannonBoss.transform.eulerAngles.x, weaponCannonBoss.transform.eulerAngles.y, weaponCannonBoss.transform.eulerAngles.z))) as Rigidbody2D;

				//Addition of magnitud to velocity of bullet
				bulletInstanceWave.velocity = direction;
				bulletInstanceWaveNeg.velocity = directionNeg;

				waveDirection--;
				if (waveDirection == 0) {
					waveDirection = 3;
				}

				retreatDistance = 0;
				stoppingDistance = 0;
			}
		}
	}

	void normalShoot() {
		if (!dead && isInRange()) {
			if (!specialAttack && !waveAttack) {
				Vector3 dir = (playerPosition() - weaponBoss.transform.position).normalized * speed * 3;
				Rigidbody2D bulletInstance = Instantiate (bullet, new Vector3 (weaponCannonBoss.transform.position.x, weaponCannonBoss.transform.position.y), Quaternion.Euler (new Vector3 (weaponCannonBoss.transform.eulerAngles.x, weaponCannonBoss.transform.eulerAngles.y, weaponCannonBoss.transform.eulerAngles.z))) as Rigidbody2D;
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
				anim.Play("Frankenjdead");
				BossControl one = generator.gameObject.GetComponent<BossControl> ();
				one.isGame ();
				Destroy (gameObject, deadTime);
			} else {
				life--;
			}
		}

		if (life == 6) {
			waveAttack = true;
		}

		if (life == 3) {
			specialAttack = true;
			waveAttack = false;
		}
	}

	void weaponAngle() {

		float angle = AngleBetweenTwoPoints (playerPosition(), weaponBoss.transform.position);

		if (player.transform.position.x < gameObject.transform.position.x) {
			if (angle < 90 && angle > -90) {
				weaponBoss.transform.localScale = new Vector3 (-0.2f, 0.2f);
				weaponBoss.transform.rotation = Quaternion.Euler (new Vector3 (0f, 0f, angle));
			} else {
				weaponBoss.transform.localScale = new Vector3 (-0.2f, -0.2f);
				angle = AngleBetweenTwoPoints (player.transform.position, weaponBoss.transform.position);
				weaponBoss.transform.rotation = Quaternion.Euler (new Vector3 (0f, 0f, angle));
			}
		} else {
			if (angle < 90 && angle > -90) {
				weaponBoss.transform.localScale = new Vector3 (0.2f, 0.2f);
				angle = AngleBetweenTwoPoints (player.transform.position, weaponBoss.transform.position);
				weaponBoss.transform.rotation = Quaternion.Euler (new Vector3 (0f, 0f, angle));

			} else {
				weaponBoss.transform.localScale = new Vector3 (0.2f, 0.2f);
				angle = AngleBetweenTwoPoints (player.transform.position, weaponBoss.transform.position);
				weaponBoss.transform.rotation = Quaternion.Euler (new Vector3 (0f, 0f, angle));
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
