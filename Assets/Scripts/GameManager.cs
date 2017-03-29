using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

    public GhostHandler ghostHandler;
    public PacmanHandler pacmanHandler;
    public MazeHandler mazeHandler;

    // Use this for initialization
    void Start () {

        //ghostHandler.Initialize();
        pacmanHandler.Initialize();
        mazeHandler.Initialize();
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
