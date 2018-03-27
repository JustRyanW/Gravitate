using UnityEngine;
using System.Collections.Generic;

public class GravityController : MonoBehaviour
{
    /*public float globalGravityScale = 10f;
    public List<GameObject> Attractors;
    public Vector2 currentVelocity;

    void OnEnable()
    {
        if (Attractors == null)
            Attractors = new List<GameObject>();
        foreach (GameObject attractor in GameObject.FindGameObjectsWithTag("Attractor"))
        {
            Attractors.Add(attractor);
        }
    }

    void FixedUpdate()
    {
        //Attract();
        if (!GetComponent<Rigidbody2D>().isKinematic)
        transform.position = NextPos(transform.position, currentVelocity);
    }

    public Vector2 NextPos(Vector2 currentPos, Vector2 currentVelocity)
    {
        Vector2 nextPos = (Vector2)transform.position + currentVelocity;
        foreach (GameObject attractor in Attractors)
        {
            Vector2 dir = attractor.transform.position - transform.position;
            float distance = dir.magnitude;

            float forceMagnitude = globalGravityScale * (attractor.GetComponent<Rigidbody2D>().mass) / distance / 2;
            Vector2 moveToAttractor = dir.normalized * forceMagnitude;
            Debug.DrawRay(Vector2.zero, nextPos);
            nextPos += moveToAttractor;
        }
        currentVelocity += nextPos;
        return currentVelocity;
    }*/





    
    public bool drawForce = false;
    public bool isLinear = true;
    public float globalGravityScale = 10f;
    public List<GameObject> Attractors;
    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void OnEnable()
    {
        if (Attractors == null)
            Attractors = new List<GameObject>();
        foreach (GameObject attractor in GameObject.FindGameObjectsWithTag("Attractor"))
        {
            Attractors.Add(attractor);
        }
    }

    void FixedUpdate()
    {
        Attract();
    }

    void Attract()
    {
        foreach (GameObject attractor in Attractors)
        {
            Rigidbody2D attractorRb = attractor.GetComponent<Rigidbody2D>();

            Vector2 direction = attractorRb.position - rb.position;
            float distance = direction.magnitude;

            float forceMagnitude = (isLinear) ? globalGravityScale * (rb.mass * attractorRb.mass) / distance / 2 : globalGravityScale * (rb.mass * attractorRb.mass) / Mathf.Pow(distance, 2);
            Vector2 force = direction.normalized * forceMagnitude;

            if (drawForce)
                Debug.DrawRay(transform.position, direction, Color.Lerp(Color.blue, Color.red, forceMagnitude / (globalGravityScale / 4)));

            rb.AddForce(force);
        }
    }
}