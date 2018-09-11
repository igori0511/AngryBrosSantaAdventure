using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour {

	private Rigidbody2D myBody;
	private Animator anim;

	private static string santaShootAnimName = "santaShoot";
	private static string santaShootTransVar = "shoot";
	private static string santaDyingAnimName = "santaDying";
	private bool alive = true;

	[SerializeField]
	private string sPInputManagerVerAxis = "Vertical";

	[SerializeField]
	private float upperOffset = 0.8f;

	[SerializeField]
	private float timeLeftUntilDeath = 1.077f;

    [SerializeField]
	private float maxSpeedY = 1.1f;

	[SerializeField]
	private float upperAndLowerForce = 2.2f;

	[SerializeField]
	private float instantForce = 5.0f;

	[SerializeField]
	private float axeDamage = 5.0f;

	[SerializeField]
	private float witchBossBulletDamage = 7.0f;

	[SerializeField]
	private float witchBossGranadeDamage = 15.0f;

	[SerializeField]
	private float witchBossBlackHoleDamage;

	[SerializeField]
	private float flyingBoyGranadeDamage = 12.0f;

	[SerializeField]
	private float boyBossBulletDamage = 4.0f;

	[SerializeField]
	private float boyBossBurpDamage;

	[SerializeField]
	private int maxPlayerHealth = 400;

    private void Awake() {
		GameObject gameObj = GameObject.FindGameObjectWithTag("PlayerTag");
		myBody = gameObj.GetComponent<Rigidbody2D>();
		anim = GetComponent<Animator>();
	}

	// Use this for initialization
	private void Start () {
		HealthBarUtils.SetMaxPlayerHealth (maxPlayerHealth);
		float playerMaxHealth = HealthBarUtils.GetMaxHealth();
		witchBossBlackHoleDamage = playerMaxHealth;
		boyBossBurpDamage = playerMaxHealth;
		myBody.freezeRotation = true;
	}

	public void FireBullet() {
		anim.SetBool (santaShootAnimName, true);
	}

	private void Update(){
		if (anim.GetCurrentAnimatorStateInfo(0).IsName(santaShootTransVar))
		{
			anim.SetBool (santaShootAnimName, false);
		}
		// check if player died
		PlayerDied ();
	}

	private void FixedUpdate() {
		PlayerMoveKeyboard ();
	}

	private void PlayerMoveKeyboard(){		

		float forceX = 0.0f, forceY = 0.0f;
		float verticalMovement = CrossPlatformInputManager.GetAxis (sPInputManagerVerAxis);

		// up
		if (verticalMovement > 0) {
			if (!reachedMaxBoundariesYMax(transform.position.y)) {
				forceY = maxSpeedY * instantForce; 
			}
		}

		// down
		if (verticalMovement < 0) {
			if (!reachedMaxBoundariesYMin(transform.position.y)) {
				forceY = -maxSpeedY * instantForce;
			}
		}

		if (reachedMaxBoundariesYMax(transform.position.y) ) {
			forceY = -maxSpeedY * upperAndLowerForce;
		}

		if (reachedMaxBoundariesYMin(transform.position.y) ) {
			forceY = maxSpeedY * upperAndLowerForce;
		}

		Vector2 force = new Vector2 (forceX, forceY);
		myBody.AddForce (force);
		transform.position = new Vector2(transform.position.x, Mathf.Clamp(transform.position.y, 0, Camera.main.orthographicSize + upperOffset));

	}

	void OnTriggerEnter2D(Collider2D other){
		DecreaseHealth (other);
	}

	private void DecreaseHealth(Collider2D other) {
		string bulletType = other.gameObject.name as string;
		// sanitize bullet names
		bulletType = bulletType.Replace("(Clone)","");

		switch (bulletType) {
			case "Axe":
				HealthBarUtils.DecreaseHealthBarValue (axeDamage);
				break;
			case "WitchBullet":
				HealthBarUtils.DecreaseHealthBarValue (witchBossBulletDamage);
				break;
			case "WitchGranade":
				HealthBarUtils.DecreaseHealthBarValue (witchBossGranadeDamage);
				break;
			case "BlackHole":
				if (!other.usedByEffector) {
					HealthBarUtils.DecreaseHealthBarValue (witchBossBlackHoleDamage);
				}
				break;
			case "Granade":
				HealthBarUtils.DecreaseHealthBarValue (flyingBoyGranadeDamage);
				break;
			case "BoyBullet":
				HealthBarUtils.DecreaseHealthBarValue (boyBossBulletDamage);
				break;
			case "BoyBurpBullet":
				HealthBarUtils.DecreaseHealthBarValue (boyBossBurpDamage);
				break;
			default:
				break;
		}

	}

	private bool reachedMaxBoundariesYMin(float y) {
		return y < 0.0f ? true : false;
	}

	private bool reachedMaxBoundariesYMax(float y) {
		return y > Camera.main.orthographicSize + upperOffset;
	}

	private void PlayerDied(){
		if (HealthBarUtils.GetCurrentHealthBarValue () <= 0) {				
			anim.SetBool (santaDyingAnimName, true);
			timeLeftUntilDeath -= Time.deltaTime;
			if (timeLeftUntilDeath < 0) {	
				Time.timeScale = 0.0f;
				alive = false;	
			}
		}
	}

	public bool isAlive(){
		return alive;
	}

}