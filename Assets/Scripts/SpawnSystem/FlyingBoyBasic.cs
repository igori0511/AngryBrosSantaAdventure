using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpawnSystem {
	public class FlyingBoyBasic : MonoBehaviour {

		private float startWait = 1.7f;
		private float spawnWait = 4.0f;
		private Rigidbody2D enemyToSpawn;
		private int numberOfEnemiesToSpawn = 15;
		private BoyBoss fourthChild;

		public void StartCoroutine(Transform spawnPoint, Rigidbody2D[] enemiesToSpawn) {
			fourthChild = gameObject.AddComponent<BoyBoss>();
			enemyToSpawn = enemiesToSpawn[2]; // reference the third enemy flyingBoy
			StartCoroutine (Spawn(spawnPoint, enemiesToSpawn)); 
		}

		private IEnumerator Spawn(Transform spawnPoint, Rigidbody2D[] enemiesToSpawn){
			yield return new WaitForSeconds (startWait);
			for (int i = 0; i < numberOfEnemiesToSpawn; i++) {
				Vector2 spawnPointPosition = new Vector2 (spawnPoint.position.x, spawnPoint.position.y);
				Instantiate (enemyToSpawn, spawnPointPosition, Quaternion.Euler (new Vector2 (0, 0)));
				yield return new WaitForSeconds (spawnWait);
			}
			// Spawn next enemy. In this case boyBoss
			fourthChild.StartCoroutine(spawnPoint, enemiesToSpawn);
		}
	}
}
