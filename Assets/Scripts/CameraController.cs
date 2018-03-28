using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CameraController : MonoBehaviour {

    public List<Transform> targets;

    public Vector3 offset;

    void LateUpdate()
    {
        float camSize = Vector2.Distance(targets[0].position, targets[1].position) / 1.8f;
        if (camSize > 5)
        {
            Camera.main.orthographicSize = camSize;
        }
        
        if (targets.Count == 0)
            return;

        Vector3 centerPoint = GetCenterPoint();
        Vector3 newPosition = centerPoint + offset;
        transform.position = newPosition;
    }

    Vector3 GetCenterPoint()
    {
        if (targets.Count == 1)
        {
            return targets[0].position;
        }

        var bounds = new Bounds(targets[0].position, Vector3.zero);
        for (int i = 0; i < targets.Count; i++)
        {
            bounds.Encapsulate(targets[i].position);
        }
        return bounds.center;
    }
}
