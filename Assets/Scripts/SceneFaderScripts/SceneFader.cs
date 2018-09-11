using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneFader : MonoBehaviour {

	public static SceneFader instance;

	public GameObject fadePanel;
	public Animator fadeAnim;
	public float fadeInInterval = 1.0f;
	public float fadeOutInterval = 0.7f;

	void Awake () {
		MakeSingleton ();
	}

	void MakeSingleton() {
		if (instance != null) {
			Destroy (gameObject);
		} else {
			instance = this;
			DontDestroyOnLoad (gameObject);
		}
	}

	public void LoadLevel(string level){
		StartCoroutine (FadeInOut(level));
	}

	IEnumerator FadeInOut(string level){
		fadePanel.SetActive (true);
		fadeAnim.Play ("FadeIn");
		yield return StartCoroutine (WairRealSeconds.WaitForRealSeconds((fadeInInterval)));
		SceneManager.LoadScene(level);
		fadeAnim.Play ("FadeOut");
		yield return StartCoroutine (WairRealSeconds.WaitForRealSeconds((fadeOutInterval)));
		fadePanel.SetActive (false);
	}
}
