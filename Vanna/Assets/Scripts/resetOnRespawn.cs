﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class resetOnRespawn : MonoBehaviour {

	private Vector3 startPosition;
	private Quaternion startRotation;
	private Vector3 startLocalScale;

	private Rigidbody2D myRigidbody;

	// Use this for initialization
	void Start () {
		startPosition = transform.position;				//ulozeni startovnich pozic
		startRotation = transform.rotation;
		startLocalScale = transform.localScale;

			if(GetComponent<Rigidbody2D>() != null)		//vybirani Rigidbody objektu, ktere ho maji
			{
				myRigidbody = GetComponent<Rigidbody2D> ();
			}
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void ResetObject() 
	{
		transform.position = startPosition;		
		transform.rotation = startRotation;
		transform.localScale = startLocalScale;

		if (myRigidbody != null) 
		{
			myRigidbody.velocity = Vector3.zero;
		}
	}
}
