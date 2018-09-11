using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MainMenuController : BaseMenuController {

	public GameObject settingPanel, highScorePanel, exitPanel;

	void Awake () {
		SetAllPanels (settingPanel, highScorePanel, exitPanel);
	}

	void Start () {
	}

	public void StartGame() {
		SceneFader.instance.LoadLevel("Intro");
		//SceneManager.LoadScene("Intro");
	}

	public void SettingsMenu() {
		CloseActiveMenusIfActive (highScorePanel, exitPanel);
		ShowHidePanel (settingPanel);
	}

	public void HighscoreMenu() {
		CloseActiveMenusIfActive (settingPanel, exitPanel);
		ShowHidePanel (highScorePanel);
	}

}
