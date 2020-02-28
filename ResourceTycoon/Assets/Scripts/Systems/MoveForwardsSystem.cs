using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MoveForwardSystem : BaseSystem
{

	public override void Start()
	{
		ComponentTypes.Add(typeof(MovementSpeedComponent));
		ComponentTypes.Add(typeof(MoveForwardsComponent));
	}

	public override void SystemUpdate( Archetype Arc )
	{

		//Get the list of archetypes
		List<BaseComponent> MovementSpeedComponents = Arc.Components[Arc.ComponentTypeMap[typeof(MovementSpeedComponent)]];
		bool playerComp = Arc.HasComponent(typeof(PlayerComponent));
           
        List<BaseComponent> MoveForwardsComponents = Arc.Components[Arc.ComponentTypeMap[typeof(MoveForwardsComponent)]];

        //Loop through all the components this could be burst compiled
        for (int i = 0; i < MovementSpeedComponents.Count; i++)
        {
            MovementSpeedComponent MSC = (MovementSpeedComponent)MovementSpeedComponents[i];
            MoveForwardsComponent MFC = (MoveForwardsComponent)MoveForwardsComponents[i];

            if (MFC.Move)
            {
                MSC.ParentEntity.transform.position = MSC.ParentEntity.transform.position + (MSC.MoveSpeed * Time.deltaTime * MSC.ParentEntity.transform.forward);
            }
        }
        
        
    }
}
