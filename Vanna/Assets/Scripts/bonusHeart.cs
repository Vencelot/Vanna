using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bonusHeart : MonoBehaviour {
	
	public int healthToGive;

	private levelManager myLevelManager;

	// Use this for initialization
	void Start () {
		myLevelManager = FindObjectOfType<levelManager> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Player") 
		{
			myLevelManager.BonusHeart(healthToGive);
			gameObject.SetActive (false);
		}


	}
}
