using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputSystem : BaseSystem
{
	public override void Start()
	{
		ComponentTypes.Add(typeof(PlayerInputComponent));
	}

	public override void SystemUpdate( Archetype Arc )
	{
		//Player movement
		Vector3 playerAxis = Vector3.zero;
        //y = rotation
        //z = forward
        //x = strafe
        if (Input.GetKey(KeyCode.W))
        {
            playerAxis.z++;
        }
        if (Input.GetKey(KeyCode.A))
        {
            playerAxis.x--;
        }
        if (Input.GetKey(KeyCode.S))
        {
            playerAxis.z--;
        }
        if (Input.GetKey(KeyCode.D))
        {
            playerAxis.x++;
        }
        playerAxis.Normalize();

        //Mouse position in world
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Transform objectHit = null;
        Vector3 mousePos = Vector3.zero;
        if (Physics.Raycast(ray, out hit))
        {
            objectHit = hit.transform;
            mousePos = hit.point;
        }

        //Mouse click
        bool mouseClick = Input.GetMouseButton(0);

		//Mini system in system


		//Get the list of components in this archetype
		List<BaseComponent> PlayerInputComponents = Arc.Components[Arc.ComponentTypeMap[typeof(PlayerInputComponent)]];

		//Loop through all the components this could be burst compiled
		for (int i = 0; i < PlayerInputComponents.Count; i++)
        {
            PlayerInputComponent PIC = (PlayerInputComponent)PlayerInputComponents[i];

            PIC.PlayerMovementAxis = playerAxis;
            PIC.MouseWorldPosition = mousePos;
            PIC.MouseDown = mouseClick;
        }
        
        
    }
}