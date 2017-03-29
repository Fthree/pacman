using UnityEngine;
using System.Collections.Generic;

public class GhostHandler : MonoBehaviour {

    public Ghost blinkyPrefab;
    public Ghost inkyPrefab;
    public Ghost pinkyPrefab;
    public Ghost clydePrefab;

    private Ghost blinkyInstance;
    private Ghost inkyInstance;
    private Ghost pinkyInstance;
    private Ghost clydeInstance;

    public WaypointHandler waypointHandler;
    private WaypointHandler waypointHandlerInstance;

    private List<Ghost> ghosts = new List<Ghost>();

    public bool disabled = false;

    public void Initialize () {
        blinkyInstance = Instantiate(blinkyPrefab) as Ghost;
        inkyInstance = Instantiate(inkyPrefab) as Ghost;
        pinkyInstance = Instantiate(pinkyPrefab) as Ghost;
        clydeInstance = Instantiate(clydePrefab) as Ghost;
        waypointHandlerInstance = Instantiate(waypointHandler) as WaypointHandler;

        blinkyInstance.Initialize(waypointHandlerInstance.GetWaypoints(GhostType.Blinky));
        inkyInstance.Initialize(waypointHandlerInstance.GetWaypoints(GhostType.Inky));
        pinkyInstance.Initialize(waypointHandlerInstance.GetWaypoints(GhostType.Pinky));
        clydeInstance.Initialize(waypointHandlerInstance.GetWaypoints(GhostType.Clyde));

        ghosts.Add(blinkyInstance);
        ghosts.Add(inkyInstance);
        ghosts.Add(pinkyInstance);
        ghosts.Add(clydeInstance);
    }

	void Update () {
	    if(disabled)
        {
            DisableGhosts();

        } else
        {
            EnableGhosts();
        }
	}

    void DisableGhosts()
    {
        ghosts.ForEach(delegate (Ghost ghost)
        {
            if (!ghost.isDisabled)
            {
                ghost.Disable();
            }
        });
    }

    void EnableGhosts()
    {
        ghosts.ForEach(delegate (Ghost ghost)
        {
            if (ghost.isDisabled)
            {
                ghost.Enable();
            }
        });
    }
}
