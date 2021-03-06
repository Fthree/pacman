﻿using UnityEngine;
using System.Collections.Generic;

public class Ghost : MonoBehaviour {
    private List<Transform> waypoints;
    int cur = 0;

    public float speed = 0.3f;

    public bool isPaused = false;

    public void Initialize(List<Transform> waypoints)
    {
        this.waypoints = waypoints;
    }

    void FixedUpdate()
    {
        if (isPaused)
        {
            return;
        }

        // Waypoint not reached yet? then move closer
        float distance = Vector3.Distance(transform.position, waypoints[cur].position);
        if (distance >= 0.01f)
        {
            Vector2 p = Vector2.MoveTowards(transform.position,
                                            waypoints[cur].position,
                                            speed);
            GetComponent<Rigidbody2D>().MovePosition(p);
        }
        // Waypoint reached, select next one
        else cur = (cur + 1) % waypoints.Count;

        // Animation
        Vector2 dir = waypoints[cur].position - transform.position;
        GetComponentInChildren<Animator>().SetFloat("DirX", dir.x);
        GetComponentInChildren<Animator>().SetFloat("DirY", dir.y);
    }

    void OnTriggerEnter2D(Collider2D co)
    {
        if (co.tag.Equals("pacman"))
        {
            //this is where pacman might do something to the ghost
        }
    }

    public void Pause()
    {
        isPaused = true;
    }

    public void Resume()
    {
        isPaused = false;
    }
}
