using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class newLevelEnter : MonoBehaviour {

	public bool level2Enter;

	// Use this for initialization
	void Start () {
		level2Enter = false;
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Player") 
		{
			level2Enter = true;
		}
	}
}
