using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarUtils : MonoBehaviour {

	private static Slider healthBar;
	private static string healthBarName = "HealthBar";
	private static float maxHealtOnAwake;

	void Awake() {
		GetReferences ();
	}

	public static void DecreaseHealthBarValue(float decreaseValue) {
		if (healthBar) {
			healthBar.value -= decreaseValue;
		}
	}

	public static float GetCurrentHealthBarValue() {
		return healthBar.value;
	}

	public static float GetMaxHealth() {
		return GetCurrentHealthBarValue();
	}

	public static void SetMaxPlayerHealth (int playerHealth) {
		healthBar.maxValue = playerHealth;
		healthBar.value = playerHealth;
	}

	private void GetReferences(){
		healthBar = GameObject.Find (healthBarName).GetComponent<Slider>();
	}
}
