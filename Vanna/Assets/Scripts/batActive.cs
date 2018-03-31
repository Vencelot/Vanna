using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class batActive : MonoBehaviour {

	public bool batActivated;

	// Use this for initialization
	void Start () {
		batActivated = false;
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Player")
		{
			batActivated = true;
		}	
	}
}
