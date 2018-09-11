using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour {

	public float DAMAGE = 10;
	public Rigidbody2D bullet;
	public float fireForce = 6.0f;
	public AudioSource santaShootSound;
	private Transform firePoint;		

	// Use this for initialization
	void Awake () {
		firePoint = transform.FindChild("FirePoint");
		if (firePoint == null) {
			Debug.LogError("No firePoint!!");
		} else {
			Debug.Log("Fire point found!");
			Debug.Log(firePoint);
		}
	}
	
	public void Shoot(){
		Physics2D.IgnoreLayerCollision(8,9);
		Vector2 firePointPosition = new Vector2 (firePoint.position.x, firePoint.position.y);
		Rigidbody2D bulletInstance = Instantiate(bullet, firePointPosition, Quaternion.Euler(new Vector2(0, 0))) as Rigidbody2D;
		bulletInstance.AddForce (bulletInstance.transform.right * fireForce);
		santaShootSound.Play ();
	}
}
