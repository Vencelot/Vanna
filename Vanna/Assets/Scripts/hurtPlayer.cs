using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hurtPlayer : MonoBehaviour {

	public levelManager myLevelManager;
	public int damageToGive;
	public float bounceForce;

	public GameObject thePlayer;



	// Use this for initialization
	void Start () {
		myLevelManager = FindObjectOfType<levelManager> ();

		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D (Collider2D other) 
		{
		if (other.tag == "Player") 
			{
				//myLevelManager.Respawn ();
				myLevelManager.HurtPlayer(damageToGive);
				
			}
		}	
}
