using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverController : MonoBehaviour {
	
	[SerializeField]
	private GameObject[] hideGameObjectOnGameOver;

	[SerializeField]
	private GameObject gameOverScreen;

	[SerializeField]
	private Player player;

	private ScoreController scoreControllerScript;

	void Start(){
		scoreControllerScript = ScoreControllerUtils.GetScoreController ();
	}

	void Update() {
		if (player) {
			if (!player.isAlive()) {
				scoreControllerScript.SaveMaxHighScore ();
				gameOverScreen.SetActive (true);
				for (int i = 0; i < hideGameObjectOnGameOver.Length; i++) {
					hideGameObjectOnGameOver [i].SetActive (false);
				}
			}
		}
	}

}
