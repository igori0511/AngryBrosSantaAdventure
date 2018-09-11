using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WitchBossShoot : MonoBehaviour {

	[SerializeField]
	private float regularShootWait;
	[SerializeField]
	private float blackHoleWait;
	[SerializeField]
	private float fireForce = 5.0f;
	[SerializeField]
	private float blackHoleFireForce = 1.5f;
	[SerializeField]
	private Rigidbody2D[] bulletSpawn;
	[SerializeField]
	private Rigidbody2D blackHole;
	[SerializeField]
	private float deltaRotation = 500.0f;
	[SerializeField]
	private string granadeThrowSoundName;
	[SerializeField]
	private string bulletThrowSoundName;
	[SerializeField]
	private string blackHoleThrowSoundName;

	private AudioSource granadeThrowSound;
	private AudioSource bulletThrowSound;
	private AudioSource blackHoleThrowSound;

//	private Rigidbody2D myBody;
	private Transform spawnPointRegular;
	private Transform spawnPointBlackHole;
	private Animator anim;
	private string regularShootSpawnPoint = "RegularShootPoint";
	private string blackHoleSpawnPoint = "BlackHoleSpawnPoint";
	private string regularBulletSpawnPosition = "witch_boss_shoot";
	private string blackHoleSpawnPosition = "witch_boss_blackhole";
	private static string LOGGER_NO_SPAWN_POINT_MESSAGE    = "No spawn point!!";
	private static string LOGGER_SPAWN_POINT_FOUND_MESSAGE = "Spawn point found!";

	// Use this for initialization
	void Start () {
		spawnPointRegular = transform.FindChild(regularShootSpawnPoint);
		spawnPointBlackHole = transform.FindChild(blackHoleSpawnPoint);
		logSpawnPoint (spawnPointRegular);
		logSpawnPoint (spawnPointBlackHole);
		anim = GetComponent<Animator>();
//		myBody = GetComponent<Rigidbody2D>();
		StartCoroutine (ShootTimerRegularBullets());
		StartCoroutine (ShootTimerBlackHole());
		granadeThrowSound   = GameObject.Find (granadeThrowSoundName).GetComponent<AudioSource>();
		bulletThrowSound    = GameObject.Find (bulletThrowSoundName).GetComponent<AudioSource>();
		blackHoleThrowSound = GameObject.Find (blackHoleThrowSoundName).GetComponent<AudioSource>();
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
			anim.SetBool (regularBulletSpawnPosition, true);
		}
	}

	private IEnumerator ShootTimerBlackHole() {
		while (true) {
			// spawn a blackhole
			yield return new WaitForSeconds (blackHoleWait);
			anim.SetBool (blackHoleSpawnPosition, true);
		}
	}

	public void WitchRegularShoot() {		
		Rigidbody2D regularBullet = bulletSpawn[Random.Range (0, bulletSpawn.Length)];
		Vector2 spawnPointPosition = new Vector2 (spawnPointRegular.position.x, spawnPointRegular.position.y);
		Rigidbody2D bulletInstance = Instantiate (regularBullet, spawnPointPosition, Quaternion.Euler (new Vector2 (0, 0))) as Rigidbody2D;
		bulletInstance.AddForce (bulletInstance.transform.right * -fireForce);
		if (!regularBullet.name.Contains ("Granade")) {
			PlayMusic (bulletThrowSound);
		} else {
			PlayMusic (granadeThrowSound);
		}
	}

	public void WitchBlackHoleShoot() {		
		Vector2 spawnPointPosition = new Vector2 (spawnPointBlackHole.position.x, spawnPointRegular.position.y);
		Rigidbody2D blackHoleInstance = Instantiate (blackHole, spawnPointPosition, Quaternion.Euler (new Vector3 (0, 0, 30))) as Rigidbody2D;
		blackHoleInstance.AddForce (blackHoleInstance.transform.right * -blackHoleFireForce);
		blackHoleInstance.AddTorque(deltaRotation);
		PlayMusic (blackHoleThrowSound);
		//myBody.AddForce(new Vector2(3.0f, 0.0f));
	}

	public void WitchregularShootDeactivateAnimation() {		
		anim.SetBool (regularBulletSpawnPosition, false);
	}

	public void WitchBlackHoleDeactivateAnimation() {		
		anim.SetBool (blackHoleSpawnPosition, false);
	}

	private void PlayMusic(AudioSource audioSource) {
		audioSource.Play ();
	}
}
