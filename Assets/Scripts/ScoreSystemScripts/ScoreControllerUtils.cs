using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreControllerUtils : MonoBehaviour {

	private static ScoreController scoreControllerScript;
	private static string scoreControllerName = "ScoreController";

	public static void InitObjects () {
		scoreControllerScript = GameObject.Find (scoreControllerName).GetComponent<ScoreController>();
	}

	public static ScoreController GetScoreController() {
		return scoreControllerScript;
	}

}
