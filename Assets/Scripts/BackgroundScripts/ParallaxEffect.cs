using UnityEngine;
using System.Collections;

public class ParallaxEffect : MonoBehaviour {

    [SerializeField]
    private float parallaxSpeed;
    private Transform cameraTransform;
    private float lastCameraX;

    private void Start()
    {
        cameraTransform = Camera.main.transform;
        lastCameraX = cameraTransform.transform.position.x;
    }

    private void Update() {
        parallaxCalculation();
    }

    private void parallaxCalculation() {
        float deltaX = cameraTransform.position.x - lastCameraX;
        transform.position += Vector3.right * (deltaX * parallaxSpeed);
        lastCameraX = cameraTransform.position.x;
    }
}