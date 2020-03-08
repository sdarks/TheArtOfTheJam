using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrongleMachine : MonoBehaviour, MachineInterface
{
    static RoomObjectBuilder objectBuilder = new RoomObjectBuilder();
    static RoomActionBuilder actionBuilder = new RoomActionBuilder();

    static RoomObject grongleMachine = objectBuilder.addProperty("type", "container").addProperty("name", "Grongle").build();

    public void machineProcess(GameObject processObject)
    {
        // Debug.Log("Grongle Machine Attempting to process Card!");
        // Check that this is a card first, then if it is green
        // If it is send a action to the PuzzleManager
        Card c = processObject.GetComponent<Card>();

        // Build a card based on what we get

        if (c != null)
        {
            RoomObject cardToProcess = objectBuilder.addProperty("type", "card").addProperty("colour", c.colour.ToString()).build();

            RoomAction placeCardIntoGrongleMachine = actionBuilder.addObject(cardToProcess).addObject(grongleMachine).setAction("put in").build();
            if (true)
            {
                PuzzleManagerMono.inst.puzzleManager.parseAction(placeCardIntoGrongleMachine);
                //Debug.Log("Grongle Machine activated!");
            }
        }
    }
}
