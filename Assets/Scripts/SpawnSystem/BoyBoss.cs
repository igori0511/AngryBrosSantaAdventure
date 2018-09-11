using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace SpawnSystem {
	public class BoyBoss : MonoBehaviour {

		private Rigidbody2D enemyToSpawn;
		private float startWait = 2.0f;
		public  GameObject explosion;
		public int numberOfCollisionsBeforeDeath = 10;
		private int currentNumberOfCollisions = 0;
		private ScoreController scoreControllerScript;
		private static string collisionGameObjectName = "BoyBoss";
		public AudioSource boyHitSound;
		private HideOverlayCanvas canvasOverlay;
		private string overlaySceneControllerName = "OverlaySceneController";

		void Start() {
			canvasOverlay =  GameObject.Find (overlaySceneControllerName).GetComponent<HideOverlayCanvas>();
			scoreControllerScript = ScoreControllerUtils.GetScoreController ();
		}

		public void StartCoroutine(Transform spawnPoint, Rigidbody2D[] enemiesToSpawn) {
			enemyToSpawn = enemiesToSpawn[3]; // reference the third enemy BoyBoss
			StartCoroutine (Spawn(spawnPoint, enemiesToSpawn)); 
		}

		private void OnTriggerEnter2D(Collider2D other){
			string gameObjectName = other.gameObject.name as string;
			if (gameObjectName.Contains("bullet")) {
				GameObject expl = Instantiate (explosion, transform.position, Quaternion.identity) as GameObject;
				Destroy (expl, 1);
				Destroy (other.gameObject);
				boyHitSound.Play ();
				if (++currentNumberOfCollisions == numberOfCollisionsBeforeDeath) {					
					Destroy (gameObject);
					scoreControllerScript.IncreaseScore (collisionGameObjectName);
					scoreControllerScript.SaveMaxHighScore ();
					canvasOverlay.HideCanvas ();
					SceneFader.instance.LoadLevel("Final");
					//SceneManager.LoadScene("Final"); 
				}
			}
		} 

		private IEnumerator Spawn(Transform spawnPoint, Rigidbody2D[] enemiesToSpawn){
			yield return new WaitForSeconds (startWait);
			Vector2 spawnPointPosition = new Vector2 (spawnPoint.position.x, spawnPoint.position.y);
		    Instantiate (enemyToSpawn, spawnPointPosition, Quaternion.Euler (new Vector2 (0, 0)));
		}
	}
}
