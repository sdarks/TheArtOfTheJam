using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.TerrainAPI;

public class Card : MonoBehaviour
{
    public CardPosition tablePosition;

    private CardReceiver cardReceiver;
    public CardReceiver CardReceiver
    {
        get => cardReceiver;
        set => cardReceiver = value;
    }

    private CardOutputter cardOutputter;
    public CardOutputter CardOutputter
    {
        get => cardOutputter;
        set => cardOutputter = value;
    }

    static public Dictionary<string, Color> colourMap = new Dictionary<string, Color>();
    static public List<Sprite> cardNumberSprites = new List<Sprite>();

    public Colour colour;
    public int number = 0;
    private BoxCollider collider;

    private SpriteRenderer renderer;

    public SpriteRenderer Renderer => renderer;

    private RoomObject roomObject;

    public RoomObject RoomObject => roomObject;

    public BoxCollider Collider
    {
        get => collider;
    }

    public enum Colour
    {
        green,
        red,
        white
    };


    private void Awake()
    {
        this.transform.position = tablePosition.transform.position;
        collider = GetComponent<BoxCollider>();
        renderer = GetComponent<SpriteRenderer>();

        generateRoomObject();

    }

    public void Start()
    {
        changeNumberSprite(number);
    }

    private void generateRoomObject()
    {
        RoomObjectBuilder builder = new RoomObjectBuilder();

        builder.addProperty("type", "card");
        if (colour != Colour.white) builder.addProperty("colour", colour.ToString());
        if (number > 0) builder.addProperty("number", number.ToString());

        roomObject = builder.build();
    }

    public void changeNumberSprite(int n)
    {
        renderer.sprite = cardNumberSprites[n];
    }

    public void changeCard(Dictionary<string, string> changeMap)
    {
        foreach (KeyValuePair<string, string> pair in changeMap)
        {
            roomObject.properties[pair.Key] = pair.Value;
        }

        if (changeMap.ContainsKey("colour"))
        {
            colour = (Colour)Enum.Parse(typeof(Colour), changeMap["colour"]);
            renderer.color = Card.colourMap[changeMap["colour"]];
        }

        if (changeMap.ContainsKey("number"))
        {
            number = Int32.Parse(changeMap["number"]);
            changeNumberSprite(number);
        }
    }

}
