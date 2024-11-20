using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FEnemy : MonoBehaviour
{
    public float fSpeed = 3f;
    Rigidbody2D rb;
    public List<Transform> waypoints;
    GameManager gameManager;

    Transform nextWayPoint;
    int waypointNum = 0;
    public float waypointReached = 0.1f;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    private void Start()
    {
        nextWayPoint = waypoints[waypointNum];
    }

    private void FixedUpdate()
    {
        flight();
    }

    private void flight()
    {
        
        //fly to the next waypoint
        Vector2 directionToWaypoint = (nextWayPoint.position - transform.position).normalized;

        // check if already reached
        float distance = Vector2.Distance(nextWayPoint.position, transform.position);

        if (gameManager.gameActive)
        {
            rb.velocity = directionToWaypoint * fSpeed;
        }
        else
        {
            fSpeed = 0;
            rb.velocity = directionToWaypoint * fSpeed;
        }
        // see if need to switch waypoints
        if (distance < waypointReached)
        {
            // swtich next waypoint
            waypointNum++;
            if (waypointNum >= waypoints.Count)
            {
                waypointNum = 0;
            }
            nextWayPoint = waypoints[waypointNum];
        }
    }
}
