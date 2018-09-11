using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoyBossMovement : MonoBehaviour {

	[SerializeField]
	private float speedY = 0.5f;
	private Rigidbody2D myBody;
	private float offset = 0.4f;
	private GameObject player;
	private Rigidbody2D playerRigidBody;

	// down true 
	// up false
	private bool direction = true;

	// Use this for initialization
	void Start () {
		myBody = GetComponent<Rigidbody2D>();
		myBody.freezeRotation = true;
		player = GameObject.FindGameObjectWithTag("PlayerTag");
		playerRigidBody = player.GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		
		//float forceX = 0.0f;
		float forceY = 0.0f;

		if (!reachedMaxBoundariesYMax (transform.position.y) && !direction) {
			forceY = speedY;
			direction = false;
		} else {
			direction = true;
		}

		if (!reachedMaxBoundariesYMin (transform.position.y) && direction) {
			forceY = -speedY;
			direction = true;
		} else {
			direction = false;
		}

		/*if (playerRigidBody.velocity.x > myBody.velocity.x) {
			forceX = 0.5f;
		}*/

		//Vector2 force = new Vector2 (forceX, forceY);

		//myBody.AddForce (force);
		if (playerRigidBody) {
			myBody.velocity = new Vector2 (playerRigidBody.velocity.x, forceY * 2.0f);
		}
		
		transform.position = new Vector2(transform.position.x, Mathf.Clamp(transform.position.y, 0, Camera.main.orthographicSize + offset));
	}

	private bool reachedMaxBoundariesYMin(float y) {
		return y < 2.0f ? true : false;
	}

	private bool reachedMaxBoundariesYMax(float y) {
		return y > Camera.main.orthographicSize + offset;
	}
}
