using System.Collections.Generic;

public class PuzzleManagerResponse
{
    public enum Type
    {
        Delete,
        Change,
        Fail,
        Error
    }

    private Dictionary<string, string> changeMap = new Dictionary<string, string>();

    public Dictionary<string, string> ChangeMap => changeMap;

    private Type responseType;

    public Type ResponseType => responseType;

    public PuzzleManagerResponse(Type responseType, Dictionary<string, string> changeMap)
    {
        this.responseType = responseType;
        this.changeMap = changeMap;
    }

    public PuzzleManagerResponse(Type responseType)
    {
        this.responseType = responseType;
    }
}