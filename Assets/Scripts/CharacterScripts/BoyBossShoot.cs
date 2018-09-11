using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoyBossShoot : MonoBehaviour {

	[SerializeField]
	private float regularShootWait;
	[SerializeField]
	private float burpWait;
	[SerializeField]
	private float fireForce = 5.0f;
	[SerializeField]
	private float burpFireForce = 1.5f;
	[SerializeField]
	private Rigidbody2D bulletSpawn;
	[SerializeField]
	private Rigidbody2D burpSpawn;

	public AudioSource boyRegularShoot;
	public AudioSource boyBurpShoot;

	private Transform spawnPointRegular;
	private Transform spawnPointBurp;
	private Animator anim;
	private string shootSpawnPoint = "ShootBullets";
	private string burpSpawnPoint = "ShootBurp";
	private string shootSpawnPointAnimationChange = "boyBossShoot";
	private string burpSpawnPointAnimationChange  = "boyBossBurp";
	private static string LOGGER_NO_SPAWN_POINT_MESSAGE    = "No spawn point!!";
	private static string LOGGER_SPAWN_POINT_FOUND_MESSAGE = "Spawn point found!";

	// Use this for initialization
	void Start () {
		spawnPointRegular = transform.FindChild(shootSpawnPoint);
		spawnPointBurp = transform.FindChild(burpSpawnPoint);
		logSpawnPoint (spawnPointRegular);
		logSpawnPoint (spawnPointBurp);
		anim = GetComponent<Animator>();
		StartCoroutine (ShootTimerRegularBullets());
		StartCoroutine (ShootTimerBurp());
	}

	private void logSpawnPoint(Transform spawnPoint){
		if (spawnPoint == null) {
			Debug.LogError(LOGGER_NO_SPAWN_POINT_MESSAGE);
		} else {
			Debug.Log(LOGGER_SPAWN_POINT_FOUND_MESSAGE);
			Debug.Log(spawnPoint);
		};
	}

	private IEnumerator ShootTimerRegularBullets() {
		while (true) {
			// spawn a regular bullet or granade
			yield return new WaitForSeconds (regularShootWait);
			anim.SetBool (shootSpawnPointAnimationChange, true);
		}
	}

	private IEnumerator ShootTimerBurp() {
		while (true) {
			// spawn a burp
			yield return new WaitForSeconds (burpWait);
			anim.SetBool (burpSpawnPointAnimationChange, true);
		}
	}

	public void BoyRegularShoot() {		
		Vector2 spawnPointPosition = new Vector2 (spawnPointRegular.position.x, spawnPointRegular.position.y);
		Rigidbody2D bulletInstance = Instantiate (bulletSpawn, spawnPointPosition, Quaternion.Euler (new Vector2 (0, 0))) as Rigidbody2D;
		bulletInstance.AddForce (bulletInstance.transform.right * -fireForce);
		if (!boyRegularShoot.isPlaying) {
			boyRegularShoot.Play ();
		}
	}

	public void BoyBurpShoot() {		
		Vector2 spawnPointPosition = new Vector2 (spawnPointBurp.position.x, spawnPointBurp.position.y);
		Rigidbody2D burpInstance = Instantiate (burpSpawn, spawnPointPosition, Quaternion.Euler (new Vector3 (0, 0, 0))) as Rigidbody2D;
		burpInstance.AddForce (burpInstance.transform.right * -burpFireForce);
		boyBurpShoot.Play ();
	}

	public void BoyregularShootDeactivateAnimation() {		
		anim.SetBool (shootSpawnPointAnimationChange, false);
	}

	public void BoyBurpDeactivateAnimation() {		
		anim.SetBool (burpSpawnPointAnimationChange, false);
	}
}
