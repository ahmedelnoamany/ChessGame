using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PieceMovement : MonoBehaviour {	

	public float moveTime = 0.1f;	//how long it takes to move a piece.
	public LayerMask GameLayer;	//collisions happen here.
	public LayerMask BoardLayer;

	private BoxCollider2D boxCollider;
	private Rigidbody2D rigidBody;
	private Renderer spriteRenderer;
	private GameObject selected;
	private GameObject secondSelected;
	private bool alreadySelected = false;

	// Use this for initialization
	void Start () {
		//boxCollider = GetComponent<BoxCollider2D> ();
		//rigidBody = GetComponent<Rigidbody2D> ();
		//spriteRenderer = GetComponent<Renderer> ();
	}
	
	// Update is called once per frame
	void Update () {
		if ( Input.GetMouseButtonDown (0)){ 
			Vector2 rayPos = new Vector2 (Camera.main.ScreenToWorldPoint (Input.mousePosition).x, Camera.main.ScreenToWorldPoint (Input.mousePosition).y);
			RaycastHit2D hit = Physics2D.Raycast (rayPos, Vector2.zero, 0f);
			if(hit){
				Debug.Log (hit.transform.name);
				Debug.Log (hit.transform.position);
				if (!alreadySelected) {
					selected = hit.collider.gameObject;
					Test (selected);
				}
				else{
					secondSelected = hit.collider.gameObject;
					Test (secondSelected);
				}
			}
		}
	}

	void Test(GameObject go){
		
		spriteRenderer = go.GetComponent<Renderer> ();
		if (!alreadySelected) {
			spriteRenderer.material.color = Color.blue;
			alreadySelected = true;
		}
		else{
			
			
			
			
		}
	}
}
