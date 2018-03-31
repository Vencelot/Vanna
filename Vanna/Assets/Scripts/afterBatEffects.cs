using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class afterBatEffects : MonoBehaviour {

	private batActive myBatActive;
	public GameObject movingPlatform;
	public GameObject caveSpikes;

	// Use this for initialization
	void Start () {
		myBatActive = FindObjectOfType<batActive> ();
		movingPlatform.SetActive (false);
		caveSpikes.SetActive (true);
	
	}
	
	// Update is called once per frame
	void Update () {
		if (myBatActive.batActivated == true) 
		{
			movingPlatform.SetActive (true);
			caveSpikes.SetActive(false);
		}
		
	}
}
