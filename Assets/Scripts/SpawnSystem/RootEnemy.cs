using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpawnSystem {
	public class RootEnemy : MonoBehaviour {
		
		private int maxNumberOfEnemiesToSpawn = 3;
		private int maxNumberOfWaves = 15;
		private Rigidbody2D enemyToSpawn;
		private float startWait = 1.0f;
		private float spawnWait = 1.4f;
		private float waveWait = 2.0f;
		private float cameraHeight; 
		private WitchBoss secondShild;
		private float maxX, minX, yOffset, offsetX, maxY, minY;

		public void StartRootCoroutine(Transform spawnPoint, Rigidbody2D[] enemiesToSpawn) {
			secondShild = gameObject.AddComponent<WitchBoss>();
			cameraHeight = Camera.main.orthographicSize;
			enemyToSpawn = enemiesToSpawn[0]; // reference the first enemy (Witch)
			StartCoroutine (Spawn(spawnPoint, enemiesToSpawn)); 
		}

		private IEnumerator Spawn(Transform spawnPoint, Rigidbody2D[] enemiesToSpawn) {
			yield return new WaitForSeconds (startWait);

			float randomY = 0.0f, randomX = 0.0f;
			int currentNumberOfEnemiesToSpawn = 0;
			setMinMaxXY();

			while (maxNumberOfWaves-- > 0) {			
				currentNumberOfEnemiesToSpawn = currentNumberOfEnemiesToSpawn == maxNumberOfEnemiesToSpawn ? 
					maxNumberOfEnemiesToSpawn : ++currentNumberOfEnemiesToSpawn;
				for (int i = 0; i < currentNumberOfEnemiesToSpawn; i++) {
					randomY = Random.Range (minY, maxY+1);
					randomX = Random.Range (minX, maxX);
					Vector2 spawnPointPosition = new Vector2 (spawnPoint.position.x - randomX, randomY);
					Instantiate (enemyToSpawn, spawnPointPosition, Quaternion.Euler (new Vector2 (0, 0)));
					yield return new WaitForSeconds (spawnWait);
				}
				yield return new WaitForSeconds (waveWait);		
			}
			// Spawn next enemy. In this case WitchBoss
			secondShild.StartCoroutine(spawnPoint, enemiesToSpawn);
		}

		private void setMinMaxXY() {
			maxX = 4.5f; 
			minX = -2.5f;
			yOffset = 5.0f;
			maxY =  cameraHeight;
			minY = -cameraHeight+yOffset;
		}

		public WitchBoss getSecondChild() {
			return secondShild;
		}

	}

}