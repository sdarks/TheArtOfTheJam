using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineCColourScreen : MonoBehaviour
{
    public SpriteRenderer screen;

    void Start()
    {
        if (screen == null)
        {
            Debug.LogError("No screen detected for MachineCColourScreen!");
            Destroy(this);
        }
    }

    // Update is called once per frame
    void Update()
    {
        screen.color = PuzzleManagerMono.inst.puzzleManager.GetMachineCColor();
    }
}
