using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShowDialogs : MonoBehaviour {

	public GameObject[] allDialogs;
	public float dialogWaitInterval = 1.2f;
	public float waithAfterDialogsFinish = 2.0f;

	void Start() {
		StartCoroutine (StartDialogs()); 
	}

	private IEnumerator StartDialogs() {
		allDialogs [0].SetActive (true);
		yield return new WaitForSeconds (dialogWaitInterval);
		for(int i = 1; i < allDialogs.Length; i++){
			allDialogs [i-1].SetActive (false);
			allDialogs [i].SetActive (true);
			yield return new WaitForSeconds (dialogWaitInterval);
		}
		yield return new WaitForSeconds (waithAfterDialogsFinish);
		Scene applicationLevelScene = SceneManager.GetActiveScene();
		string sceneName = applicationLevelScene.name;
		if (sceneName == "Final") {
			//SceneManager.LoadScene("MainMenu"); 
			SceneFader.instance.LoadLevel("MainMenu");
		}
		if (sceneName == "Intro") {
			//SceneManager.LoadScene("Gameplay");
			SceneFader.instance.LoadLevel("Gameplay");
		}	
	}
}
