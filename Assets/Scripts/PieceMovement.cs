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
		boxCollider = GetComponent<BoxCollider2D> ();
		rigidBody = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
//		if(Input.GetMouseButtonDown(0))
//		{
//			Debug.Log(Input.mousePosition);
//		}
		if ( Input.GetMouseButtonDown (0)){ 
//			RaycastHit2D hit; 
//			Vector2 start = Input.mousePosition;
//			Vector2 end = Input.mousePosition;
//			hit = Physics2D.Raycast (start, , GameLayer);

			Vector2 rayPos = new Vector2 (Camera.main.ScreenToWorldPoint (Input.mousePosition).x, Camera.main.ScreenToWorldPoint (Input.mousePosition).y);
			RaycastHit2D hit = Physics2D.Raycast (rayPos, Vector2.zero, 0f);

			if(hit){
				Debug.Log (hit.transform.name);
			}
		}
	}
}
