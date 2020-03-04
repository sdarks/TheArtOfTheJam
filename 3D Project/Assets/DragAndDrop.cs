using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragAndDrop : MonoBehaviour
{
	private bool Dragging = false;
	private float DragDistance = 0.0f;
	public float FudgeFactor = 0.99f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

	private void OnMouseEnter()
	{
		
	}

	private void OnMouseExit()
	{
		
	}

	private void OnMouseDown()
	{
		DragDistance = Vector3.Distance(transform.position, Camera.main.transform.position);
		Dragging = true;
	}

	private void OnMouseUp()
	{
		Dragging = false;
	}

	// Update is called once per frame
	void Update()
    {
        if(Dragging)
		{
			Ray Ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			Vector3 RayPoint = Ray.GetPoint(DragDistance*FudgeFactor);
			transform.position = RayPoint;
			
		}
    }
}
