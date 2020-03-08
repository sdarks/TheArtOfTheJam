﻿using System;
 using System.Collections.Generic;
 using UnityEngine;

 public class PuzzleManager
{
    private RoomObject lastCard;
    private int lastNumber = 0;
    
    private bool ascending = true;
    
    private string machineCColour;
    private string machineCMode;

    private Dictionary<string, bool> machineStatusMap = new Dictionary<string, bool>();

    public PuzzleManager()
    {
        machineStatusMap["machineA"] = true;
        machineStatusMap["machineB"] = true;
        machineStatusMap["machineC"] = true;
    }

    public bool parseAction(RoomAction action)
    {
        if (action.actionType == "put in")
        {
            RoomObject card = action.objects[0];
            RoomObject machine = action.objects[1];

            if ((card.properties["type"] != "card") || (machine.properties["type"] != "machine"))
            {
                return false;
            }
            else
            {
                return cardInMachine(card, machine);
            }
        }
        else
        {
            return false;
        }

        return true;
    }

    public bool cardInMachine(RoomObject card, RoomObject machine)
    {
        string machineName = machine.properties["name"];

        if (!machineStatusMap[machineName])
        {
            return false;
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

        if (card.properties.ContainsKey("number"))
        {
            int n = Int32.Parse(card.properties["number"]);
            if (@ascending && n < lastNumber)
            {
                return false;
            } else if (!@ascending && n > lastNumber)
            {
                return false;
            }
        }

        switch (machineName)
        {
            case "machineA":
                if (cardColour != "green")
                {
                    return false;
                }
                machineStatusMap["machineB"] = true;
                @ascending = !@ascending;
                break;
            case "machineB":
                if (cardColour != "red")
                {
                    return false;
                }
                machineStatusMap["machineB"] = false;
                break;
            case "machineC":
                break;
        }

        return true;
    }

    public bool[] GetObjectivesCompleted()
    {
        return null;
    }

}