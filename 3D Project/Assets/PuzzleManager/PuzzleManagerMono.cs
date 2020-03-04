using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleManagerMono : MonoBehaviour
{
    public int levelNumber;

    // Start is called before the first frame update
    void Start()
    {
        PuzzleManager puzzleManager = new PuzzleManager(Levels.GetLevelObjectives(levelNumber));
    }
}
