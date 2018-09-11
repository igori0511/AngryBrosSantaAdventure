using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableBossWitchMovement : MonoBehaviour {

	private WitchFlying witchScript;
	private float witchBossMoving = 1.0f;
	public AudioSource axeDestroySound;

	// Use this for initialization
	void Start () {		
		witchScript = GetComponent<WitchFlying>();
	}
	
	void OnBecameVisible(){
		StartCoroutine(WitchFlyingDisableScript());	
		axeDestroySound.Play ();
	}

	private IEnumerator WitchFlyingDisableScript() {
		yield return new WaitForSeconds (witchBossMoving);
		witchScript.enabled = false;
	}
}
