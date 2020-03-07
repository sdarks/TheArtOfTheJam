﻿using System;
using UnityEngine;
using UnityEngine.UIElements;

public class MainController : MonoBehaviour
{
    public static MainController controller;
    public Card heldCard;

    public void Awake()
    {
        if (controller == null)
        {
            controller = this;
        }
        else
        {
            Destroy(this);
            Debug.Log("Error: MainController created while MainController.controller was not null. Deleting this instance.");
        }
    }

    public void Update(){
        
        
        if (heldCard != null)
        {
            if (heldCard.cardReceiver != null)
            {
                var heldCardPosition = heldCard.transform;
                heldCardPosition.position =
                    heldCard.cardReceiver.transform.position + heldCard.cardReceiver.cardPosition;
                heldCardPosition.eulerAngles = heldCard.cardReceiver.cardRotation;
            } 
            else if (!Input.GetMouseButton(0))
            {
                heldCard.transform.position = heldCard.tablePosition.transform.position;
                heldCard.transform.eulerAngles = new Vector3(90,0,90);
                heldCard.GetComponent<BoxCollider>().enabled = true;
                heldCard = null;
            }
            else
            {
                Vector3 mousePosition = Input.mousePosition;
                mousePosition.z = 5;
                Vector3 position = Camera.main.ScreenToWorldPoint(mousePosition);
                heldCard.transform.position = position;
                heldCard.transform.eulerAngles = new Vector3(0,0,0);
            }
        }
        
        
        

    }

    public void holdCard(Card c)
    {
        if (heldCard == null)
        {
            heldCard = c;
            heldCard.GetComponent<BoxCollider>().enabled = false;
        }
        else
        {
            Debug.Log("Can't pick up a card while holding one.");
        }
    }

}