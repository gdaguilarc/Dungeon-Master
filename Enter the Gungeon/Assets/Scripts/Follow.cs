     using System.Collections;
     using System.Collections.Generic;
     using UnityEngine;
     using UnityEngine.UI;
     public class Follow : MonoBehaviour
     {
     
         public Transform Player;
         public int MoveSpeed = 5;
         public int MaxDist = 10;
         public int MinDist = 2;
		 Animator anim;
	Rigidbody2D rb;
		 
     
		
     
     
         void Start()
         {
			anim = GetComponent<Animator> ();
         }
     
         void Update()
         {
			rb = transform.GetComponent<Rigidbody2D> ();
		if(rb.bodyType == RigidbodyType2D.Dynamic){
			if (Vector2.Distance(transform.position, Player.position) >= MinDist)
			{

				transform.position = Vector3.Lerp (transform.position, new Vector2(Player.position.x, Player.position.y), Time.deltaTime*MoveSpeed);
				anim.SetFloat("Mov", transform.position.x);
				//transform.forward * MoveSpeed * Time.deltaTime;



				if (Vector2.Distance(transform.position, Player.position) <= MaxDist)
				{
					//Here Call any function U want Like Shoot at here or something
				}

			}
		}
            
         }
     }
     