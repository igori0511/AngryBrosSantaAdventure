using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossFlying : MonoBehaviour {

	public float interpVelocity = 0.5f;
	public Vector3 offset;
	[SerializeField]
	private float offsetX;
	Vector3 targetPos;

	private void Start()
	{
		offsetX = 2.2f;
	}

	private void FixedUpdate() {

		Vector3 cameraTransform = transform.position;

		Vector3 posNoZ = cameraTransform;
		cameraTransform.x += -offsetX;
		posNoZ.z = cameraTransform.z;

		Vector3 targetDirection = (cameraTransform - posNoZ);

		interpVelocity = targetDirection.magnitude * 4.0f;

		targetPos = transform.position + (targetDirection.normalized * interpVelocity * Time.deltaTime);

		transform.position = Vector3.Lerp(transform.position, targetPos + offset, 0.5f);

	}
}
