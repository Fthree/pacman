using UnityEngine;
using System.Collections;

public class PacmanHandler : MonoBehaviour {

    public Pacman pacmanPrefab;
    private Pacman pacmanInstance;

    public void Initialize()
    {
        pacmanInstance = Instantiate(pacmanPrefab) as Pacman;
    }

    // Update is called once per frame
    void Update () {
	
	}
}
