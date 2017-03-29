using UnityEngine;
using System.Collections;

public class PacDot : MonoBehaviour {
    public void Initialize(IntVector2 coordinate)
    {
        transform.localPosition = coordinate.toVector2();
    }

   void OnTriggerEnter2D(Collider2D co) { 
        if (co.name.Contains("Pacman"))
        {
            Destroy(gameObject);
        }
    }
}
