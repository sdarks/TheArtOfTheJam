﻿using System.Collections.Generic;


public class RoomObject
{
    public Dictionary<string, string> properties = new Dictionary<string, string>();

    public RoomObject(Dictionary<string, string> properties)
    {
        this.properties = properties;
    }
}

