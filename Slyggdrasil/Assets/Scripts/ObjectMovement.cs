//Script used to move an object between waypoints
//Assisted by Coding in Flow on YouTube
//https://www.youtube.com/watch?v=UlEE6wjWuCY
//Script started: 10/05/2023
//Script finished 10/05/2023
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMovement : MonoBehaviour
{
    [SerializeField]
    private GameObject[] waypoints; //Store game objects as waypoints in the editor
    [SerializeField]
    private float velocity = 200.0f;

    private int currentWaypointIndex = 0;



    // Update is called once per frame
    private void Update()
    {
        if (Vector2.Distance(waypoints[currentWaypointIndex].transform.position, transform.position) < 0.1f)
        {
            currentWaypointIndex++;
            if(currentWaypointIndex >= waypoints.Length)
            {
                currentWaypointIndex = 0;
            }
        }

        transform.position = Vector2.MoveTowards(transform.position, waypoints[currentWaypointIndex].transform.position, Time.deltaTime*velocity); //Move every frame towards the target waypoint by the set velocity
    }
}
