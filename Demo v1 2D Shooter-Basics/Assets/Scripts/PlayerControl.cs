using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour {

	//How fast Ro can go
	public float topspeed = 4f;
	Animator anim;
	const float timeout = 4.0f;
	float countdown = timeout;
	bool idle = false;
	public Rigidbody2D bullet;
	public float maxSpeed = 25f;


	void Start(){
		anim = GetComponent<Animator> ();
	}
	void Update(){
		PlayerDies player = GetComponent<PlayerDies> ();	
		bool life = player.GetLife ();
		if (life) {
			Vector3 mov = new Vector3 (
				Input.GetAxisRaw("Horizontal"),
				Input.GetAxisRaw("Vertical"),
				0
			);
			transform.position = Vector3.MoveTowards (

				transform.position,
				transform.position+ mov,
				topspeed * Time.deltaTime

			);

			anim.SetFloat ("Mov_x", mov.x);
			anim.SetFloat("Mov_y", mov.y);




			//codigo del Idle
			if(!idle)
			{
				if(mov != Vector3.zero)
					countdown = timeout;

				if(countdown <= 0.0f)
				{
					idle = true;
				}
				countdown -= Time.deltaTime;
			}
			else
			{
				if(mov != Vector3.zero)
				{
					idle = false;
					countdown = timeout;
					anim.SetBool("Active", true);
				}else{
					anim.SetBool("Active", false);
				}
			}


			if (Input.GetButtonDown("Fire1")) {

				//...setting shoot direction
				Vector3 shootDirection;
				shootDirection = Input.mousePosition;
				shootDirection.z = 0.0f;
				shootDirection = Camera.main.ScreenToWorldPoint(shootDirection);
				shootDirection = shootDirection-transform.position;
				//...instantiating the rocket
				Rigidbody2D bulletInstance = Instantiate(bullet, transform.position, Quaternion.Euler(new Vector3(transform.eulerAngles.x,transform.eulerAngles.y,transform.eulerAngles.z))) as Rigidbody2D;
				bulletInstance.velocity = new Vector2(shootDirection.x * maxSpeed, shootDirection.y * maxSpeed);
				anim.Play("Shoot");
			}
		}

			

	}
}
