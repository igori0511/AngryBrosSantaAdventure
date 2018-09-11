using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoyMovement : MonoBehaviour {

	[SerializeField]
	private float speedY = 0.2f;
	private Rigidbody2D myBody;
	private float offset = 0.2f;

	// down true 
	// up false
	private bool direction = true;

	// Use this for initialization
	void Start () {
		myBody = GetComponent<Rigidbody2D>();
		myBody.freezeRotation = true;
	}

	// Update is called once per frame
	void FixedUpdate () {

		float forceX = 0.0f;
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

		//Vector2 force = new Vector2 (forceX, forceY);
		//myBody.AddForce (force);
		myBody.velocity = new Vector2(forceX, forceY * 3.0f);
		transform.position = new Vector2(transform.position.x, Mathf.Clamp(transform.position.y, 0, Camera.main.orthographicSize + offset));
	}

	private bool reachedMaxBoundariesYMin(float y) {
		return y < .0f ? true : false;
	}

	private bool reachedMaxBoundariesYMax(float y) {
		return y > Camera.main.orthographicSize + offset;
	}
}
