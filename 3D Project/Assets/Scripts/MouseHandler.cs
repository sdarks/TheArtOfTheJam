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
					RoomStateManager.inst.PlayMouseDownSound();
                }
                else
                {
                    MonoBehaviour machineButton = hit.collider.gameObject.GetComponent<MachineButton>();
                    if (machineButton != null)
                    {
                        MachineButton machineButtonCast = (MachineButton) machineButton;
                        machineButtonCast.on = !machineButtonCast.@on;
                        PuzzleManagerMono.inst.puzzleManager.switchMode(machineButtonCast.on);
                        machineButtonCast.switchSprite();
                        print(machineButtonCast.on);
                    }
                }
            }
        }

        if (Input.GetMouseButton(0) && MainController.controller.heldCard != null)
        {
            Cursor.visible = false;
        }
        else
        {
            Cursor.visible = true;
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
                    MainController.controller.heldCard.CardReceiver = (CardReceiver) receiver;
                    hitReceiver = true;
                }
            }

			if (!hitReceiver)
			{
				MainController.controller.heldCard.CardReceiver = null;
			}
        }
        

    }
}