using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayerPreferencesPackage;

public class SoundBaseController : MonoBehaviour {

	void Awake() {
		MuteOrEnableSound ();
	}

	public static void MuteOrEnableSound(){
		if (PlayerPreferences.isPlayerGameSoundPreferenceOff ()) {
			SetAudioListenerState (true, 0.0f);
		} else {
			SetAudioListenerState (false, 1.0f);
		}
	}

	private static void SetAudioListenerState(bool pause, float volume) {
		AudioListener.pause = pause;
		AudioListener.volume = volume;
	}

}
