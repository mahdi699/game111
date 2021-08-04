using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

	float moveSpeed = 7f;

	Rigidbody2D rb;

	playatwo target;
	Vector2 moveDirection;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
		target = GameObject.FindObjectOfType<playatwo>();
		moveDirection = (target.transform.position - transform.position).normalized * moveSpeed;
		rb.velocity = new Vector2 (moveDirection.x, moveDirection.y);
		
	}

	void OnTriggerEnter2D (Collider2D col)
	{
		if (col.transform.tag ==  "player2") {
			Debug.Log ("Hit!");
			Destroy (gameObject);
		}else 
			if (col.transform.tag == "boxx")
		{
			Destroy(gameObject);
		}
	}

}
