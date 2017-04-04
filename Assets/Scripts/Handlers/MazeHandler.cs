using UnityEngine;
using System.Collections;

public class MazeHandler : MonoBehaviour {

    public Maze mazePrefab;
    private Maze maze;

    private MazeCoordinatesDto coordinates;

    public PacDotHandler pacDotHandler;

    // Use this for initialization
    public void Initialize() {
        maze = Instantiate(mazePrefab) as Maze;

        coordinates = MazeUtil.getMazeCoordinates();
        pacDotHandler.Initialize(coordinates.pacDotCoordinates, maze.transform);
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public void Destroy()
    {
        Destroy(maze.gameObject);
        pacDotHandler.Destroy();
    }
}
