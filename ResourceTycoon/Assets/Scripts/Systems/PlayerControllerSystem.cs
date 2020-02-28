using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerSystem : BaseSystem
{
	public override void Start()
	{
		ComponentTypes.Add(typeof(PlayerInputComponent));
		ComponentTypes.Add(typeof(RotateTowardsMouseComponent));
		ComponentTypes.Add(typeof(MoveForwardsComponent));
	}

	public override void SystemUpdate( Archetype Arc )
	{

		//Get the list of components in this archetype
		List<BaseComponent> PlayerInputComponents = Arc.Components[Arc.ComponentTypeMap[typeof(PlayerInputComponent)]];
		List<BaseComponent> RotateTargetComponents = Arc.Components[Arc.ComponentTypeMap[typeof(RotateTowardsMouseComponent)]];
        List<BaseComponent> MoveForwardComponents = Arc.Components[Arc.ComponentTypeMap[typeof(MoveForwardsComponent)]];

        //Loop through all the components this could be burst compiled
        for (int i = 0; i < PlayerInputComponents.Count; i++)
        {
            PlayerInputComponent PIC = (PlayerInputComponent)PlayerInputComponents[i];
			RotateTowardsMouseComponent RTC = (RotateTowardsMouseComponent)RotateTargetComponents[i];
            MoveForwardsComponent MFC = (MoveForwardsComponent)MoveForwardComponents[i];

            if ((PIC.PlayerMovementAxis.x != 0 || PIC.PlayerMovementAxis.z != 0))
            {
                Vector3 newPos = PIC.ParentEntity.transform.position;
                //Move forwards
                newPos.z += PIC.PlayerMovementAxis.z;
                newPos.x += PIC.PlayerMovementAxis.x;
				if(PIC.PlayerMovementAxis.z > 0)
					MFC.Move = true;

               
            }
            else
            {
                MFC.Move = false;
               
            }
        }
        
        
    }
}
