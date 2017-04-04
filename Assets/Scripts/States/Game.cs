using UnityEngine;
using System.Collections;

public class Game : MonoBehaviour {

    public GhostHandler ghostHandler;
    public PacmanHandler pacmanHandler;
    public MazeHandler mazeHandler;

    public void Initialize()
    {
        ghostHandler.Initialize();
        pacmanHandler.Initialize();
        mazeHandler.Initialize();
    }

	public void Resume()
    {
        ghostHandler.Resume();
        pacmanHandler.Resume();
    }

    public void Pause()
    {
        ghostHandler.Pause();
        pacmanHandler.Pause();
    }

	// Update is called once per frame
	void Update () {
	
	}

    public void DestroyGame()
    {
        ghostHandler.Destory();
        pacmanHandler.Destroy();
        mazeHandler.Destroy();
    }

}
