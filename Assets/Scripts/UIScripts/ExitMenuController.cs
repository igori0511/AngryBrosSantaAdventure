using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitMenuController : MainMenuController {

	private HideOverlayCanvas canvasOverlay;
	private string overlaySceneControllerName = "OverlaySceneController";

	void Awake () {	
		SetAllPanels (settingPanel, highScorePanel, exitPanel);	
	}

	void Start () {
		GameObject overlayScene = GameObject.Find (overlaySceneControllerName);
		if(overlayScene){
			canvasOverlay =  overlayScene.GetComponent<HideOverlayCanvas>();
		}
	}

	void Update () {
		if (Input.GetKeyDown(KeyCode.Escape)) {
			QuitGame ();
		}
	}

	public void ExitYes (){
		Scene applicationLevelScene = SceneManager.GetActiveScene();
		string sceneName = applicationLevelScene.name;
		if (sceneName == "Gameplay") {
			Time.timeScale = 1.0f;
			if (canvasOverlay) {
				canvasOverlay.HideCanvas ();
			}
			SceneFader.instance.LoadLevel("MainMenu");
			//SceneManager.LoadScene("MainMenu"); 
		}
		if (sceneName == "MainMenu") {
			Application.Quit();
		}
	}

	public void ExitNo (){
		ShowHidePanel (exitPanel);
	}

}
