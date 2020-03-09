using System;
using System.Collections.Generic;
using UnityEngine;

public class MachineButton : UnityEngine.MonoBehaviour
{
    public bool on = true;
    public CardReceiver machine;
    public List<Sprite> spriteSwitchList = new List<Sprite>();
    private int n = 0;

    public void Start()
    {
        machine.GetComponent<SpriteRenderer>().sprite = spriteSwitchList[0];
    }

    public void switchSprite()
    {
        n++;
        if (n >= spriteSwitchList.Count)
        {
            n = 0;
        }
        machine.GetComponent<SpriteRenderer>().sprite = spriteSwitchList[n];

    }
}