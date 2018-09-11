using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyExplosion : MonoBehaviour {

	public  GameObject explosion;

	private ScoreController scoreControllerScript;

	private string scoreControllerName = "ScoreController";

	private string collisionGameObjectName = "Witch";

	private string witchDeathSoundController = "WitchDeathSound";

	private AudioSource witchDeathSound;

	private void Start(){
		collisionGameObjectName = gameObject.name.Replace("(Clone)","");
		scoreControllerScript = GameObject.Find (scoreControllerName).GetComponent<ScoreController>();
		witchDeathSound = GameObject.Find (witchDeathSoundController).GetComponent<AudioSource>();
	}
	
	void OnTriggerEnter2D(Collider2D other){
		string gameObjectName = other.gameObject.name as string;
		if (gameObjectName.Contains("bullet")) {
			PlayDeathSound ();
			scoreControllerScript.IncreaseScore (collisionGameObjectName);
			Destroy (other.gameObject);
			Destroy (gameObject);
			GameObject expl = Instantiate(explosion, transform.position, Quaternion.identity) as GameObject;
			Destroy (expl,1);
		}
	} 

	private void PlayDeathSound() {
		witchDeathSound.Play ();
	}

}