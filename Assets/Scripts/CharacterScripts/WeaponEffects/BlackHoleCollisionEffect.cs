using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackHoleCollisionEffect : MonoBehaviour {

	private float deltaRotation = 500.0f;
	public  Rigidbody2D targetEffect;
	public  float destroyTime;
	public AudioSource blackHoleEffect;
	private bool alreadyPlayed = false;

	private void Start(){
	}

	void OnTriggerEnter2D(Collider2D other){
		string gameObjectName = other.gameObject.name as string;
		if (gameObjectName.Contains("BlackHole") && !other.usedByEffector) {
			if (!blackHoleEffect.isPlaying && !alreadyPlayed) {
				blackHoleEffect.Play ();
			}
			Rigidbody2D expl = Instantiate (targetEffect, other.transform.position, Quaternion.Euler (new Vector3 (0, 0, 30)));
			expl.AddTorque(deltaRotation);
			Destroy (expl, destroyTime);
			alreadyPlayed = true;
		}
	} 

}