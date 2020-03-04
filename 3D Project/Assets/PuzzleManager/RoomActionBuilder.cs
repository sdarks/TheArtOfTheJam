using System.Collections.Generic;
public class RoomActionBuilder
{
    private List<RoomObject> objects = new List<RoomObject>();
    private string action;

    public RoomActionBuilder addObject(RoomObject o)
    {
        objects.Add(o);
        return this;
    }

    public RoomActionBuilder setAction(string action)
    {
        this.action = action;
        return this;
    }

    public RoomAction build()
    {
        RoomAction a = new RoomAction(objects, action);
        objects.Clear();
        action = "";
        return a;
    }
}