﻿using System.Collections.Generic;

public class RoomAction
{
    private List<RoomObject> objects;
    private string actionType;

    public RoomAction(List<RoomObject> objects, string actionType)
    {
        this.objects = objects;
        this.actionType = actionType;
    }

    public bool equals(RoomAction action)
    {
        if (this.objects.Count != action.objects.Count) return false;

        if (this.actionType != action.actionType) return false;

        for (int i = 0; i < objects.Count; i++)
        {
            if (this.objects[i] != action.objects[i]) return false;
        }

        return true;
    }

}