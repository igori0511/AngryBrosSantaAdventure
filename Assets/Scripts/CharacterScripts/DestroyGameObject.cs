﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyGameObject : MonoBehaviour {

	void OnBecameInvisible() {
		Destroy(gameObject);
	}
}
