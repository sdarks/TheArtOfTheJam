using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrongleMachine : MonoBehaviour, MachineInterface
{
    static RoomObjectBuilder objectBuilder = new RoomObjectBuilder();
    static RoomActionBuilder actionBuilder = new RoomActionBuilder();

    static RoomObject greenCard = objectBuilder.addProperty("type", "card").addProperty("colour", "green").build();
    static RoomObject grongleMachine = objectBuilder.addProperty("type", "container").addProperty("name", "Grongle").build();
    static RoomAction placeGreenCardIntoGrongleMachine = actionBuilder.addObject(greenCard).addObject(grongleMachine).setAction("put in").build();

    public void machineProcess(GameObject processObject)
    {
        // Debug.Log("Grongle Machine Attempting to process Card!");
        // Check that this is a card first, then if it is green
        // If it is send a action to the PuzzleManager
        Card c = processObject.GetComponent<Card>();

        if (c != null)
        {
            if (c.colour == Color.green)
            {
                RoomStateManager.inst.IncrementProgress();
                PuzzleManagerMono.inst.puzzleManager.parseAction(placeGreenCardIntoGrongleMachine);
                // Debug.Log("Grongle Machine activated!");
            }
        }
    }
}
