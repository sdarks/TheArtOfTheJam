using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class PuzzleManagerTests
    {
        // Using a single green card and machine, we will see if we can complete a simple objective which is
        // To put each green card into the machine
        [Test]
        public void PassSingleObjective()
        {
            // Use the Assert class to test conditions
            RoomObjectBuilder objectBuilder = new RoomObjectBuilder();
            RoomActionBuilder actionBuilder = new RoomActionBuilder();

            RoomObject card = objectBuilder.addProperty("type", "card").build();

            RoomObject machine = objectBuilder.addProperty("type", "container").addProperty("name", "machine").build();

            RoomAction action = actionBuilder.addObject(card).addObject(machine).setAction("put in").build();

            List<PuzzleNode> objectives = new List<PuzzleNode>();

            PuzzleNode objective = new PuzzleNode(null, null, action);             // This objectives have no requirements or previous needed actions
            objectives.Add(objective);


            PuzzleManager manager = new PuzzleManager(objectives);
            // Setup is now complete
            // Now lets try running a single action

            // Objective should start false
            bool[] objectivesCompleted = manager.GetObjectivesCompleted();
            Assert.AreEqual(objectivesCompleted[0], false);

            // Then be completed by doing the required action
            manager.parseAction(action);
            objectivesCompleted = manager.GetObjectivesCompleted();
            Assert.AreEqual(objectivesCompleted[0], true);
        }

        // Complete an objective that requires us to first change a green card to blue, then put the blue card into another machine
        [Test]
        public void TurnGreenCardBlue()
        {
            // Use the Assert class to test conditions
            RoomObjectBuilder objectBuilder = new RoomObjectBuilder();
            RoomActionBuilder actionBuilder = new RoomActionBuilder();

            RoomObject greenCard = objectBuilder.addProperty("type", "card").addProperty("colour", "green").build();
            RoomObject blueCard = objectBuilder.addProperty("type", "card").addProperty("colour", "blue").build();

            RoomObject colourMachine = objectBuilder.addProperty("type", "container").addProperty("name", "colourMachine").build();
            RoomObject copyMachine = objectBuilder.addProperty("type", "container").addProperty("name", "copyMachine").build();

            RoomAction placeGreenCardIntoColourMachine = actionBuilder.addObject(greenCard).addObject(colourMachine).setAction("put in").build();
            RoomAction placeBlueCardIntoCopyMachine = actionBuilder.addObject(blueCard).addObject(copyMachine).setAction("put in").build();

            List<PuzzleNode> objectives = new List<PuzzleNode>();

            // Create final objective first, then create Green card objective
            PuzzleNode copyBlueCardObjective = new PuzzleNode(null, null, placeBlueCardIntoCopyMachine);
            PuzzleNode createBlueCardObjective = new PuzzleNode(null, copyBlueCardObjective, placeGreenCardIntoColourMachine);
            objectives.Add(createBlueCardObjective);

            PuzzleManager manager = new PuzzleManager(objectives);
            // Setup is now complete

            // Objective should start false
            bool[] objectivesCompleted = manager.GetObjectivesCompleted();
            Assert.AreEqual(objectivesCompleted[0], false);

            // Then be completed by doing the required action
            manager.parseAction(placeGreenCardIntoColourMachine);
            objectivesCompleted = manager.GetObjectivesCompleted();
            Assert.AreEqual(objectivesCompleted[0], false);

            // Should still be not complete
            // Then we put a blue card into copy machine to finish
            manager.parseAction(placeBlueCardIntoCopyMachine);
            objectivesCompleted = manager.GetObjectivesCompleted();
            Assert.AreEqual(objectivesCompleted[0], true);
        }
    }
}