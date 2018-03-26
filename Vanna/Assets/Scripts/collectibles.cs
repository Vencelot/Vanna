using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collectibles : MonoBehaviour {



	public int energyCrystalsValue;

	private levelManager myLevelManager;

	// Use this for initialization
	void Start () {
		myLevelManager = FindObjectOfType<levelManager> ();
	}
	
	// Update is called once per frame
	void Update () {
		
		
	}

	void OnTriggerEnter2D (Collider2D other)			//sbirani veci
	{
		if (other.tag == "Player") 
		{
			gameObject.SetActive(false);
			myLevelManager.AddCrystals (energyCrystalsValue); 	//pridani hodnoty krystalu
			//Destroy(gameObject);								//zniceni objektu

		}
	}
}
