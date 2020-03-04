using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleManagerMono : MonoBehaviour
{
    public static PuzzleManagerMono inst;
    public int levelNumber;
    public PuzzleManager puzzleManager;

    private void Awake()
    {
        if (inst == null)
        {
            inst = this;
        }
        else
        {
            Destroy(this);
            Debug.LogError("Multiple PuzzleManagerMono detected, deleting the newest");
        }
    }

    void Start()
    {
        Level level = Levels.GetLevel(levelNumber);

        // Puzzle objectives are ready
        puzzleManager = new PuzzleManager(level.objectives);

        // Create our RoomObjects now

    }
}
