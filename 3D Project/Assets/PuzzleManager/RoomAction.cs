﻿using System.Collections.Generic;

public class RoomAction
{
    public List<RoomObject> objects;
    public string actionType;

    public RoomAction(List<RoomObject> objects, string actionType)
    {
        this.objects = objects;
        this.actionType = actionType;
    }

    public bool satisfiedBy(RoomAction action)
    {
        if (this.objects.Count != action.objects.Count) return false;

        if (this.actionType != action.actionType) return false;

        for (int i = 0; i < objects.Count; i++)
        {
            if (!objects[i].satisfiedBy(action.objects[i])) return false;
        }

        return true;
    }

}