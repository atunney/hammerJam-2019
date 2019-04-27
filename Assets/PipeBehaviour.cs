using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeBehaviour : MonoBehaviour {

	public bool dropped = false;	
	Rigidbody2D rb2D;

	float fallSpeed = 1f;

	void Awake() {
		rb2D = GetComponent<Rigidbody2D>();
		Freeze();
	}

	public void Freeze() {
		rb2D.velocity = Vector2.zero;
		rb2D.angularVelocity = 0f;
		dropped = false;
	}

	public void Drop() {
		rb2D.velocity = new Vector2(0, -5f);
		
		dropped = true;
	}

	public void RandomRotation() {


	}

	// void Update () {
	// 	if (dropped  && rb2D.isKinematic) {
	// 		rb2D.constraints = RigidbodyConstraints.None;
	// 	}

	// }
}
