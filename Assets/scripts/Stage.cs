using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage : MonoBehaviour {

    public LineRenderer lineRenderer;
    public Waypoint[] waypoints;

    void Start()
    {
        List<Vector3> points = new List<Vector3>();

        foreach(Waypoint waypoint in waypoints)
        {
            points.Add(waypoint.transform.position);
        }
        lineRenderer.positionCount = points.Count;
        lineRenderer.SetPositions(points.ToArray());
    }
}