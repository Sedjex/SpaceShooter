using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowThePath : MonoBehaviour
{
    // array of waypoints which enemy moves in a wave
    public Transform[] PathPoints;
    //speed enemy
    public float SpeedEnemy;
    //destroy the surving enemies at the end of the path or send them to beginning of the path
    public bool IsReturn;

    //store vector3 of all the waypoints Debug....................
    public Vector3[] NewPosition;
    //............................................................

    //current waypoint to which the enemy is moving
    private int _curPos;

    private void Start()
    {
        NewPosition = NewPositionByPath(PathPoints);
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
        return pathPositions;
    }
}
