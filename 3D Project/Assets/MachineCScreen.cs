using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineCScreen : MonoBehaviour
{
    public SpriteRenderer screen;
    public TextMesh screenNumber;

    public Sprite[] staticTextureArray;
    private int currentTextureNumber;

    public Sprite normalScreenTexture;

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
            Debug.LogError("Not enough static sprites for MachineCColourScreen!!");
            Destroy(this);
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Check if machine is on first
        if (!PuzzleManagerMono.inst.puzzleManager.machineOn("machineC"))
        {
            screen.gameObject.transform.localScale = new Vector3(2, 2.5f, 1);
            if (currentTextureNumber == staticTextureArray.Length) { currentTextureNumber = 0; }
            screen.sprite = staticTextureArray[currentTextureNumber];
            currentTextureNumber++;
            screenNumber.text = "";
            screen.color = Color.white;
            return;
        }
        else
        {
            screen.gameObject.transform.localScale = new Vector3(1, 1, 1);
            screen.sprite = normalScreenTexture;
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
