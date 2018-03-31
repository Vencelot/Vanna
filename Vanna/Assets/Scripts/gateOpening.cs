using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gateOpening : MonoBehaviour {


	public batActive myBatActive;
	private Animator myAnim;

	// Use this for initialization
	void Start () {
		myBatActive = FindObjectOfType<batActive> ();
		myAnim = GetComponent<Animator> ();
	}

	// Update is called once per frame
	void Update () {
		myAnim.SetBool ("batActive", myBatActive.batActivated);
		
	}


}
