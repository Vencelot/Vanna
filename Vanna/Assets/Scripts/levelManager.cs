using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class levelManager : MonoBehaviour {


	public float waitToRespawn;
	public playerMovement thePlayer;
	public int energyCrystalsCount;


	public Text energyCrystalText;

	public Image heart1;
	public Image heart2;
	public Image heart3;

	public Sprite fullHeart;
	public Sprite halfHeart;
	public Sprite emptyHeart;

	public int maxHealth;
	public int healthCount;

	public bool respawning;
	public BoxCollider2D currentBoxCollider2D;

	public resetOnRespawn [] objectsToReset;

	// Use this for initialization
	void Start () {
		thePlayer = FindObjectOfType <playerMovement> ();
		currentBoxCollider2D = thePlayer.GetComponent<BoxCollider2D> ();
		energyCrystalText.text = " ";
		healthCount = maxHealth;
		objectsToReset = FindObjectsOfType<resetOnRespawn> ();
	

		
	}
	
	// Update is called once per frame
	void Update () {
		if (healthCount <= 0 && !respawning) 	//osetreni smrti a znovu zrozeni pri 0 health a respawnovani pouze kdyz je to dovoleno
		{
			Respawn ();
			respawning = true;
			currentBoxCollider2D.size = new Vector3 (0.19f,0.38f,0f);
			currentBoxCollider2D.offset = new Vector3 (-0.1f, -0.02f, 0f);

		}
	
			
	}

	public void Respawn () {

		StartCoroutine (RespawnCo());

	}

	public IEnumerator RespawnCo () 							//coroutine která zajišťuje prodlevu mezí deaktivací a aktivací hráče
		{
			thePlayer.gameObject.SetActive (false);

			yield return new WaitForSeconds(waitToRespawn);		//čekání vyměřeného času
			
			healthCount = maxHealth;							//obnovení životu
			respawning	= false;
			energyCrystalText.text = " ";
			energyCrystalsCount = 0;
			updateHeartMeter ();
			
			
			

			thePlayer.transform.position = thePlayer.respawnPoint; 	//respawnuti hrace na miste checkpointu
			thePlayer.gameObject.SetActive (true);					//opetne aktivovani hrace+

		for(int i = 0; i < objectsToReset.Length; i++)
			{
				objectsToReset[i].gameObject.SetActive(true);
				objectsToReset[i].ResetObject();
			}
		}
		
	public void AddCrystals(int energyCrystalsToAdd)				//zapocitani a vypsani poctu sebranych krystalu
	{
		energyCrystalsCount += energyCrystalsToAdd;					//zapocitani soucasneho poctu krystalu
		energyCrystalText.text = "      " + energyCrystalsCount;	//vypsani poctu
	}

	public void HurtPlayer(int damageToTake)			//odebirani zivotu hraci
	{
		healthCount -= damageToTake;					//odeberani zivotu
		updateHeartMeter ();
		thePlayer.Knockback (); 						//volani funkce knockback pri zraneni hrace
	}

	public void updateHeartMeter()			//zmena sprite image srdce
	{
		switch (healthCount) 
		{
		case 6:
			heart3.sprite = fullHeart;
			heart2.sprite = fullHeart;
			heart1.sprite = fullHeart;
			return;

		case 5:
			heart3.sprite = halfHeart;
			heart2.sprite = fullHeart;
			heart1.sprite = fullHeart;
			return;

		case 4:
			heart3.sprite = emptyHeart;
			heart2.sprite = fullHeart;
			heart1.sprite = fullHeart;
			return;

		case 3:
			heart3.sprite = emptyHeart;
			heart2.sprite = halfHeart;
			heart1.sprite = fullHeart;
			return;

		case 2:
			heart3.sprite = emptyHeart;
			heart2.sprite = emptyHeart;
			heart1.sprite = fullHeart;
			return;

		case 1:
			heart3.sprite = emptyHeart;
			heart2.sprite = emptyHeart;
			heart1.sprite = halfHeart;
			return;

		case 0:
			heart3.sprite = emptyHeart;
			heart2.sprite = emptyHeart;
			heart1.sprite = emptyHeart;
			return;

		default:
			heart3.sprite = emptyHeart;
			heart2.sprite = emptyHeart;
			heart1.sprite = emptyHeart;
			return;
			
		}					

	}






}

