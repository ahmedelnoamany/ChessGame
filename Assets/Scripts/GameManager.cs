using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	public static GameManager instance = null;		//instance of GameManager.
	public BoardManager boardScript;		//to store our boardManager script.

	public bool whoseTurn;	//white turn = true. Black turn = false.

	private bool settingUp;		//true if setting up the game. False otherwise.
	private BoxCollider2D boxCollider;
	private Rigidbody2D rigidBody;
	private Renderer spriteRenderer;
	private GameObject selected;
	private GameObject secondSelected;
	private bool alreadySelected = false;	//if a piece has already been selected



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
	void Update () {
		if ( Input.GetMouseButtonDown (0)){ 
			Vector2 rayPos = new Vector2 (Camera.main.ScreenToWorldPoint (Input.mousePosition).x, Camera.main.ScreenToWorldPoint (Input.mousePosition).y);
			RaycastHit2D hit = Physics2D.Raycast (rayPos, Vector2.zero, 0f);
			if(hit){
				Debug.Log (hit.transform.name);
				Debug.Log (hit.transform.position);
				Selection (hit);
			}
		}
	}

	//Piece selected Logic
	void Selection(RaycastHit2D hit){

		if (alreadySelected) {	//if another piece has been selected, unhighlight the first.
			spriteRenderer.material.color = Color.white;
		}
		selected = hit.collider.gameObject;
		spriteRenderer = selected.GetComponent<Renderer> ();
		if (WhosTurn () == true && hit.transform.tag == "WhiteTeam") {	//whites turn. check piece tag only allow white to be selected.
			HighlightSelection (selected);	
		} 
		if(WhosTurn() == false && hit.transform.tag == "BlackTeam"){
				HighlightSelection (selected);
		}
	}
	//Highlight selected piece	
	void HighlightSelection(GameObject go){
		spriteRenderer.material.color = Color.blue;
		alreadySelected = true;
		}

	bool WhosTurn(){
		if (whoseTurn == true)
			return true;	//white
		return false;	//black
	}

	//Called by Awake(). Initializes the game by the GameManager.
	void InitGame(){
		settingUp = true;
		boardScript.SetupGame ();
		
	}
	

}
