using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireOnMouseClickSystem : BaseSystem
{
	public override void Start()
	{
		ComponentTypes.Add(typeof(FireComponent));
		ComponentTypes.Add(typeof(FireOnMouseClickComponent));
		ComponentTypes.Add(typeof(PlayerInputComponent));
	}

	public override void SystemUpdate( Archetype Arc )
	{
		List<BaseComponent> FireComponents = Arc.Components[Arc.ComponentTypeMap[typeof(FireComponent)]];
		List<BaseComponent> PlayerInputComponents = Arc.Components[Arc.ComponentTypeMap[typeof(PlayerInputComponent)]];

		//Loop through all the components this could be burst compiled
		for (int i = 0; i < FireComponents.Count; i++)
        {
            FireComponent FC = (FireComponent)FireComponents[i];
            PlayerInputComponent PIC = (PlayerInputComponent)PlayerInputComponents[i];
            if (PIC.MouseDown)
            {
                FC.Firing = true;
            }
        }
        

    }
}
