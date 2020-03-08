using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UIElements;

public class MainController : MonoBehaviour
{
    public static MainController controller;
    public Card heldCard;

    public List<CardPosition> cardPositions = new List<CardPosition>();

    private Dictionary<CardPosition, Card> cardMap = new Dictionary<CardPosition, Card>();

    public List<Sprite> cardSprites;

    private List<Card> cards = new List<Card>();
    
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
        
        foreach (CardPosition pos in cardPositions)
        {
            cardMap[pos] = null;
        }

        foreach(GameObject o in GameObject.FindGameObjectsWithTag("Card"))
        {
            Card c = o.GetComponent<Card>();
            cards.Add(c);
            cardMap[c.tablePosition] = c;
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
                        //PuzzleManagerMono.inst.puzzleManager.Ascending
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
                break;
            }
        }
    }

    public void changeCard(Card card, CardReceiver receiver, PuzzleManagerResponse response)
    {
        cardMap[card.tablePosition] = null;
        card.tablePosition = null;
        
        card.CardOutputter = receiver.gameObject.GetComponent<CardOutputter>();
        if (card.CardOutputter)
        {
            card.transform.position = card.CardOutputter.transform.position + card.CardOutputter.cardPosition;
            card.transform.eulerAngles = new Vector3(90, 0, 0);
            card.Collider.enabled = true;
            heldCard = null;
        }
        card.changeCard(response.ChangeMap);
    }

    public void releaseCard()
    {
        if (heldCard.tablePosition == null)
        {
            addNewCard(heldCard);
        }
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
            heldCard.CardOutputter = null;
        }
        else
        {
            Debug.Log("Can't pick up a card while holding one.");
        }
    }

}
