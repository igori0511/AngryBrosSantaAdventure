using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeathSounds : MonoBehaviour {

	public AudioSource deerInjuredSound;
	public AudioSource beforeScreamingSound;
	public AudioSource screamingSound;

	public void PlayDeerInjured() {
		PlaySound (deerInjuredSound);
	}

	public void PlayBeforeScreaming() {
		PlaySound (beforeScreamingSound);
	}

	public void PlayScreaming() {
		PlaySound (screamingSound);
		
	}

	private void PlaySound(AudioSource sound) {
		sound.Play ();
	}

}