using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PieceMovement : MonoBehaviour {	

	public float moveTime = 0.1f;	//how long it takes to move a piece.
	public LayerMask GameLayer;	//collisions happen here.

	private BoxCollider2D boxCollider;
	private Rigidbody2D rigidBody;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
