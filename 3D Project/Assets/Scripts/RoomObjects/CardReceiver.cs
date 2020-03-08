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

    public bool receiveCard(Card c)
    {
        RoomObject machine = objectBuilder.addProperty("type", "machine").addProperty("name", gameObject.name).build();

        RoomObject card = objectBuilder.addProperty("type", "card").addProperty("colour", c.colour.ToString()).build();

        RoomAction placeCardIntoMachine = actionBuilder.addObject(card).addObject(machine).setAction("put in").build();
        
        return PuzzleManagerMono.inst.puzzleManager.parseAction(placeCardIntoMachine);
    }
}