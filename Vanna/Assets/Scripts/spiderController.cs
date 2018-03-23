using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spiderController : MonoBehaviour {

	private Rigidbody2D myRigidBody;

	public float moveSpeed;
	public bool canMove;
	//private Animator myAnimator;

	// Use this for initialization
	void Start () {
		myRigidBody = GetComponent<Rigidbody2D> ();
		//myAnimator = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (canMove)
		{
			myRigidBody.velocity = new Vector3 (-moveSpeed, myRigidBody.velocity.y, 0f);
		}
			
	}

	void OnBecameVisible () 
	{
		canMove = true;
	}

	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.tag == "Kill Plane")
		{

			Destroy (gameObject);
		}	
	}
}
