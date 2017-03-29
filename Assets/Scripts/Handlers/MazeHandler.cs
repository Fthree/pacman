using UnityEngine;
using System.Collections;

public class MazeHandler : MonoBehaviour {

    public Maze mazePrefab;
    private Maze mazeInstance;

    private MazeCoordinatesDto coordinates;

    public PacDotHandler pacDotHandler;

    // Use this for initialization
    public void Initialize() {
        mazeInstance = Instantiate(mazePrefab) as Maze;

        coordinates = MazeUtil.getMazeCoordinates();
        pacDotHandler.Initialize(coordinates.pacDotCoordinates, mazeInstance.transform);
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
