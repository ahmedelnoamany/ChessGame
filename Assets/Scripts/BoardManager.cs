using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class BoardManager : MonoBehaviour {

	public GameObject blackTile;		//to hold black tile 
	public GameObject whiteTile;		//to hold white tile
	public GameObject[] whiteTeam;		//to hold white team chess pieces
	public GameObject[] blackTeam;		//to hold black team chess pieces


	private static int columns = 8;		//board size. columns x rows
	private static int rows = 8;
	private Transform boardHolder;		//to keep the hierarchy clean.
	private Transform pieces;
	//private List <Vector3> gridPositions = new List<Vector3>();		//all board positions.

	
	//Called by the GameManager in order to set up the gameBoard
	public void SetupGame () {

		SetBoard ();
		SetBoardPieces ();

		
	}

	//Called by SetupGame(). Sets up the board tiles.
	void SetBoard(){

		boardHolder = new GameObject ("Board").transform;		//setting boardHolder to transform of Board GameObject.
		GameObject toInstantiate;		//what we will be instantiating.
		for(int i = 0; i < columns; i++){
			for (int j = 0; j < rows; j++) {
				if (i % 2 == 0) {		//This is an odd column 
					if(j % 2 == 0){		//this is an odd row
						toInstantiate = blackTile;
					}
					else{
						toInstantiate = whiteTile;
					}
				}
				else{	//this is an even column
					if(j % 2 == 0){
						toInstantiate = whiteTile;
					}
					else{
						toInstantiate = blackTile;
					}
				}
				GameObject instance = Instantiate (toInstantiate, new Vector3 (i, j, 0f), Quaternion.identity) as GameObject;	//instantiating tile at position i, j.
				instance.transform.SetParent (boardHolder);		//putting instantiated gameObject under boardHolder to keep it clean.
			}
		}
	}

	//Called by SetupGame(). Sets up the board pieces.
	void SetBoardPieces(){
		pieces = new GameObject ("Pieces").transform;

		for(int i = 0; i < whiteTeam.Length; i++){

			if (i == 0) { //Pawns bro!!!!
				GameObject whiteInstantiate = whiteTeam [i];
				GameObject blackInstantiate = blackTeam [i];
				for (int j = 0; j < columns; j++) {
					GameObject wpawn = Instantiate (whiteInstantiate, new Vector3 (1, j, 0f), Quaternion.identity) as GameObject;
					wpawn.transform.SetParent (pieces);
					GameObject bpawn = Instantiate (blackInstantiate, new Vector3 (6, j, 0f), Quaternion.identity) as GameObject;
					bpawn.transform.SetParent (pieces);
				}
			} else {
				GameObject wpiece = Instantiate (whiteTeam [i], new Vector3 (0, i - 1, 0f), Quaternion.identity) as GameObject;		//instantiating white pieces
				wpiece.transform.SetParent (pieces);
				GameObject bpiece = Instantiate (blackTeam [i], new Vector3 (7, i - 1, 0f), Quaternion.identity) as GameObject;		//instantiating black pieces
				bpiece.transform.SetParent (pieces);

				if (i < whiteTeam.Length - 2) {	//if not king or queen then make another copy of it.
					GameObject wpiece2 = Instantiate (whiteTeam [i], new Vector3 (0, 8 - i, 0f), Quaternion.identity) as GameObject;
					wpiece2.transform.SetParent (pieces);
					GameObject bpiece2 = Instantiate (blackTeam [i], new Vector3 (7, 8 - i, 0f), Quaternion.identity) as GameObject;
					bpiece2.transform.SetParent (pieces);
				}
			}
		}
	}
}
