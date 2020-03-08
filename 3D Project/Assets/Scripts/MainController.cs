using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UIElements;

public class MainController : MonoBehaviour
{
    public static MainController controller;
    public Card heldCard;

    private List<CardPosition> cardPositions = new List<CardPosition>();

    private Dictionary<CardPosition, Card> cardMap;

    public List<Sprite> cardSprites;


    public void Awake()
    {
        if (controller == null)
        {
            controller = this;
        }
        else
        {
            Destroy(this);
            Debug.Log(
                "Error: MainController created while MainController.controller was not null. Deleting this instance.");
        }

        cardPositions.Capacity = 10;
        foreach (CardPosition pos in GetComponents<CardPosition>())
        {
            cardPositions[pos.index] = pos;
            cardMap[pos] = null;
        }

        foreach (Card card in GetComponents<Card>())
        {
            cardMap[card.tablePosition] = card;
        }

        Card.colourMap["red"] = Color.red;
        Card.colourMap["green"] = Color.green;
        Card.colourMap["white"] = Color.white;

        Card.cardNumberSprites = cardSprites;
    }

    public void Update(){
        
        
        if ((heldCard != null) && (heldCard.CardOutputter == null))
        {
            if (!Input.GetMouseButton(0))
            {
                if (heldCard.CardReceiver != null)
                {
                    PuzzleManagerResponse response = heldCard.CardReceiver.receiveCard(heldCard);
					RoomStateManager.inst.InsertCardSound();
					switch (response.ResponseType)
                    {
                        case PuzzleManagerResponse.Type.Delete:
                            GameObject.Destroy(heldCard.gameObject);
							RoomStateManager.inst.GoodAction();
                            break;
                        case PuzzleManagerResponse.Type.Change:
                            changeCard(heldCard, heldCard.CardReceiver, response);
							RoomStateManager.inst.GoodAction();
							break;
                        case PuzzleManagerResponse.Type.Fail:
                            RoomStateManager.inst.invalidAction();
                            releaseCard();
                            break;
                        case PuzzleManagerResponse.Type.Error:
                            Debug.Log("Error action type received, most likely occurs if a card is released into a non-machine type Card Receiver.");
                            break;
                    }
                }
                else
                {
                    releaseCard();
                }
            }
            else if (heldCard.CardReceiver != null)
            {
                var heldCardPosition = heldCard.transform;
                heldCardPosition.position =
                    heldCard.CardReceiver.transform.position + heldCard.CardReceiver.cardPosition;
                heldCardPosition.eulerAngles = heldCard.CardReceiver.cardRotation;
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

    public void addNewCard(Card card)
    {
        foreach (CardPosition c in cardPositions)
        {
            if (cardMap[c] == null)
            {
                cardMap[c] = card;
                card.tablePosition = c;
            }
        }
    }

    public void changeCard(Card card, CardReceiver receiver, PuzzleManagerResponse response)
    {
        card.tablePosition = null;
        card.CardOutputter = receiver.gameObject.GetComponent<CardOutputter>();
    }

    public void releaseCard()
    {
        heldCard.transform.position = heldCard.tablePosition.transform.position;
        heldCard.transform.eulerAngles = new Vector3(90, 0, 90);
        heldCard.Collider.enabled = true;
        heldCard = null;
		RoomStateManager.inst.PlayMouseUpSound();
	}

    public void holdCard(Card c)
    {
        if (heldCard == null)
        {
            heldCard = c;
            heldCard.Collider.enabled = false;
        }
        else
        {
            Debug.Log("Can't pick up a card while holding one.");
        }
    }

}
