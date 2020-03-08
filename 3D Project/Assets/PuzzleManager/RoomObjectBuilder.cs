using System.Collections.Generic;


public class RoomObjectBuilder
{

    Dictionary<string, string> objectProperties = new Dictionary<string, string>();

    public RoomObjectBuilder addProperty(string type, string value)
    {
        objectProperties[type] = value;
        return this;
    }

    public RoomObject build()
    {
        RoomObject o = new RoomObject(objectProperties);
        objectProperties = new Dictionary<string, string>();
        return o;
    }


}
