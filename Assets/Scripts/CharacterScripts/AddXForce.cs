using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddXForce : MonoBehaviour {

	[SerializeField]
	private float speedX = 8.0f, maxVelocityX = 4.0f;
	private Rigidbody2D myBody;

	// Use this for initialization
	private void Awake() {
		myBody = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {

		if (Time.timeScale > 0) {
		
			float forceX = 0.0f;
			float velocityX = Mathf.Abs (myBody.velocity.x);

			//right 
			if (velocityX < maxVelocityX) {
				forceX = speedX;
			} 

			Vector2 force = new Vector2 (forceX, 0.0f);
			myBody.AddForce (force);
		}
	}
}
