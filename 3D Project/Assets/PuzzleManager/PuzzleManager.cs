﻿using System.Collections.Generic;

public class PuzzleManager
{
    private List<PuzzleNode> objectives;

    private bool[] objectivesCompleted;

    public PuzzleManager(List<PuzzleNode> objectives)
    {
        this.objectives = objectives;
        objectivesCompleted = new bool[objectives.Count];
    }

    public void parseAction(RoomAction action)
    {
        for (int i = 0; i < objectives.Count; i++)
        {
            if (objectives[i].requirement.satisfiedBy(action))
            {
                if (objectives[i].next != null)
                {
                    objectives[i] = objectives[i].next;
                }
                else
                {
                    //objective completed.
                    objectivesCompleted[i] = true;
                }
            }
        }

    }

    public bool[] GetObjectivesCompleted()
    {
        return objectivesCompleted;
    }

}