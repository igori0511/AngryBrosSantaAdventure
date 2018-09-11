using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HideOverlayCanvas : MonoBehaviour {

	public GameObject canvas;

	public void HideCanvas() {		
		canvas.SetActive (false);
	}
}
