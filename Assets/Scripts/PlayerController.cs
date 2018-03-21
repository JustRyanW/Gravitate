using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public int launchSpeed;

	Rigidbody2D rb;
	bool isLanded;

	void Start () {
		rb = GetComponent<Rigidbody2D> ();
	}

	void Update () {
		if (Input.GetMouseButtonDown (0) && isLanded) {
			LaunchPlayer ();
		}
	}

	void OnCollisionEnter2D (Collision2D coll) {
		if (!isLanded) {
			rb.isKinematic = true;
			isLanded = true;
		}
	}

	void LaunchPlayer () {
		rb.isKinematic = false;
		Vector2 dir = Camera.main.ScreenToWorldPoint (Input.mousePosition) - transform.position;
		rb.AddForce (dir.normalized * launchSpeed);
		Invoke ("LeftPlanet", 0.1f);
	}

	void LeftPlanet(){
		isLanded = false;
	}

}
