using UnityEngine;
using System.Collections;

using System;

public class Pacman : MonoBehaviour {
    public float speed = 0.4f;
    public int lives = 3;
    Vector2 dest = Vector2.zero;

    bool isPaused = false;

    Action pacmanHit;

    void Start()
    {
        dest = transform.position;
    }

    void FixedUpdate()
    {
        if(isPaused)
        {
            return;
        }

        // Move closer to Destination
        Vector2 p = Vector2.MoveTowards(transform.position, dest, speed);
        GetComponent<Rigidbody2D>().MovePosition(p);

        // Check for Input if not moving
        if ((Vector2)transform.position == dest)
        {
            if (Input.GetKey(KeyCode.UpArrow) && valid(Vector2.up))
                dest = (Vector2)transform.position + Vector2.up;
            if (Input.GetKey(KeyCode.RightArrow) && valid(Vector2.right))
                dest = (Vector2)transform.position + Vector2.right;
            if (Input.GetKey(KeyCode.DownArrow) && valid(-Vector2.up))
                dest = (Vector2)transform.position - Vector2.up;
            if (Input.GetKey(KeyCode.LeftArrow) && valid(-Vector2.right))
                dest = (Vector2)transform.position - Vector2.right;
        }

        // Animation Parameters
        Vector2 dir = dest - (Vector2)transform.position;
        GetComponentInChildren<Animator>().SetFloat("DirX", dir.x);
        GetComponentInChildren<Animator>().SetFloat("DirY", dir.y);
    }

    bool valid(Vector2 dir)
    {

        // Cast Line from 'next to Pac-Man' to 'Pac-Man'
        Vector2 pos = transform.position;
        RaycastHit2D hit = Physics2D.Linecast(pos + dir, pos);

        if(hit.collider.tag.Equals("Pacdot"))
        {
            return true;
        }

        return (hit.collider == GetComponent<Collider2D>());
    }

    public void Initialize(Action pacmanHit)
    {
        this.pacmanHit = pacmanHit;
    }

    public void Pause()
    {
        isPaused = true;
    }

    public void Resume()
    {
        isPaused = false;
    }

    void OnTriggerEnter2D(Collider2D co)
    {
        if(co.tag.Equals("ghost"))
        {
            lives--;
            pacmanHit();
        }
    }
}
