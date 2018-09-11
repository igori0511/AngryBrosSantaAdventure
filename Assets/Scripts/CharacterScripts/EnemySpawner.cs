using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SpawnSystem;

public class EnemySpawner : MonoBehaviour {

	[SerializeField]
	private Rigidbody2D[] enemiesToSpawn;

	private RootEnemy rootEnemySpawner;
	private WitchBoss witchBossInstance;

	private string enemySpawnerPoint = "EnemySpawner";
	private static string LOGGER_NO_SPAWN_POINT_MESSAGE    = "No spawn point!!";
	private static string LOGGER_SPAWN_POINT_FOUND_MESSAGE = "Spawn point found!";

	private Transform spawnPoint;

	// Use this for initialization
	private void Start () {
		spawnPoint = transform.FindChild(enemySpawnerPoint);
		logSpawnPoint(spawnPoint);
		rootEnemySpawner = gameObject.AddComponent<RootEnemy>();
		rootEnemySpawner.StartRootCoroutine (spawnPoint, enemiesToSpawn); 
		witchBossInstance = rootEnemySpawner.getSecondChild ();
	}	

	private void logSpawnPoint(Transform spawnPoint){
		if (spawnPoint == null) {
			Debug.LogError(LOGGER_NO_SPAWN_POINT_MESSAGE);
		} else {
			Debug.Log(LOGGER_SPAWN_POINT_FOUND_MESSAGE);
			Debug.Log(spawnPoint);
		};
	}

	private void Update() {		
		if (!WitchBoss.isBossAlive) {
			witchBossInstance.SpawnNextWave (spawnPoint, enemiesToSpawn);
			WitchBoss.isBossAlive = true;
		}
	}
}
