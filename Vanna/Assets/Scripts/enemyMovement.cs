using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyMovement : MonoBehaviour {

	public float moveSpeed;

	public Transform start;
	public Transform end;

	private Rigidbody2D myRigidBody;

	public bool movingToEnd;

	// Use this for initialization
	void Start () {
		myRigidBody = GetComponent<Rigidbody2D> ();
		
	}
	
	// Update is called once per frame
	void Update () {
		if (movingToEnd && transform.position.x > end.position.x) 		//pohyb nepritele k bodu konec, pokud je jeho x hodnota mensi jak hodnoa x konce
		{
			movingToEnd = false;										//pokud je hodnota x nepritele = x konce, nepohybujeme se ke konci
		}
		if (!movingToEnd && transform.position.x < start.position.x) 	//pohyb nepritele k bodu start, pokud je jeho x hodnota mensi jak hodnoa x start
		{
			movingToEnd = true;											//pokud je hodnota x nepritele = x start, nepohybujeme se ke startu
		}
		if (movingToEnd) {
			myRigidBody.velocity = new Vector3 (moveSpeed, myRigidBody.velocity.y, 0f);		//pohyb vpred
			transform.localScale = new Vector3 (1f, 1f, 1f);								//smer pohledu nepritele
		} else 
		{
			myRigidBody.velocity = new Vector3 (-moveSpeed, myRigidBody.velocity.y, 0f);	//pohyb vzad
			transform.localScale = new Vector3 (-1f, 1f, 1f);								//smer pohledu nepritele
		}		
		
	}
}
