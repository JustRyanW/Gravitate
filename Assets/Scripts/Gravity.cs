using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(LineRenderer))]
public class Gravity : MonoBehaviour {

	public float attractionForce = 10f;

	Rigidbody rb;

	public static List<Gravity> Attractors;

	void Start () 
	{
		rb = GetComponent<Rigidbody> ();
	}

	void FixedUpdate () 
	{
		foreach (Gravity attractor in Attractors) 
		{
			if (attractor != this)
				Attract (attractor);
		}
	}

	void OnEnable ()
	{
		if (Attractors == null)
			Attractors = new List<Gravity> ();
		Attractors.Add (this);

	}

	void OnDisable ()
	{
		Attractors.Remove (this);
	}

	void Attract (Gravity objToAttract)
	{
		Rigidbody rbToAttract = objToAttract.rb;

		Vector3 direction = rb.position - rbToAttract.position;
		float distance = direction.magnitude;

		float forceMagnitude = attractionForce * (rb.mass * rbToAttract.mass) / Mathf.Pow (distance, 2);
		Vector3 force = direction.normalized * forceMagnitude;

		rbToAttract.AddForce (force);
	}

}