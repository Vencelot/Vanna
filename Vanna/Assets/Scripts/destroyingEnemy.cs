using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyingEnemy : MonoBehaviour {

	private Rigidbody2D playerRigidbody;

	public float bounceForce;
	// Use this for initialization
	void Start () {
		playerRigidbody = transform.parent.GetComponent<Rigidbody2D> ();
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Enemy") 
		{
			
			Destroy (other.gameObject);
			playerRigidbody.velocity = new Vector3 (playerRigidbody.velocity.x, bounceForce, 0f);
		}
			
	}
}
