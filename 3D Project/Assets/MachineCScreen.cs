using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineCScreen : MonoBehaviour
{
    public SpriteRenderer screen;
    public TextMesh screenNumber;

    public Texture2D[] staticTextureArray;
    private int currentTextureNumber;

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

        if (staticTextureArray.Length == 0)
        {
            Debug.LogError("Not enough static textures for MachineCColourScreen!!");
            Destroy(this);
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Check if machine is on first
        if (!PuzzleManagerMono.inst.puzzleManager.machineOn())
        {
            if (currentTextureNumber == staticTextureArray.Length) { currentTextureNumber = 0; }
        }



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
