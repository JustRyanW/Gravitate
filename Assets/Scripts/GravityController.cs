using UnityEngine;
using System.Collections.Generic;

public class GravityController : MonoBehaviour {

    public bool drawForce = false;
    public bool isLinear = true;
    public float globalGravityScale = 10f;
    public List<GameObject> Attractors;
    Rigidbody2D rb;

	void Start () {
        rb = GetComponent<Rigidbody2D>();
	}
	
	void OnEnable () {
        if (Attractors == null)
            Attractors = new List<GameObject>();
        foreach (GameObject attractor in GameObject.FindGameObjectsWithTag("Attractor"))
        {
            Attractors.Add(attractor);
        }
    }

    void FixedUpdate()
    {
        foreach (GameObject attractor in Attractors)
        {
            Attract(attractor);
        }
    }

    void Attract(GameObject planet)
    {
        Rigidbody2D planetRb = planet.GetComponent<Rigidbody2D>();

        Vector2 direction = planetRb.position - rb.position;
        float distance = direction.magnitude;

        float forceMagnitude = (isLinear) ? globalGravityScale * (rb.mass * planetRb.mass) / distance / 2 : globalGravityScale * (rb.mass * planetRb.mass) / Mathf.Pow(distance, 2);
        Vector2 force = direction.normalized * forceMagnitude;

        if (drawForce)
            Debug.DrawRay(transform.position, direction, Color.Lerp(Color.blue, Color.red, forceMagnitude / (globalGravityScale / 4)));

        rb.AddForce(force);
    }

    // create own movement handler that uses startpos startvelocity and returns a endpos and endvelocity instead of relying on rigidbody, then use it to calculate trajectory

    /*public Vector2 CalculateForce(Vector2 startPos)
    {
        foreach (GameObject attractor in Attractors)
        {
            Vector2 direction = planetRb.position - rb.position;
            float distance = direction.magnitude;

            float forceMagnitude = (isLinear) ? globalGravityScale * (rb.mass * planetRb.mass) / distance / 2 : globalGravityScale * (rb.mass * planetRb.mass) / Mathf.Pow(distance, 2);
            Vector2 force = direction.normalized * forceMagnitude;

        }
        return finalForce;
    }

    public Vector2 CalculatePos(Vector2 startPos, Vector2 startVel, float iterations)
    {
        for (int i = 0; i < iterations; i++)
        {


        }
        return finalPos;
    }*/
}
