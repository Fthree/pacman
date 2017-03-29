using UnityEngine;
using System.Collections.Generic;

public class WaypointHandler : MonoBehaviour {
    List<Transform> getChildren(string tagName)
    {
        GameObject waypoints = GameObject.FindGameObjectWithTag(tagName);
        List<Transform> result = new List<Transform>();
        for(int i = 0; i != waypoints.transform.childCount; i++)
        {
            result.Add(waypoints.transform.GetChild(i));
        }

        return result;
    }


    public List<Transform> GetWaypoints(GhostType type)
    {
        switch(type)
        {
            case GhostType.Blinky:
                return getChildren("BlinkyWaypoints");
            case GhostType.Inky:
                return getChildren("InkyWaypoints");
            case GhostType.Pinky:
                return getChildren("PinkyWaypoints");
            case GhostType.Clyde:
                return getChildren("ClydeWaypoints");
            default:
                return new List<Transform>();

        }
    }
}
