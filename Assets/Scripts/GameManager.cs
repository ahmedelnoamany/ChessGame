using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	public static GameManager instance = null;		//instance of GameManager.
	public BoardManager boardScript;		//to store our boardManager script.

	[HideInInspector]
	public bool whoseTurn = true;	//white turn = true. Black turn = false.

	private bool settingUp;		//true if setting up the game. False otherwise.




	// Called when the script instance is being loaded.
	void Awake () {
		if(instance == null){	//only 1 GameManager. If this instance is not the GameManager then destroy it.
			instance = this;
		}
		else if(instance != this){
			Destroy (gameObject);
		}
		DontDestroyOnLoad (gameObject);
		boardScript = GetComponent<BoardManager> ();	//Getting reference to BoardManager
		InitGame ();
	}

	//Called by Awake(). Initializes the game by the GameManager.
	void InitGame(){
		settingUp = true;
		boardScript.SetupGame ();
		
	}
	

}
