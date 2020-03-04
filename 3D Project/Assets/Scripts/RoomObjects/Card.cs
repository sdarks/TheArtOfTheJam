using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    public string cardName;
    public Color colour = Color.white;

    void Init(string cardName, Color colour)
    {
        this.cardName = cardName;
        this.colour = colour;

        GetComponentInChildren<SpriteRenderer>().color = colour;
    }
}
