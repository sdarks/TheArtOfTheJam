using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.TerrainAPI;

public class Card : MonoBehaviour
{
    public string cardName;
    public GameObject tablePosition;
    public CardReceiver cardReceiver;
    public Colour colour;
    public int number = 0;
    private BoxCollider collider;

    public BoxCollider Collider
    {
        get => collider;
    }

    public enum Colour
    {
        green,
        red,
        white
    };

    private void Awake()
    {
        this.transform.position = tablePosition.transform.position;
        collider = GetComponent<BoxCollider>();
    }
}
