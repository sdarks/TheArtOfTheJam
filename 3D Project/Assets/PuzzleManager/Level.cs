using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// The data Storage for an entire Level
public class Level
{
    // Level Data
    public List<RoomObject> roomObjects { get; }
    public List<PuzzleNode> objectives { get; }

    public Level(List<RoomObject> roomObjects, List<PuzzleNode> objectives)
    {
        this.roomObjects = roomObjects;
        this.objectives = objectives;
    }

}
