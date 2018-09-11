using UnityEngine;

public class CameraFollow : MonoBehaviour {

	 private float interpVelocity;
     public GameObject target;
     public Vector3 offset;
	 public float floatMaxY = 1.8f;
	 public float floatMinY = 1.79f;
     Vector3 targetPos;
	 
     // Use this for initialization
     void Start () {
         targetPos = transform.position;
     }
     
     // Update is called once per frame
     void FixedUpdate () {
         if (target)
         {
            Vector3 posNoZ = transform.position;
            posNoZ.z = target.transform.position.z;
  
            Vector3 targetDirection = (target.transform.position - posNoZ);
  
            interpVelocity = targetDirection.magnitude * 7.5f;
  
            targetPos = transform.position + (targetDirection.normalized * interpVelocity * Time.deltaTime); 
  			
			Vector3 newPosition = Vector3.Lerp( transform.position, targetPos + offset, 0.25f);	

			transform.position = new Vector3(newPosition.x, Mathf.Clamp(newPosition.y, floatMinY, floatMaxY), newPosition.z);
  
         }
     }

}
