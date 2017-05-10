using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IgnoreCollision : MonoBehaviour {


	public Collider2D other;

	// Use this for initialization
	void Awake () {

		Physics2D.IgnoreCollision (GetComponent<CapsuleCollider2D> (), other, true);
		
	}

}
