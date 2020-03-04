using System;
using System.Collections.Generic;
using PuzzleManager;

    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello");
            
            RoomObjectBuilder objectBuilder = new RoomObjectBuilder();
            RoomActionBuilder actionBuilder = new RoomActionBuilder();

            RoomObject greenCard = objectBuilder.addProperty("colour", "green")
                .addProperty("type", "card")
                .build();

            RoomObject redCard = objectBuilder.addProperty("colour", "red")
                .addProperty("type", "card")
                .build();
            
            
            RoomObject blorginator = objectBuilder.addProperty("type", "container")
                .addProperty("name", "blorginator")
                .build();
            
            RoomObject fooblestopper = objectBuilder.addProperty("type", "container")
                .addProperty("name", "fooblestopper")
                .build();

            RoomAction action1 = actionBuilder.addObject(greenCard)
                .addObject(blorginator)
                .setAction("put in")
                .build();

            RoomAction action2 = actionBuilder.addObject(redCard)
                .addObject(fooblestopper)
                .setAction("put in")
                .build();

            List<PuzzleNode> objectives = new List<PuzzleNode>();
            
            PuzzleNode node = new PuzzleNode(null, null, action1);
            
            node = new PuzzleNode(null, node, action1);
            node = new PuzzleNode(null, node, action1);
            node = new PuzzleNode(null, node, action1);
            node = new PuzzleNode(null, node, action1);
            objectives.Add(node);

            node = new PuzzleNode(null, null, action2);
            node = new PuzzleNode(null, node, action2);
            node = new PuzzleNode(null, node, action2);
            node = new PuzzleNode(null, node, action2);
            node = new PuzzleNode(null, node, action2);
            objectives.Add(node);
            
            PuzzleManager manager = new PuzzleManager(objectives);

        }
    }