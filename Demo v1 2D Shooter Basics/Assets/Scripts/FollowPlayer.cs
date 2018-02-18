using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class FollowPlayer : MonoBehaviour
{

	public Transform Player;
	public int AlertDistance;
	public int MoveSpeed;
	public int MaxDist;
	public int MinDist;
	Animator anim;
	Rigidbody2D rb;
	bool Alerted = false;
	public Rigidbody2D bullet;
	public float maxSpeed = 25f;
	private float nextShot = 0f;
	private float period = 2.0f;





	float AngleBetweenTwoPoints(Vector3 a, Vector3 b) {
		return Mathf.Atan2(a.y - b.y, a.x - b.x) * Mathf.Rad2Deg;

	}

	IEnumerator ExecuteAfterTime(float time){
		yield return new WaitForSeconds (time);
	}

	void Start()
	{
		anim = GetComponent<Animator> ();
	}

	void Update(){
		EnemyDies enemy = GetComponent<EnemyDies> ();	
		bool life = enemy.GetLife ();
		if (life) {
			if (AlertDistance > Vector2.Distance (transform.position, Player.position)) {
				Alerted = true;
			}

			if (Alerted) {

				Vector2 positionOnScreen = transform.position;

				//Get the Screen position of the mouse
				Vector2 playerOnScreen =Player.position;
				float randomx = Random.Range (0, 2);
				float randomy = Random.Range (0, 2);


				float angle = AngleBetweenTwoPoints(playerOnScreen, positionOnScreen);

				if (angle < 90 && angle > -90) {
					transform.localScale = new Vector3 (1f, 1);
					transform.rotation = Quaternion.Euler (new Vector3 (0f, 0f, angle));

				} else{
					transform.localScale = new Vector3 (-1f, 1);
					angle = AngleBetweenTwoPoints(positionOnScreen, playerOnScreen);
					transform.rotation = Quaternion.Euler (new Vector3 (0f, 0f, angle));
				}

				if (Time.time > nextShot){
					nextShot += period;
					Vector3 shootDirection;
					shootDirection = Player.position;
					shootDirection.z = 0.0f;
					//shootDirection = Camera.main.ScreenToWorldPoint(shootDirection);
					shootDirection = shootDirection-transform.position;
					ExecuteAfterTime (6f);
					Rigidbody2D bulletInstance = Instantiate (bullet, transform.position, Quaternion.Euler (new Vector3 (transform.eulerAngles.x, transform.eulerAngles.y, transform.eulerAngles.z))) as Rigidbody2D;
					bulletInstance.velocity = new Vector2 ((shootDirection.x +randomx)* maxSpeed, (shootDirection.y+randomy) * maxSpeed);
					anim.Play ("Fire");
				}




			}

			if(Alerted){
				rb = transform.GetComponent<Rigidbody2D> ();
				if(rb.bodyType == RigidbodyType2D.Dynamic){
					if (Vector2.Distance(transform.position, Player.position) >= MinDist){
						transform.position = Vector3.Lerp (transform.position, new Vector2(Player.position.x, Player.position.y), Time.deltaTime*MoveSpeed);
						anim.SetFloat("Mov", transform.position.x);
						if (Vector2.Distance(transform.position, Player.position) <= MaxDist){



						}
					}
				} 
			}
		}
	}
}
