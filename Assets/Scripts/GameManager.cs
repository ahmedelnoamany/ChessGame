using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	public static GameManager instance = null;		//instance of GameManager.
	public BoardManager boardScript;		//to store our boardManager script.
	public PieceMovement movePiece;		//for the piecemovemnt script so we can move the pieces.
	public bool whoseTurn = true;	//white turn = true. Black turn = false.

	private bool settingUp;		//true if setting up the game. False otherwise.
	private BoxCollider2D boxCollider;		//reference to box collider
	private Rigidbody2D rigidBody;			//reference to rigidbody
	private Renderer spriteRenderer;		//reference to renderer
	private GameObject selected;			//reference to piece object selected
	private bool alreadySelected = false;	//false if first selection, true once you select another piece

	// Called when the script instance is being loaded.
	void Awake () {
		if(instance == null){	//only 1 GameManager. If this instance is not the GameManager then destroy it.
			instance = this;
		}
		else if(instance != this){
			Destroy (gameObject);
		}
		DontDestroyOnLoad (gameObject);	//dont destroy the GameManager on loads.
		boardScript = GetComponent<BoardManager> ();	//Getting reference to BoardManager
		InitGame ();
	}
	void Update () {
		if ( Input.GetMouseButtonDown (0)){ 		//if left mouse is clicked
			Vector2 rayPos = new Vector2 (Camera.main.ScreenToWorldPoint (Input.mousePosition).x, Camera.main.ScreenToWorldPoint (Input.mousePosition).y);	//position of click
			RaycastHit2D hit = Physics2D.Raycast (rayPos, Vector2.zero, 0f);	//casting ray from mouse position to 0,0 to see if a piece has been hit.
			if(hit){
				Debug.Log (hit.transform.name);
				Debug.Log (hit.transform.position);
				Selection (hit);	//calling selection method
			}
		}
	}

	//Piece selected Logic
	void Selection(RaycastHit2D hit){

		if (alreadySelected) {	//if another piece has been selected, unhighlight the first.
			spriteRenderer.material.color = Color.white;
		}
		selected = hit.collider.gameObject;		//get reference to the gameObject that has been clicked on.
		spriteRenderer = selected.GetComponent<Renderer> ();	//get reference to the renderer.
		if (WhosTurn () == true && hit.transform.tag == "WhiteTeam") {	//whites turn. check piece tag only allow white to be selected.
			HighlightSelection (selected);	
		} 
		if(WhosTurn() == false && hit.transform.tag == "BlackTeam"){	//blacks turn. only allow black pieces to be selected.
				HighlightSelection (selected);
		}
	}
	//Highlight selected piece	
	void HighlightSelection(GameObject go){
		spriteRenderer.material.color = Color.blue;		//set the color to blue
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
