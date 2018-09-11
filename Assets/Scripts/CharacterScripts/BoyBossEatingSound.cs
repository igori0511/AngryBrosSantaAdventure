using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoyBossEatingSound : MonoBehaviour {

	public AudioSource boyBossEatingSound;

	public void playEatingSound() {
		boyBossEatingSound.Play ();
	}
}
