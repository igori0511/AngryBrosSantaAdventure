using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenericEffects : MonoBehaviour {

	public  GameObject targetEffect;
	public  float destroyTime;
	public string axeDestroyController= "AxeHitSound";
	private AudioSource axeDestroySound;

	private void Start(){
		axeDestroySound = GameObject.Find (axeDestroyController).GetComponent<AudioSource>();
	}
	
	void OnTriggerEnter2D(Collider2D other){
		string gameObjectName = other.gameObject.name as string;
		if (gameObjectName.Contains("Player")) {
			PlayDeathSound ();
			GameObject expl = Instantiate(targetEffect, transform.position, Quaternion.identity) as GameObject;
			Destroy (gameObject);
			Destroy (expl, destroyTime);
		}
	} 

	private void PlayDeathSound() {
		axeDestroySound.Play ();
	}

}