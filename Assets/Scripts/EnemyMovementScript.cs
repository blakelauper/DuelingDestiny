using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class EnemyMovementScript : MonoBehaviour
{
    [SerializeField]
    private GameObject[] waypoints; // An array of GameObject waypoints
    [SerializeField]
    private float speed = 5.0f;
    private int currentWayPointIndex = 0; // Index of the current waypoint

    // Update is called once per frame
    void Update()
    {
        MoveToWaypoint();

        // Face the direction of movement
        if (waypoints.Length > 0)
        {
            Vector2 direction = waypoints[currentWayPointIndex].transform.position - transform.position;
            FlipSprite(direction.x);
        }
    }

    private void MoveToWaypoint()
    {
        if (Vector2.Distance(waypoints[currentWayPointIndex].transform.position, transform.position) < 0.1f)
        {
            currentWayPointIndex++;
            if (currentWayPointIndex >= waypoints.Length)
            {
                currentWayPointIndex = 0;
            }
        }

        transform.position = Vector2.MoveTowards(transform.position, waypoints[currentWayPointIndex].transform.position, Time.deltaTime * speed);
    }

    private void FlipSprite(float directionX)
    {
        // Flip the sprite based on the direction
        if (directionX > 0)
        {
            transform.localScale = new Vector3(1.5f, 1.5f, 1); // Facing right
        }
        else if (directionX < 0)
        {
            transform.localScale = new Vector3(-1.5f, 1.5f, 1); // Facing left
        }
    }
}
