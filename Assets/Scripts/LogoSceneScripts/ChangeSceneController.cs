using System.Collections;
using UnityEngine;

public class ChangeSceneController : MonoBehaviour {

    public float secondsUntilLoadNextScene = 3.0f;

	void Start () {
        StartCoroutine(LoadNextScene(secondsUntilLoadNextScene));
    }

    private IEnumerator LoadNextScene(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        SceneFader.instance.LoadLevel("MainMenu");
    }
}
