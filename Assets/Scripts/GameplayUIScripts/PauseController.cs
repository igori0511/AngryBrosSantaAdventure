using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PauseController : MonoBehaviour {

	[SerializeField]
	private GameObject pauseGameButtons;

	private GameObject controlsChoiceOne;
	private GameObject joystickBoundaries;
	private GameObject joystickController;

	void Start() {
		controlsChoiceOne = GameObject.FindGameObjectWithTag ("ControlsChoiceOne");
		joystickBoundaries = GameObject.FindGameObjectWithTag ("JoystickBoundaries");
		joystickController = GameObject.FindGameObjectWithTag ("JoystickController");
	}

	public void Pause(){
		Time.timeScale = 0.0f;
		pauseGameButtons.SetActive (true);
		controlsChoiceOne.SetActive (false);
		joystickBoundaries.SetActive (false);
		joystickController.SetActive (false);
	}

	public void ResumeGame(){
		Time.timeScale = 1.0f;
		pauseGameButtons.SetActive (false);
		controlsChoiceOne.SetActive (true);
		joystickBoundaries.SetActive (true);
		joystickController.SetActive (true);
	}

	public void RestartGame(){		
		Time.timeScale = 1.0f;
		SceneFader.instance.LoadLevel("Gameplay");
		//SceneManager.LoadScene("Gameplay");
	}
}
