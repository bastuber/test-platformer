using NUnit.Framework;
using System;
using System.Collections.Generic;
using UnityEngine;
public class MovingPlatform : MonoBehaviour
{
    public List<Transform> WayPoints;

    public float Speed;

    private float t = 0;
    private int wayPointIndex = 0;
    private bool goForward = true;


    private void FixedUpdate()
    {
        if (WayPoints == null || WayPoints.Count < 2)
        {
            Console.WriteLine("Error: Not enough waypoints defined");
            return;
        }

        Vector3 startPos = WayPoints[wayPointIndex].position;
        Vector3 endPos;
        if (goForward)
        {
            endPos = WayPoints[wayPointIndex + 1].position;
        }
        else
        {
            endPos = WayPoints[wayPointIndex - 1].position;
        }

        t += Time.fixedDeltaTime * Speed;
        Vector3 newPos = Vector3.Lerp(startPos, endPos, t);

        if (t >= 1.0f)
        {
            t = 0;

            if (goForward)
            {
                wayPointIndex++;
                if (wayPointIndex == WayPoints.Count - 1)
                {
                    goForward = false;
                }
            }
            else
            {
                wayPointIndex--;
                if (wayPointIndex == 0)
                {
                    goForward = true;
                }
            }
        }

        var rigidBody = GetComponent<Rigidbody2D>();
        rigidBody.MovePosition(newPos);
    }
}
