using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BoyStartThrow : MonoBehaviour
{
	private BoyGranadeThrow boyScript;
	public AudioSource boyLaughing;

	// Use this for initialization
	void Start () {		
		boyScript = GetComponent<BoyGranadeThrow>();
	}

	void OnBecameVisible(){
		boyLaughing.Play ();
		BoyShootingStartScript();	
	}

	private void BoyShootingStartScript() {
		boyScript.startThrow();
		boyScript.enabled = true;
	}
}


