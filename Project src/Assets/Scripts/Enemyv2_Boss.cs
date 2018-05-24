using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemyv2_Boss : MonoBehaviour {

	//Player vars
	private Transform player;

	//Shoot vars
	private bool spread;
	private bool specialAttack;
	private int timeShots;
	private int specialAttackTimeShots;
	private float speed;
	public Rigidbody2D bullet;
	private GameObject weapon;
	private GameObject weaponCannon;
	public GameObject generator;

	//Life vars
	private int life;
	//Movement vars
	private float stoppingDistance;
	private float retreatDistance;

	//Animation vars
	Animator anim;
	public Sprite frontSprite;
	public Sprite backSprite;
	public float scale_X;
	public float scale_Y;
	public bool front;
	public bool right;
	int deadTime;
	bool dead;

	void Start () {
		generator = GameObject.FindGameObjectWithTag ("Gen");
		player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform> ();
		weapon = GameObject.FindGameObjectWithTag ("BossWeapon");
		weaponCannon = GameObject.Find ("weaponCannon");
		timeShots = 40;
		specialAttackTimeShots = 100;
		speed = 3;
		spread = false;
		specialAttack = false;

		stoppingDistance = 5;
		retreatDistance = 5;

		anim = gameObject.GetComponent<Animator> ();
		deadTime = 1;
		dead = false;
		life = 10;
	}

	bool isInRange() {

		float distance = Vector3.Distance (player.transform.position, transform.position);
		if (distance < 17) {
			return true;
		}

		return false;
	}

	void Update () {

		if (!dead) {
			Vector3 temp = player.transform.position;

			if (isInRange()) {
				movement ();
				animations ();
				weaponAngle ();


				if (life == 6) {
					spread = true;
				}

				if (life == 3) {
					spread = false;
					specialAttack = true;
					retreatDistance = 0;
					stoppingDistance = 0;
				}

				if (((specialAttackTimeShots == 100)) && (specialAttack == true)) {

					//Vectors
					Vector3 specialBot = new Vector3 (transform.position.x, transform.position.y - 10f, transform.position.z);
					Vector3 specialTop = new Vector3 (transform.position.x, transform.position.y + 10f, transform.position.z);
					Vector3 specialRight = new Vector3 (transform.position.x + 10f, transform.position.y, transform.position.z);
					Vector3 specialLeft = new Vector3 (transform.position.x - 10f, transform.position.y, transform.position.z);

					//Magnitud of Vector
					Vector3 specialBotDir = (specialBot - transform.position).normalized * speed * 3;
					Vector3 specialTopDir = (specialTop - transform.position).normalized * speed * 3;
					Vector3 specialRightDir = (specialRight - transform.position).normalized * speed * 3;
					Vector3 specialLeftDir = (specialLeft - transform.position).normalized * speed * 3;

					//Bullet Instance
					Rigidbody2D bulletSpecialBot = Instantiate (bullet, new Vector3 (transform.position.x, transform.position.y), Quaternion.Euler (new Vector3 (transform.eulerAngles.x, transform.eulerAngles.y, transform.eulerAngles.z))) as Rigidbody2D;
					Rigidbody2D bulletSpecialTop = Instantiate (bullet, new Vector3 (transform.position.x, transform.position.y), Quaternion.Euler (new Vector3 (transform.eulerAngles.x, transform.eulerAngles.y, transform.eulerAngles.z))) as Rigidbody2D;
					Rigidbody2D bulletSpecialRight = Instantiate (bullet, new Vector3 (transform.position.x, transform.position.y), Quaternion.Euler (new Vector3 (transform.eulerAngles.x, transform.eulerAngles.y, transform.eulerAngles.z))) as Rigidbody2D;
					Rigidbody2D bulletSpecialLeft = Instantiate (bullet, new Vector3 (transform.position.x, transform.position.y), Quaternion.Euler (new Vector3 (transform.eulerAngles.x, transform.eulerAngles.y, transform.eulerAngles.z))) as Rigidbody2D;

					//Addition of magnitud to velocity of bullet
					bulletSpecialBot.velocity = specialBotDir;
					bulletSpecialTop.velocity = specialTopDir;
					bulletSpecialRight.velocity = specialRightDir;
					bulletSpecialLeft.velocity = specialLeftDir;

				} else if (timeShots == 0 || specialAttackTimeShots == 0) {
					if (spread == true) {
						Vector3 spreadTop = new Vector3 (player.transform.position.x + 1f, player.transform.position.y + 1f, player.transform.position.z);
						Vector3 spreadBot = new Vector3 (player.transform.position.x - 1f, player.transform.position.y - 1f, player.transform.position.z);

						Vector3 topDir = (spreadTop - weapon.transform.position).normalized * speed * 3;
						Vector3 botDir = (spreadBot - weapon.transform.position).normalized * speed * 3;

						Rigidbody2D bulletInstanceTop = Instantiate (bullet, new Vector3 (weaponCannon.transform.position.x, weaponCannon.transform.position.y), Quaternion.Euler (new Vector3 (weaponCannon.transform.eulerAngles.x, weaponCannon.transform.eulerAngles.y, weaponCannon.transform.eulerAngles.z))) as Rigidbody2D;
						Rigidbody2D bulletInstanceBot = Instantiate (bullet, new Vector3 (weaponCannon.transform.position.x, weaponCannon.transform.position.y), Quaternion.Euler (new Vector3 (weaponCannon.transform.eulerAngles.x, weaponCannon.transform.eulerAngles.y, weaponCannon.transform.eulerAngles.z))) as Rigidbody2D;

						bulletInstanceBot.velocity = botDir;
						bulletInstanceTop.velocity = topDir;
					}

					Vector3 dir = (temp - weapon.transform.position).normalized * speed * 3;
					Rigidbody2D bulletInstance = Instantiate (bullet, new Vector3 (weaponCannon.transform.position.x, weaponCannon.transform.position.y), Quaternion.Euler (new Vector3 (weaponCannon.transform.eulerAngles.x, weaponCannon.transform.eulerAngles.y, weaponCannon.transform.eulerAngles.z))) as Rigidbody2D;
					bulletInstance.velocity = dir;

					if (timeShots == 0) {
						timeShots = 40;
						specialAttackTimeShots--;
					}

					if (specialAttackTimeShots == 0) {
						specialAttackTimeShots = 100;
						timeShots--;
					}
				} else {
					timeShots--;
					specialAttackTimeShots--;
				}
			}
		}
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

	void weaponAngle() {

		float angle = AngleBetweenTwoPoints (player.transform.position, weapon.transform.position);

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
			GetComponent<SpriteRenderer>().sprite = backSprite;
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

	void OnTriggerEnter2D(Collider2D other){
		Debug.Log ("Life is" + life);
		if (other.gameObject.name == "Bullet2(Clone)" || other.gameObject.name == "Bullet2") {
			Destroy (other.gameObject);
			Debug.Log ("Destroyed Bullet");
			if (life <= 0) {
				dead = true;
				anim.Play("Frankenjdead");
				Destroy (gameObject, deadTime);
				Debug.Log ("Destroyed Boss");
				BossControl one = generator.gameObject.GetComponent<BossControl> ();
				one.isGame ();
			} else {
				life--;
			}
		}
	}
}
