using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PieceMovement : MonoBehaviour {	

	public float moveTime = 0.1f;	//how long it takes to move a piece.
	public LayerMask GameLayer;		//collisions happen here.

	private BoxCollider2D boxCollider;
	private Rigidbody2D rigidBody;

	// Use this for initialization
	protected virtual void Start () {	//virtual so it can be overwritten by children
		boxCollider = GetComponent<BoxCollider2D> ();
		rigidBody = GetComponent<Rigidbody2D> ();
	}


}
