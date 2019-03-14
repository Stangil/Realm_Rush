using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    void Start()
    {
        Pathfinder pathfinder = FindObjectOfType<Pathfinder>();
        var path = pathfinder.getPath();
        StartCoroutine(FollowPath(path));
    }


    IEnumerator FollowPath(List<Waypoint> path)//co-routine
    {
        print("Starting Patrol...");
        foreach (Waypoint waypoint in path)
        {
            print("Visiting Block: " + waypoint.name);
            transform.position = waypoint.transform.position;
            yield return new WaitForSeconds(1f);
        }
        print("Ending patrol");
    }
}
