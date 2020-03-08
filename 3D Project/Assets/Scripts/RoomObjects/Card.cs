using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.TerrainAPI;

public class Card : MonoBehaviour
{
    public string cardName;
    public CardPosition tablePosition;
    
    private CardReceiver cardReceiver;
    public CardReceiver CardReceiver
    {
        get => cardReceiver;
        set => cardReceiver = value;
    }

    private CardOutputter cardOutputter;
    public CardOutputter CardOutputter => cardOutputter;
    
    public Colour colour;
    public int number = 0;
    private BoxCollider collider;

    private RoomObject roomObject;

    public RoomObject RoomObject => roomObject;

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
        
        generateRoomObject();

    }

    private void generateRoomObject()
    {
        RoomObjectBuilder builder = new RoomObjectBuilder();

        builder.addProperty("type", "card");
        if (colour != Colour.white) builder.addProperty("colour", colour.ToString());
        if (number > 0) builder.addProperty("number", number.ToString());

        roomObject = builder.build();
    }
    
}
