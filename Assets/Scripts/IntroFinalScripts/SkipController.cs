using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class SkipController : MonoBehaviour {
	
	public void SkipIntroScene() {
		SceneFader.instance.LoadLevel("Gameplay");
		//SceneManager.LoadScene("Gameplay");
	}

	public void SkipFinalScene() {
		SceneFader.instance.LoadLevel("MainMenu");
		//SceneManager.LoadScene("MainMenu");
	}

}
