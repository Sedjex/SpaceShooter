using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowThePath : MonoBehaviour
{
    // array of waypoints which enemy moves in a wave
    [HideInInspector]
    public Transform[] PathPoints;
    [HideInInspector]
    public float SpeedEnemy;
    //destroy the surving enemies at the end of the path or send them to beginning of the path
    [HideInInspector]
    public bool IsReturn;

    //store vector3 of all the waypoints Debug....................
    [HideInInspector]
    public Vector3[] NewPosition;
    //............................................................

    //current waypoint to which the enemy is moving
    private int _curPos;

    private void Start()
    {
        NewPosition = NewPositionByPath(PathPoints);
        transform.position = NewPosition[0];
    }

    private void Update()
    {
        //move the current enemy to the points of the path with the given speed
        transform.position = Vector3.MoveTowards(transform.position, NewPosition[_curPos], SpeedEnemy * Time.deltaTime);
        //if the current enemy has reached the point of the path
        if (Vector3.Distance(transform.position, NewPosition[_curPos]) < 0.2f)
        {
            //set the next waypoint
            _curPos++;

            //if the rurrent enemy reaches the last point and IsReturn = true, send the enemy to the starting waypoint
            if (IsReturn && Vector3.Distance(transform.position, NewPosition[NewPosition.Length - 1]) < 0.3f)
                _curPos = 0;

            //if the enemy reaches the last point and IsReturn = false, destroy the enemy
            if (Vector3.Distance(transform.position, NewPosition[NewPosition.Length - 1]) < 0.2f && !IsReturn)
                Destroy(gameObject);
        }
    }

    Vector3[] NewPositionByPath(Transform[] pathPos)
    {
        Vector3[] pathPositions = new Vector3[pathPos.Length];
        for (int i = 0; i < PathPoints.Length; i++)
        {
            pathPositions[i] = pathPos[i].position;
        }

        //pathPositions = Smoothing(pathPositions);
        //pathPositions = Smoothing(pathPositions);

        return pathPositions;
    }

    //Vector3[] Smoothing(Vector3[] pathPositions)
    //{
    //    Vector3[] newPathPosition = new Vector3[(pathPositions.Length - 2) * 2 + 2];
    //    newPathPosition[0] = pathPositions[0];
    //    newPathPosition[newPathPosition.Length - 1] = pathPositions[pathPositions.Length - 1];
    //    int j = 1;
    //    for (int i = 0; i < pathPositions.Length - 2; i++)
    //    {
    //        newPathPosition[j] = pathPositions[i] + (pathPositions[i + 1] - pathPositions[i]) * 0.75f;

    //        pathPositions[j + 1] = pathPositions[i + 1] + (pathPositions[i + 2] - pathPositions[i + 1]) * 0.25f;
    //        j += 2;
    //    }
    //    return newPathPosition;
    //}
}
