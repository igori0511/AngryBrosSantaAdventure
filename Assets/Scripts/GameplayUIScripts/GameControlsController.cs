using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayerPreferencesPackage;

public class GameControlsController : MonoBehaviour {

	[SerializeField]
	private GameObject[] choiceOneControls;
	[SerializeField]
	private GameObject[] choiceTwoControls;

	void Awake () {
		if (PlayerPreferences.isPlayerGameControlPreferenceChoiceTwoEnabled()) {
			EnableControls (choiceTwoControls);
		} else {
			EnableControls (choiceOneControls);
		}
	}

	private void EnableControls(GameObject[] controls){
		for (int i = 0; i < choiceOneControls.Length; i++) {
			controls[i].SetActive(true);
		}
	}
}
