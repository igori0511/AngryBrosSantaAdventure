using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseMenuController : MonoBehaviour {

	private GameObject panelOne, panelTwo, panelThree;

	protected void ShowHidePanel(GameObject panel) {
		if (!panel.activeSelf) {
			panel.SetActive (true);
		} else {
			panel.SetActive (false);
		}
	}

	protected void HidePanel(GameObject panel){
		panel.SetActive (false);
	}

	protected bool RegisteredMenusAreActive(GameObject panelOne, GameObject panelTwo) {
		return panelOne.activeSelf || panelTwo.activeSelf;

	}

	protected void CloseActiveMenus(GameObject panelOne, GameObject panelTwo) {
		HidePanel (panelOne);	
		HidePanel (panelTwo);
	}

	protected void CloseActiveMenusIfActive(GameObject panelOne, GameObject panelTwo) {
		if (RegisteredMenusAreActive (panelOne, panelTwo)) {
			CloseActiveMenus (panelOne, panelTwo);
		}
	}

	public void QuitGame() {
		CloseActiveMenusIfActive (panelOne, panelTwo);
		ShowHidePanel (panelThree);
	}

	protected void SetAllPanels (GameObject panelOne, GameObject panelTwo, GameObject panelThree) {
		SetSettingPanel (panelOne);
		SetHighScorePanel (panelTwo);
		SetExitPanel (panelThree);
	}

	private void SetSettingPanel (GameObject panelOne) {
		this.panelOne = panelOne;
	}

	private void SetHighScorePanel (GameObject panelTwo) {
		this.panelTwo = panelTwo;
	}

	private void SetExitPanel (GameObject panelThree) {
		this.panelThree = panelThree;
	}

}
