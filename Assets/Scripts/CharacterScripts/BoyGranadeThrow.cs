using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoyGranadeThrow : MonoBehaviour {

	[SerializeField]
	private float granadeThrowWait;
	[SerializeField]
	private float granadeFireForce;
	[SerializeField]
	private Rigidbody2D granadeSpawn;
	public AudioSource boyThrowGranade;

	private GameObject target;

	private float offsetThrow = 2.0f;
	private Vector2 end;
	private Transform spawnPointGranade;
	private Animator anim;
	private string granadeShootSpawnPoint = "GranadeFirePoint";
	private string fireGranadeAnimation = "boyGranadeThrow";
	private static string LOGGER_NO_SPAWN_POINT_MESSAGE    = "No spawn point!!";
	private static string LOGGER_SPAWN_POINT_FOUND_MESSAGE = "Spawn point found!";
	IEnumerator startThrowAnimation;

	// Use this for initialization
	void Awake () {
		spawnPointGranade = transform.FindChild(granadeShootSpawnPoint);
		logSpawnPoint (spawnPointGranade);
		anim = GetComponent<Animator>();
		startThrowAnimation = StartThrowAnimation ();

	}

	public void startThrow() {
		StartCoroutine (startThrowAnimation);
	}

	private IEnumerator StartThrowAnimation() {
		while (true) {
			// spawn a regular bullet or granade
			yield return new WaitForSeconds (granadeThrowWait);
			anim.SetBool (fireGranadeAnimation, true);
		}
	}

	private void logSpawnPoint(Transform spawnPoint){
		if (spawnPoint == null) {
			Debug.LogError(LOGGER_NO_SPAWN_POINT_MESSAGE);
		} else {
			Debug.Log(LOGGER_SPAWN_POINT_FOUND_MESSAGE);
			Debug.Log(spawnPoint);
		};
	}

	public void ThrowGranade() {
		Vector2 spawnPointPosition = new Vector2 (spawnPointGranade.position.x, spawnPointGranade.position.y);
		target = GameObject.FindGameObjectWithTag("PlayerTag");
		end = target.transform.position;
		if (!(end.x + offsetThrow > spawnPointPosition.x)) {
			Rigidbody2D granadeInstance = Instantiate (granadeSpawn, spawnPointPosition, Quaternion.Euler (new Vector3 (0, 0, 0))) as Rigidbody2D;
			//granadeInstance.AddForce (granadeInstance.transform.right * -granadeFireForce);
			granadeInstance.AddForce ((end - spawnPointPosition) * granadeFireForce);
			boyThrowGranade.Play ();
		} else {
			StopCoroutine (startThrowAnimation);
		}
	}

	public void BoyGranadeThrowDeactivateAnimation() {		
		anim.SetBool (fireGranadeAnimation, false);
	}

	public void StopCoroutineThrowAnimation(){
		StopCoroutine (startThrowAnimation);
	}
}
