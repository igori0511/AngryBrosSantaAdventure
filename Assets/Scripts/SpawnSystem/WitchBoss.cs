using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpawnSystem {
	public class WitchBoss : MonoBehaviour {

		private Rigidbody2D enemyToSpawn;
		private float startWait = 1.0f;
		public  GameObject explosion;
		public static bool isBossAlive = true;
		public int numberOfCollisionsBeforeDeath = 10;
		private int currentNumberOfCollisions = 0;
		private FlyingBoyBasic thirdChild;
		private Rigidbody2D witchBossInstance;
		private ScoreController scoreControllerScript;
		private static string collisionGameObjectName = "WitchBoss";
		private string witchDeathSoundController = "WitchDeathSound";
		private string santaLaughtSound = "SantaLaught";
		private AudioSource witchDeathSound;
		private AudioSource santaLaught;

		void Start() {
			scoreControllerScript = ScoreControllerUtils.GetScoreController ();
			witchDeathSound = GameObject.Find (witchDeathSoundController).GetComponent<AudioSource>();
			santaLaught = GameObject.Find (santaLaughtSound).GetComponent<AudioSource>();
		}

		public void StartCoroutine(Transform spawnPoint, Rigidbody2D[] enemiesToSpawn) {
			enemyToSpawn = enemiesToSpawn[1]; // reference the first enemy (WitchBoss)
			thirdChild = gameObject.AddComponent<FlyingBoyBasic>();
			StartCoroutine (Spawn(spawnPoint, enemiesToSpawn)); 
		}

		private IEnumerator Spawn(Transform spawnPoint, Rigidbody2D[] enemiesToSpawn){
			yield return new WaitForSeconds (startWait);
			Vector2 spawnPointPosition = new Vector2 (spawnPoint.position.x, spawnPoint.position.y);
			witchBossInstance = Instantiate (enemyToSpawn, spawnPointPosition, Quaternion.Euler (new Vector2 (0, 0)));
		}

		private void OnTriggerEnter2D(Collider2D other){
			string gameObjectName = other.gameObject.name as string;
			if (gameObjectName.Contains("bullet")) {
				GameObject expl = Instantiate (explosion, transform.position, Quaternion.identity) as GameObject;
				Destroy (expl, 1);
				Destroy (other.gameObject);
				witchDeathSound.Play ();
				if (++currentNumberOfCollisions == numberOfCollisionsBeforeDeath) {					
					Destroy (gameObject);
					isBossAlive = false;
					scoreControllerScript.IncreaseScore (collisionGameObjectName);
					santaLaught.Play ();
				}
			}
		} 

		public Rigidbody2D getWitchBossInstance() {
			return witchBossInstance;
		}
	
		public void SpawnNextWave(Transform spawnPoint, Rigidbody2D[] enemiesToSpawn){
			// Spawn next enemy. In this case flyingBoy
			thirdChild.StartCoroutine(spawnPoint, enemiesToSpawn);
		}

	}
}