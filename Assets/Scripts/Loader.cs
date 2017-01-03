using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loader : MonoBehaviour {

	//Loader Placed on camera

	public GameObject gameManager;	//to hold our GameManager object
	
	// Update is called once per frame
	void Awake () {
		if(GameManager.instance == null){	//if we dont have a gameManager object...instantiate it.
			Instantiate (gameManager);
		}
		
	}
}
