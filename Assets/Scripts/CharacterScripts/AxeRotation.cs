using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxeRotation : MonoBehaviour {

	public float rotationsPerMinute = 10.0f;

	// Update is called once per frame
	void FixedUpdate () {
		transform.Rotate( new Vector3( 0,0, 30 ));
	}
}
