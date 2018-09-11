using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KickColliderSwapper : MonoBehaviour {

	[SerializeField]
	private PolygonCollider2D[] colliders;
	private int currentColliderIndex = 0;

	public void SetColliderForSprite( int spriteNum )
	{
		colliders[currentColliderIndex].enabled = false;
		currentColliderIndex = spriteNum;
		colliders[currentColliderIndex].enabled = true;
	}

	public void ResetColliderForSprite( int spriteNum )
	{
		colliders[currentColliderIndex].enabled = false;
	}

}
