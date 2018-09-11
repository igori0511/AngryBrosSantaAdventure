using UnityEngine;

public class InfiniteScrolling : MonoBehaviour {

    [SerializeField]
	private float backgroundSize;

    private Transform cameraTransform;
	private Transform[] layers;
	private float viewZone = 10;
	private int leftIndex;
	private int rightIndex;

    private void Start() {
		cameraTransform = Camera.main.transform;
        layers = new Transform[transform.childCount];
		for (int i = 0; i < transform.childCount; i++) {
			layers [i] = transform.GetChild (i);
		}
		leftIndex = 0;
		rightIndex = layers.Length - 1;
    }

	private void Update() {
        scrollBasedOnPressedKey();
    }

    private void scrollBasedOnPressedKey() {
        if (cameraTransform.position.x < (layers[leftIndex].transform.position.x + viewZone))
        {
            scrollLeft();
        }
        if (cameraTransform.position.x > (layers[rightIndex].transform.position.x - viewZone))
        {
            scrollRight();
        }
    }

	private void scrollLeft() {
		Vector3 newLeftPosition = assignOldYZindex(calculateNewBackgroundPosition(layers, leftIndex, backgroundSize), layers, leftIndex);
		layers [rightIndex].position = newLeftPosition;
		leftIndex = rightIndex--;	
		if (rightIndex < 0) {
			rightIndex = layers.Length - 1;
		}
	}

	private void scrollRight(){
		Vector3 newRightPosition = assignOldYZindex(calculateNewBackgroundPosition(layers, rightIndex, -backgroundSize), layers, rightIndex);
		layers [leftIndex].position = newRightPosition;
		rightIndex = leftIndex++;
		if (leftIndex == layers.Length) {
			leftIndex = 0;
		}
	}
	
	private Vector3 calculateNewBackgroundPosition(Transform[] layers, int index, float backgroundSize){
		return Vector3.right * (layers[index].position.x - backgroundSize);		 
	}

	private Vector3 assignOldYZindex(Vector3 newBackgroundPosition, Transform[] layers, int index){
		newBackgroundPosition.y = layers[index].position.y;	
		newBackgroundPosition.z = layers[index].position.y;
		return newBackgroundPosition;		
	}

}