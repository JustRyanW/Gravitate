using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public Vector2 launchSpeedMinMax;
    public float mouseDistanceForMaxSpeed;

	Rigidbody2D rb;
	LineRenderer lr;
	bool isLanded;
    float minForcePercent;
    float forcePercent;

	void Start () {
		rb = GetComponent<Rigidbody2D> ();
		lr = GetComponent<LineRenderer> ();
        minForcePercent = launchSpeedMinMax.x / launchSpeedMinMax.y;
	}

	void Update () {
		if (Input.GetMouseButtonDown (0) && isLanded) {
			LaunchPlayer ();
		}
		if (isLanded) {
			Vector2 pos = transform.position;
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 dir = mousePos - pos;
            float halfWidth = transform.localScale.magnitude / 2;
            float mouseDistanceFromPlayerSurface = Mathf.Clamp(Mathf.Clamp(Vector2.Distance(mousePos, pos) - halfWidth, 0, float.MaxValue), minForcePercent, 1);
            forcePercent = Mathf.Clamp(mouseDistanceFromPlayerSurface, 0, mouseDistanceForMaxSpeed) / mouseDistanceForMaxSpeed;
            lr.SetPosition (0, pos + dir.normalized / 2.2f);
			lr.SetPosition (1, pos + dir.normalized * forcePercent * mouseDistanceForMaxSpeed + dir.normalized / 2);
		}
	}

	void OnCollisionEnter2D (Collision2D coll) {
		if (!isLanded) {
            lr.enabled = true;
            rb.isKinematic = true;
			isLanded = true;
		}
	}

	void LaunchPlayer () {
        lr.enabled = false;
		rb.isKinematic = false;
		Vector2 dir = Camera.main.ScreenToWorldPoint (Input.mousePosition) - transform.position;
		rb.AddForce (dir.normalized * launchSpeedMinMax.y * forcePercent);
		Invoke ("LeftPlanet", 0.1f);
	}

	void LeftPlanet(){
		isLanded = false;
	}

}
