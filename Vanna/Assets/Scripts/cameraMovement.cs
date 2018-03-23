using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraMovement : MonoBehaviour {

	public GameObject player;
	private Vector3 playerPosition;
	public float followAhead;
	public float smoothing;


	// Use this for initialization
	void Start ()
	{
		
	}
	
	// Update is called once per frame
	void Update () 
		{
		playerPosition = new Vector3 (player.transform.position.x, transform.position.y, transform.position.z);	//kamera bude sledovat a nasledovat pozici hrace

			if (player.transform.localScale.x > 0f) 		//pohyb kamera pred hrace
				{
					playerPosition = new Vector3 (playerPosition.x + followAhead, playerPosition.y, playerPosition.z);
				} else
				{
					playerPosition = new Vector3 (playerPosition.x - followAhead, playerPosition.y, playerPosition.z);	
				}

			
		transform.position = Vector3.Lerp (transform.position, playerPosition, smoothing * Time.deltaTime); 	//plynuly prechod kamery pri pohybu ze strany na stranu


		}

		
}
