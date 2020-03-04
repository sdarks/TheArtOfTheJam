using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleManagerMono : MonoBehaviour
{
    public int levelNumber;

    // Start is called before the first frame update
    void Start()
    {
        Level level = Levels.GetLevel(levelNumber);

        // Puzzle objectives are ready
        PuzzleManager puzzleManager = new PuzzleManager(level.objectives);

        // Create our RoomObjects now

    }
}
