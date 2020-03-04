﻿using System.Collections.Generic;


public class RoomObject
{
    public Dictionary<string, string> properties = new Dictionary<string, string>();

    public RoomObject(Dictionary<string, string> properties)
    {
        this.properties = properties;
    }

    public bool satisfiedBy(RoomObject o)
    {
        foreach(KeyValuePair<string, string> entry in properties)
        {
            if (!o.properties.ContainsKey(entry.Key)) return false;

            if (properties[entry.Key] != o.properties[entry.Key]) return false;
        }

        return true;
    }
}

