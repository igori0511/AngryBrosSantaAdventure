using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScoreMainMenuController : MonoBehaviour {

	[SerializeField]
	private Text scoreComponent;

	void Start () {
		scoreComponent.text = ScoreController.GetHighScore ().ToString();
	}	

}
