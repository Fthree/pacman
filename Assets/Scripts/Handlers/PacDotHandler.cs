using UnityEngine;
using System.Collections.Generic;

public class PacDotHandler : MonoBehaviour {

    public PacDot PacDotPrefab;
    private List<PacDot> PacDot = new List<PacDot>();

    public void Initialize(List<IntVector2> pacDotCoordinates, Transform parent)
    {
        PacDot = new List<PacDot>();
        foreach(IntVector2 PacDotCoordinate in pacDotCoordinates)
        {
            PacDot instance = Instantiate(PacDotPrefab) as PacDot;
            instance.transform.SetParent(parent);
            instance.Initialize(PacDotCoordinate);
            PacDot.Add(instance);
        }
    }

    void Update () {
	
	}

    public void Destroy()
    {
        PacDot.ForEach(delegate (PacDot pacdot)
        {
            Destroy(pacdot.gameObject);
        });
    }
}
