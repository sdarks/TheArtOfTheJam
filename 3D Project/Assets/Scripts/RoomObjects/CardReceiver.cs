﻿using UnityEngine;

public class CardReceiver : MonoBehaviour
{
    public Vector3 cardPosition;
    public Vector3 cardRotation;

    public string objectName;

    RoomObjectBuilder objectBuilder;
    RoomActionBuilder actionBuilder;

    public void Start()
    {
        actionBuilder = new RoomActionBuilder();
        objectBuilder = new RoomObjectBuilder();
    }

    public PuzzleManagerResponse receiveCard(Card c)
    {
        RoomObject machine = objectBuilder.addProperty("type", "machine").addProperty("name", gameObject.name).build();

        objectBuilder
            .addProperty("type", "card")
            .addProperty("colour", c.colour.ToString());
        if (c.number > 0)
        {
            objectBuilder.addProperty("number", c.number.ToString());
        }
        RoomObject card = objectBuilder.build();

        RoomAction placeCardIntoMachine = actionBuilder.addObject(card).addObject(machine).setAction("put in").build();
        
        return PuzzleManagerMono.inst.puzzleManager.parseAction(placeCardIntoMachine);
    }
}