using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineCScreen : MonoBehaviour
{
    public SpriteRenderer screen;
    public TextMesh screenNumber;

    void Start()
    {
        if (screen == null)
        {
            Debug.LogError("No screen detected for MachineCColourScreen!");
            Destroy(this);
        }

        if (screenNumber == null)
        {
            Debug.LogError("No screenNumber detected for MachineCColourScreen!");
            Destroy(this);
        }
    }

    // Update is called once per frame
    void Update()
    {
        // If we are in number mode, show a number
        if (PuzzleManagerMono.inst.puzzleManager.machineCModePublic == 1)
        {
            // Colour Mode
            screenNumber.text = "";
            screen.color = PuzzleManagerMono.inst.puzzleManager.GetMachineCColor();
        }
        else
        {
            // Number Mode
            screenNumber.text = PuzzleManagerMono.inst.puzzleManager.machineCNumberPublic.ToString();
            screen.color = Color.black;
        }
    }
}
