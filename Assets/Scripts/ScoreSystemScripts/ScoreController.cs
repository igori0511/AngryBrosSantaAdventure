using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour {

	[SerializeField]
	private int regularWitchScore = 10;

	[SerializeField]
	private int witchBossScore = 700;

	[SerializeField]
	private int regularBoyScore = 15;

	[SerializeField]
	private int boyBossScore = 1500;

	[SerializeField]
	private Text scoreComponent;

	public static readonly string HIGH_SCORE_KEY = "HighScore";

	private int count;

	void Awake ()
	{
		ScoreControllerUtils.InitObjects ();
		ResetCount ();
		scoreComponent.text = "0";
	}

	public void IncreaseScore(string enemyName) {
		//Debug.Log (enemyName);
		if (scoreComponent) {
			switch (enemyName) {
				case "Witch":
					count += regularWitchScore;					
					break;
				case "WitchBoss":
					count += witchBossScore;	
					break;
				case "Boy":
					count += regularBoyScore;				
					break;	
				case "BoyBoss":
					count += boyBossScore;
					break;	
				default:
					break;
			}
			SetScoreOnUI ();
		}
	}

	private void SetScoreOnUI() {
		scoreComponent.text	= count.ToString ();
	}

	private void SaveHighScore(int value) {
		PlayerPrefs.SetInt (HIGH_SCORE_KEY, value);
	}

	public void ResetCount() {
		count = 0;
	}

	public int GeScore() {
		return count;
	}

	public void SaveMaxHighScore(){
		if (count > GetHighScore ()) {
			SaveHighScore (count);
		}
	}

	public static int GetHighScore() {
		return PlayerPrefs.GetInt(HIGH_SCORE_KEY);
	}

}
