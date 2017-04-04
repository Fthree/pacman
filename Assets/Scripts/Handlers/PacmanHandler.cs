using UnityEngine;
using System.Collections;

public class PacmanHandler : MonoBehaviour {

    public Pacman pacmanPrefab;
    private Pacman pacman;

    public void Initialize()
    {
        pacman = Instantiate(pacmanPrefab) as Pacman;
        pacman.Initialize(OnHit);
    }

    public void OnHit()
    {
        if(pacman.lives <= 0)
        {
            //DEAD
        }

        //decrease the lives reset the pacman
    }

    // Update is called once per frame
    void Update () {
	
	}

    public void Pause()
    {
        pacman.Pause();
    }

    public void Resume()
    {
        pacman.Resume();
    }

    public void Destroy()
    {
        Destroy(pacman.gameObject);
    }
}
