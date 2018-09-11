using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using PlayerPreferencesPackage;

public class SettingsMenuController : MonoBehaviour {

	public Button choiceOneButton;
	public Button choiceTwoButton;
	public Button musicOnButton;
	public Button musicOffButton;

	void Awake () {		
	}

	void Start () {
		synchTransition ();
	}

	// controls choice one button pressed means second will be selected
	public void ChoiceOneButtonPressed() {
		setInteractable (choiceOneButton, choiceTwoButton, false, true);
		setControlsChoice (PlayerPreferences.CONTROLS_DEFAULT_VALUE, PlayerPreferences.CONTROLS_CHOICE_TWO_VAL);
	}

	// controls choice two button pressed means first will be selected
	public void ChoiceTwoButtonPressed() {
		setInteractable (choiceOneButton, choiceTwoButton, true, false);
		setControlsChoice (PlayerPreferences.CONTROLS_CHOICE_ONE_VAL, PlayerPreferences.CONTROLS_DEFAULT_VALUE);
	}

	// tapping music on button will change music state to off
	public void MusicButtonOn() {
		setInteractable (musicOnButton, musicOffButton, false, true);
		setControlsMusic (PlayerPreferences.CONTROLS_DEFAULT_VALUE, PlayerPreferences.CONTROLS_MUSIC_OFF_VAL);
		SoundBaseController.MuteOrEnableSound ();
	}

	// tapping music off button will change music state to on
	public void MusicButtonOff() {
		setInteractable (musicOnButton, musicOffButton, true, false);
		setControlsMusic (PlayerPreferences.CONTROLS_MUSIC_ON_VAL, PlayerPreferences.CONTROLS_DEFAULT_VALUE);
		SoundBaseController.MuteOrEnableSound ();
	}

	// helper method to set interactable values for controls buttons
	private void setInteractable(Button buttonOne, Button buttonTwo, 
							     bool firstChoice, bool secondChoice) {
		buttonOne.interactable = firstChoice;
		buttonTwo.interactable = secondChoice;
	}

	// helper method to set player preferences controls
	private void setControlsChoice(string firstChoiceVal, string secondChoiceVal) {
		PlayerPreferences.setControlsChoiceOneVal(firstChoiceVal);
		PlayerPreferences.setControlsChoiceTwoVal(secondChoiceVal);
	}

	// helper method to set music
	private void setControlsMusic(string firstChoiceVal, string secondChoiceVal) {
		PlayerPreferences.setControlsMusicOn(firstChoiceVal);
		PlayerPreferences.setControlsMusicOff(secondChoiceVal);
	}

	// helper method to synch transition between menus
	private void synchTransition() {
		if (PlayerPreferences.isPlayerGameControlPreferenceChoiceOneEnabled ()) {
			setInteractable (choiceOneButton, choiceTwoButton, true, false);

		} else {
			setInteractable (choiceOneButton, choiceTwoButton, false, true);
		}

		if (PlayerPreferences.isPlayerGameSoundPreferenceOff ()) {
			setInteractable (musicOnButton, musicOffButton, false, true);
		} else {
			setInteractable (musicOnButton, musicOffButton, true, false);
		}
	}

}
