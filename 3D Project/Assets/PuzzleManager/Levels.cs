using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// We use this to store all our level Objectives
public static class Levels
{
    static RoomObjectBuilder objectBuilder = new RoomObjectBuilder();
    static RoomActionBuilder actionBuilder = new RoomActionBuilder();

    public static Level GetLevel(int levelNumber)
    {
        switch (levelNumber)
        {
            case 0:
                return Level0();
            case 1:
            // return Level1();
            case 2:
            // return Level2();
            default:
                return null;
        }
    }

    // Level 1 wants us to place three green cards into the "Grongle" machine and two blue cards into the "Blorble" machine
    private static Level Level0()
    {
        List<RoomObject> roomObjects = new List<RoomObject>();
        List<PuzzleNode> objectives = new List<PuzzleNode>();

        // Level Setup
        // Cards
        RoomObject greenCard = objectBuilder.addProperty("type", "card").addProperty("colour", Color.green.ToString()).build();
        RoomObject blueCard = objectBuilder.addProperty("type", "card").addProperty("colour", Color.blue.ToString()).build();

        // Machines
        RoomObject grongleMachine = objectBuilder.addProperty("type", "container").addProperty("name", "Grongle").build();
        RoomObject blorbleMachine = objectBuilder.addProperty("type", "container").addProperty("name", "Blorble").build();

        roomObjects.Add(greenCard);
        roomObjects.Add(greenCard);
        roomObjects.Add(greenCard);
        roomObjects.Add(blueCard);
        roomObjects.Add(blueCard);
        roomObjects.Add(grongleMachine);
        roomObjects.Add(blorbleMachine);

        // Actions that we are looking for
        // Level (These are all good as well)
        RoomAction placeGreenCardIntoGrongleMachine = actionBuilder.addObject(greenCard).addObject(grongleMachine).setAction("put in").build();
        RoomAction placeBlueCardIntoBlorbleMachine = actionBuilder.addObject(blueCard).addObject(blorbleMachine).setAction("put in").build();

        // Bad actions
        RoomAction placeGreenCardIntoBlorbleMachine = actionBuilder.addObject(greenCard).addObject(blorbleMachine).setAction("put in").build();
        RoomAction placeBlueCardIntoGrongleMachine = actionBuilder.addObject(blueCard).addObject(grongleMachine).setAction("put in").build();

        // Build objectives
        PuzzleNode obj1 = new PuzzleNode(null, null, placeGreenCardIntoGrongleMachine, ObjectiveType.Level);
        obj1 = new PuzzleNode(null, obj1, placeGreenCardIntoGrongleMachine, ObjectiveType.Good);
        obj1 = new PuzzleNode(null, obj1, placeGreenCardIntoGrongleMachine, ObjectiveType.Good);
        objectives.Add(obj1);

        PuzzleNode obj2 = new PuzzleNode(null, null, placeBlueCardIntoBlorbleMachine, ObjectiveType.Level);
        obj2 = new PuzzleNode(null, obj2, placeBlueCardIntoBlorbleMachine, ObjectiveType.Good);
        objectives.Add(obj2);

        // Bad objectives as well
        PuzzleNode badObj1 = new PuzzleNode(null, null, placeGreenCardIntoBlorbleMachine, ObjectiveType.Bad);
        objectives.Add(badObj1);
        PuzzleNode badObj2 = new PuzzleNode(null, null, placeBlueCardIntoGrongleMachine, ObjectiveType.Bad);
        objectives.Add(badObj2);

        return new Level(roomObjects, objectives);
    }

    // Level 2 expects us to change each card to its complementary colour using the "ChangeColour" machine, then "Fax" it
    // private static Level Level1()
    // {
    //      return new Level();
    // }

    // level 3 wants us to add all the number cards together, then fax it
    // private static Level Level2()
    // {
    //     return new Level();
    // }

}
