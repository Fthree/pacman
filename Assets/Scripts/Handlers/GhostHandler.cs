using UnityEngine;
using System.Collections.Generic;
using System;

public class GhostHandler : MonoBehaviour {

    public Ghost blinkyPrefab;
    public Ghost inkyPrefab;
    public Ghost pinkyPrefab;
    public Ghost clydePrefab;

    private Ghost blinky;
    private Ghost inky;
    private Ghost pinky;
    private Ghost clyde;

    public WaypointHandler waypointHandler;
    private WaypointHandler waypointHandlerInstance;

    private List<Ghost> ghosts;

    public void Initialize () {
        ghosts = new List<Ghost>();
        blinky = Instantiate(blinkyPrefab) as Ghost;
        inky = Instantiate(inkyPrefab) as Ghost;
        pinky = Instantiate(pinkyPrefab) as Ghost;
        clyde = Instantiate(clydePrefab) as Ghost;
        waypointHandlerInstance = Instantiate(waypointHandler) as WaypointHandler;

        blinky.Initialize(waypointHandlerInstance.GetWaypoints(GhostType.Blinky));
        inky.Initialize(waypointHandlerInstance.GetWaypoints(GhostType.Inky));
        pinky.Initialize(waypointHandlerInstance.GetWaypoints(GhostType.Pinky));
        clyde.Initialize(waypointHandlerInstance.GetWaypoints(GhostType.Clyde));

        ghosts.Add(blinky);
        ghosts.Add(inky);
        ghosts.Add(pinky);
        ghosts.Add(clyde);
    }

	void Update () {
	    
	}

    public void Pause()
    {
        ghosts.ForEach(delegate (Ghost ghost)
        {
            ghost.Pause();
        });
    }

    public void Resume()
    {
        ghosts.ForEach(delegate (Ghost ghost)
        {
            ghost.Resume();
        });
    }

    public void Destory()
    {
        ghosts.ForEach(delegate (Ghost ghost)
        {
            Destroy(ghost.gameObject);
        });

        Destroy(waypointHandlerInstance.gameObject);
    }
}
