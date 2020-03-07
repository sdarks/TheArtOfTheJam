using System;
using UnityEngine;

public class MouseHandler : UnityEngine.MonoBehaviour
{
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                MonoBehaviour cardBehaviour = hit.collider.gameObject.GetComponent<Card>();
                if (cardBehaviour != null)
                {
                    MainController.controller.holdCard((Card) cardBehaviour);
                }
            }
        }

        if (MainController.controller.heldCard != null)
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            bool hitReceiver = false;

            if (Physics.Raycast(ray, out hit))
            {
                MonoBehaviour receiver = hit.collider.gameObject.GetComponent<CardReceiver>();
                if (receiver != null)
                {
                    MainController.controller.heldCard.cardReceiver = (CardReceiver) receiver;
                    hitReceiver = true;
                }
            }

            if (!hitReceiver) MainController.controller.heldCard.cardReceiver = null;
        }
        

    }
}