using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableBoyBossMovement : MonoBehaviour {

	private BossFlying boyScript;
	private BoyBossShoot boyBossShootScript;
	private float boyBossMoving = 1.0f;
	public AudioSource boyBossLaughing;

	// Use this for initialization
	void Start () {		
		boyScript = GetComponent<BossFlying>();
		boyBossShootScript = GetComponent<BoyBossShoot>();
	}

	void OnBecameVisible(){
		boyBossLaughing.Play ();
		StartCoroutine(BoyFlyingDisableScript());	
	}

	private IEnumerator BoyFlyingDisableScript() {
		yield return new WaitForSeconds (boyBossMoving);
		boyScript.enabled = false;
		boyBossShootScript.enabled = true;
	}
}
