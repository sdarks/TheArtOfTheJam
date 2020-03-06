using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.TerrainAPI;

public class Card : MonoBehaviour
{
    public string cardName;
    public Color colour = Color.white;
    public bool held = false;

    void Init(string cardName, Color colour)
    {
        this.cardName = cardName;
        this.colour = colour;

        GetComponentInChildren<SpriteRenderer>().color = colour;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            held = true;
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                Debug.Log(hit.transform.name);
                if (hit.transform.name == "MyObjectName")
                {
                    print("My object is clicked by mouse");
                }
            }
        } else if (!Input.GetMouseButton(0))
        {
            held = false;
        }
        
        if (held)
        {
            Vector3 mousePosition = Input.mousePosition;
            mousePosition.z = 5;
            Vector3 position = Camera.main.ScreenToWorldPoint(mousePosition);
            Debug.Log(mousePosition);
            Debug.Log(position);
           // position.z = -5;
           // Debug.Log(transform.rotation);
          // transform.rotation = new Quaternion(0, -0.5f, 0.5f, 0.5f);
            transform.position = position;
        }
        
        
    }

}
