using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateTowardsMouseSystem : BaseSystem
{
	public override void Start()
	{
		ComponentTypes.Add(typeof(RotateTowardsMouseComponent));
		ComponentTypes.Add(typeof(RotateTargetComponent));
		ComponentTypes.Add(typeof(PlayerInputComponent));
	}

	public override void SystemUpdate( Archetype Arc )
	{
		
        //Get the list of components in this archetype
        List<BaseComponent> PlayerInputComponents = Arc.Components[Arc.ComponentTypeMap[typeof(PlayerInputComponent)]];
        List<BaseComponent> RotateTargetComponents = Arc.Components[Arc.ComponentTypeMap[typeof(RotateTargetComponent)]];

        //Loop through all the components this could be burst compiled
        for (int i = 0; i < PlayerInputComponents.Count; i++)
        {
            PlayerInputComponent PIC = (PlayerInputComponent)PlayerInputComponents[i];
            RotateTargetComponent RTC = (RotateTargetComponent)RotateTargetComponents[i];

            if (PIC.MouseWorldPosition != Vector3.zero)
            {
                RTC.TargetPosition = PIC.MouseWorldPosition;
            }
            else
            {
                RTC.TargetPosition = PIC.ParentEntity.transform.position;
            }
        }
        
        

    }

}
