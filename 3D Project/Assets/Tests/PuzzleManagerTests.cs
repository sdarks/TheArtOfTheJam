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
    }
}
