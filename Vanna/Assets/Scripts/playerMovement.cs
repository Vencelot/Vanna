using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class playerMovement : MonoBehaviour {

	private Rigidbody2D myRigidBody;
	private Animator myAnim;
	private Checkpoint myCheckpoint;
	public	levelManager myLevelManager;

	public float movementSpeed;
	public float jumpPower;


	public Transform groundCheck;
	public float groundCheckRadius;
	public LayerMask whatIsGround;
	public bool isGrounded;

	public Vector3 respawnPoint;








	void Start () 
		{
			myRigidBody = GetComponent<Rigidbody2D>();				//získání komponentu z Rigidbody2d
			myAnim = GetComponent<Animator>();						//ziskani komponentu z Animatoru
			respawnPoint = transform.position;						//ulozeni zakladni respawn pozice
			myLevelManager = FindObjectOfType <levelManager>();		//ziskani objektu typu levelManager
			
		}


	// Update is called once per frame
	void Update () {

		//pohyb hrace
											//kontrola pozice	-	kontrola okolí 	-	kontrola zda je pod ním zem			
		isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround); //určení zda hráč stojí na zemi nebo ne


		if (Input.GetAxisRaw ("Horizontal") > 0f) 				//kontrola zda je hodnota x větší než 0 - pohyb vpravo
			{
				myRigidBody.velocity = new Vector3 (movementSpeed, myRigidBody.velocity.y, 0f);
				transform.localScale = new Vector3 (1f, 1f, 1f); //smer hrace pri pohybu vpred (otoceni)
			}
		else if (Input.GetAxisRaw ("Horizontal") < 0f) 			//kontrola zda je hodnota x menší než 0 - pohyb vlevo
			{
				myRigidBody.velocity = new Vector3 (-movementSpeed, myRigidBody.velocity.y, 0f);
				transform.localScale = new Vector3 (-1f, 1f, 1f); //smer hrace pri pohybu vzad (otoceni)
			}
		else 													//pokud se hodnota rovná 0 - charakter stojí
			{
				myRigidBody.velocity = new Vector3 (0f, myRigidBody.velocity.y, 0f);
			}

		if (Input.GetButton ("Jump") && isGrounded) 							//pokud je zmáčknutí tlačítko pro skok, hráč vyskočí
			{
			myRigidBody.velocity = new Vector3 (myRigidBody.velocity.x, jumpPower, 0f);
			}	



		//animace hrace
			myAnim.SetFloat ("Speed", Mathf.Abs (myRigidBody.velocity.x));
			myAnim.SetBool ("Grounded", isGrounded);


	}
		//deaktivuje hraje po srazce s timto objektem
	void OnTriggerEnter2D (Collider2D other)
		{
		if (other.tag == "Kill Plane")
			{
				
			myLevelManager.Respawn();								//odkaz na funcki Respawn v levelManageru
			}	

		if (other.tag == "Checkpoint")
			{
				respawnPoint = other.transform.position;						//hracova nova pozice znovuzrozeni
			}	
		}

	void OnCollisionEnter2D (Collision2D other)
	{
		if (other.gameObject.tag == "MovingPlatform") 
		{
			transform.parent = other.transform;
		}	
	}

	void OnCollisionExit2D (Collision2D other)
	{
		if (other.gameObject.tag == "MovingPlatform")
		{
			transform.parent = null;							
		}	
	}
}
