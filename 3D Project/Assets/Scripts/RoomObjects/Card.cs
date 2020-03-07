using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.TerrainAPI;

public class Card : MonoBehaviour
{
    public string cardName;
    public Color colour = Color.white;
    public GameObject tablePosition;
    public CardReceiver cardReceiver;

    void Init(string cardName, Color colour)
    {
        this.cardName = cardName;
        this.colour = colour;

        GetComponentInChildren<SpriteRenderer>().color = colour;
    }

    private void Awake()
    {
        this.transform.position = tablePosition.transform.position;
    }

    void Update()
    {
        // if (Input.GetMouseButtonDown(0))
        // {
        //     RaycastHit hit;
        //     Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        //
        //     if (Physics.Raycast(ray, out hit))
        //     {
        //         MainController.controller.holdCard((Card) hit.collider.gameObject.GetComponent<Card>());
        //     }
        // } 
    }

}
