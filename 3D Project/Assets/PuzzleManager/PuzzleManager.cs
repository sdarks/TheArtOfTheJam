﻿using System;
 using System.Collections.Generic;
 using UnityEngine;

 public class PuzzleManager
{
    private RoomObject lastCard;
    private int lastNumber = 0;
    private string lastColour = "";
    private bool cardAdded = false;
    
    private bool ascending = true;
    
    private string machineCColour = "";
    private int machineCNumber = 0;
    
    private int machineCMode = 1;

    
    
    // 0 - Colour mode
    // 1 - Number mode

    //Details if a machine is turned on or off (not the same as enabled).
    private Dictionary<string, bool> machineStatusMap = new Dictionary<string, bool>();
    
    //Details if a machine is enabled or not.
    private Dictionary<string, bool> machineEnabledMap = new Dictionary<string, bool>();
    
    //Details what colours are allowed into which machines.
    private Dictionary<string, List<string>> machineValidColours = new Dictionary<string, List<string>>();

    public PuzzleManager()
    {
        machineStatusMap["machineA"] = true;
        machineValidColours["machineA"] = new List<string>();
        machineValidColours["machineA"].Add(Card.Colour.green.ToString());
        machineValidColours["machineA"].Add(Card.Colour.white.ToString());
            
        machineStatusMap["machineB"] = true;
        machineValidColours["machineB"] = new List<string>();
        machineValidColours["machineB"].Add(Card.Colour.red.ToString());
        machineValidColours["machineB"].Add(Card.Colour.white.ToString());
        
        machineStatusMap["machineC"] = true;
        machineValidColours["machineC"] = new List<string>();
        machineValidColours["machineC"].Add("all");


    }

    public PuzzleManagerResponse parseAction(RoomAction action)
    {
        if (action.actionType == "put in")
        {
            RoomObject card = action.objects[0];
            RoomObject machine = action.objects[1];

            if ((card.properties["type"] != "card") || (machine.properties["type"] != "machine"))
            {
                return new PuzzleManagerResponse(PuzzleManagerResponse.Type.Fail);
            }
            else
            {
                return cardInMachine(card, machine);
            }
        }
        else
        {
            return new PuzzleManagerResponse(PuzzleManagerResponse.Type.Fail);
        }
    }

    public PuzzleManagerResponse cardInMachine(RoomObject card, RoomObject machine)
    {
        PuzzleManagerResponse.Type responseType = PuzzleManagerResponse.Type.Error;
        Dictionary<string, string> changeMap = null;
        
        string machineName = machine.properties["name"];

        if (!machineStatusMap[machineName])
        {
            return new PuzzleManagerResponse(PuzzleManagerResponse.Type.Fail);
        }
        

        string cardColour;

        if (!card.properties.ContainsKey("colour"))
        {
            cardColour = "white";
        }
        else
        {
            cardColour = card.properties["colour"];
        }
        
        if (!(machineValidColours[machineName].Contains(cardColour) || machineValidColours[machineName].Contains("all")))
        {
            return new PuzzleManagerResponse(PuzzleManagerResponse.Type.Fail);
        }


        if (card.properties.ContainsKey("number") && cardAdded) 
        {
            int n = Int32.Parse(card.properties["number"]);

            if (@ascending && n <= lastNumber)
            {
                return new PuzzleManagerResponse(PuzzleManagerResponse.Type.Fail);
            } else if (!@ascending && n >= lastNumber)
            {
                return new PuzzleManagerResponse(PuzzleManagerResponse.Type.Fail);
            }
        }

        switch (machineName)
        {
            case "machineA":
                if (cardColour == "green")
                {
                    @ascending = !@ascending;
                    //RoomStateManager.inst.SetPlayReverse(@ascending);
                }
                machineStatusMap["machineB"] = true;
                responseType = PuzzleManagerResponse.Type.Delete;
                break;
            case "machineB":
                if(cardColour == "red") machineStatusMap["machineB"] = false;
                responseType = PuzzleManagerResponse.Type.Delete;
                machineStatusMap["machineC"] = true;
                break;
            case "machineC":
                responseType = PuzzleManagerResponse.Type.Change;
                changeMap = new Dictionary<string, string>();
                switch (machineCMode)
                {
                    case 1:
                        if (machineCColour == "") return new PuzzleManagerResponse(PuzzleManagerResponse.Type.Fail);
                        else
                        {
                            changeMap["colour"] = machineCColour; 
                            machineCColour = "";
                            machineCNumber = 0;
                        }
                        break;
                    case 2:
                        if (machineCNumber == 0) return new PuzzleManagerResponse(PuzzleManagerResponse.Type.Fail);
                        else
                        {
                            changeMap["number"] = machineCNumber.ToString();
                            machineCColour = "";
                            machineCNumber = 0;
                        }
                        break;
                }
               
                machineStatusMap["machineC"] = false;
                break;
        }

        cardAdded = true;
        if (card.properties.ContainsKey("number")) lastNumber = Int32.Parse(card.properties["number"]);

        if (cardColour != "white") lastColour = cardColour;
        
        lastCard = card;

        if (machineName != "machineC")
        {
            if(cardColour!="white") machineCColour = cardColour;
            if (card.properties.ContainsKey("number")) machineCNumber = Int32.Parse(card.properties["number"]);
        }

        if (responseType == PuzzleManagerResponse.Type.Change) return new PuzzleManagerResponse(responseType, changeMap);
        else return new PuzzleManagerResponse(responseType);

    }

    public void switchMode(bool b)
    {
        if (b) machineCMode = 1;
        else machineCMode = 2;
    }

    public Color GetMachineCColor()
    {
        if (machineCColour == "")
        {
            return Color.black;
            
        }
        return Card.colourMap[machineCColour];
    }

    public bool[] GetObjectivesCompleted()
    {
        //depreciated
        return null;
    }

}