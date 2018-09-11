using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoyDyingAnimation : MonoBehaviour {

	private Animator anim;
	private string dyingAnimation = "boyDying";
	private BoyGranadeThrow boyGranadeThrow;
	private BoyMovement boyMovement;
	public GameObject explosion;
	private Rigidbody2D myBody;
	private ScoreController scoreControllerScript;
	private static string collisionGameObjectName = "Boy";
	private int numberOfHits;
	public AudioSource boyDyingSound;

	[SerializeField]
	private float yForce = -8.0f;

	private void Start(){
		anim = GetComponent<Animator>();
		boyGranadeThrow = GetComponent<BoyGranadeThrow>();
		boyMovement = GetComponent<BoyMovement>();
		myBody = GetComponent<Rigidbody2D>();
		scoreControllerScript = ScoreControllerUtils.GetScoreController ();
		numberOfHits = 0;
	}
	
	void OnTriggerEnter2D(Collider2D other){
		string gameObjectName = other.gameObject.name as string;
		if (gameObjectName.Contains ("bullet")) {
			if (++numberOfHits == 1) {
				scoreControllerScript.IncreaseScore (collisionGameObjectName);
			}
			boyDyingSound.Play ();
			Destroy (other.gameObject);
			anim.SetBool (dyingAnimation, true);
			boyGranadeThrow.StopCoroutineThrowAnimation ();
			boyMovement.enabled = false;
			GameObject expl = Instantiate (explosion, transform.position, Quaternion.identity) as GameObject;
			Destroy (expl, 1);
			myBody.AddForce (new Vector2(0.0f, yForce));
		}
	} 

}