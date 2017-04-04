using UnityEngine;
using System.Collections.Generic;

public static class MazeUtil {
    public static MazeCoordinatesDto getMazeCoordinates()
    {
        IntVector2[,] pacdotCoords = new IntVector2[100, 100]; //Any size large enough to fill the whole maze
        IntVector2 initialPosition = new IntVector2(2, 2); //bottom left
        MazeDirection currentDirection = MazeDirection.North;

        FFDiscoverMaze(initialPosition, currentDirection, pacdotCoords);

        List<IntVector2> retPDCoords = new List<IntVector2>();

        for(int y = 0; y != 100; y++)
        {
            for (int x = 0; x != 100; x++)
            {
                if(pacdotCoords[x, y] != null)
                {
                    retPDCoords.Add(pacdotCoords[x, y]);
                }
            }
        }

        MazeCoordinatesDto ret = new MazeCoordinatesDto();
        ret.pacDotCoordinates = retPDCoords;

        return ret;
    }
    
    private static void FFDiscoverMaze(IntVector2 position, MazeDirection direction, IntVector2[,] pacdotCoords)
    {
        if(pacdotCoords[position.x, position.z] != null)
        {
            //have we visited this position already?
            return;
        }

        //Distance is half a unit to account for sides
        RaycastHit2D hit = Physics2D.Raycast(position.toVector2(), direction.ToIntVector2().toVector2(), 0.5f);

        if(hit)
        {
            //fall back after hitting something
            return;
        }

        pacdotCoords[position.x, position.z] = position;

        //Go in all directions 
        MazeDirection nextDir = MazeDirection.North;
        FFDiscoverMaze(position + nextDir.ToIntVector2(), nextDir, pacdotCoords);
        nextDir = MazeDirection.East;
        FFDiscoverMaze(position + nextDir.ToIntVector2(), nextDir, pacdotCoords);
        nextDir = MazeDirection.South;
        FFDiscoverMaze(position + nextDir.ToIntVector2(), nextDir, pacdotCoords);
        nextDir = MazeDirection.West;
        FFDiscoverMaze(position + nextDir.ToIntVector2(), nextDir, pacdotCoords);
    }
}
