using UnityEngine;
using System.Collections.Generic;

public class PacDotHandler : MonoBehaviour {

    public PacDot PacDotPrefab;
    private List<PacDot> PacDotInstances = new List<PacDot>();

    public void Initialize(List<IntVector2> pacDotCoordinates, Transform parent)
    {
        foreach(IntVector2 PacDotCoordinate in pacDotCoordinates)
        {
            PacDot instance = Instantiate(PacDotPrefab) as PacDot;
            instance.transform.SetParent(parent);
            instance.Initialize(PacDotCoordinate);
            PacDotInstances.Add(instance);
        }
    }

    void Update () {
	
	}
}
