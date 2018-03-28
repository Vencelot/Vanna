using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraMovement : MonoBehaviour {

	public GameObject player;
	private Vector3 playerPosition;
	public float followAhead;
	public float smoothing;

	public bool border;

	public float maxX;
	public float minX;

	public float maxY;
	public float minY;


	// Use this for initialization
	void Start ()
	{
		border = true;

	}

	// Update is called once per frame
	void FixedUpdate () 
		{
		playerPosition = new Vector3 (player.transform.position.x, player.transform.position.y, transform.position.z);	//kamera bude sledovat a nasledovat pozici hrace

			if (player.transform.localScale.x > 0f) 
		{ 		//pohyb kamera pred hrace
				playerPosition = new Vector3 (playerPosition.x + followAhead, playerPosition.y, transform.position.z);
					} else {
				playerPosition = new Vector3 (playerPosition.x - followAhead, playerPosition.y, transform.position.z);	
				}
					
		if (border == true) 
		{
			transform.position = new Vector3 (Mathf.Clamp(transform.position.x,minX,maxX), Mathf.Clamp(transform.position.y, minY, maxY), transform.position.z);
		}		
			
			transform.position = Vector3.Lerp (transform.position, playerPosition, smoothing * Time.deltaTime); 	//plynuly prechod kamery pri pohybu ze strany na stranu
	}

		

			
}
