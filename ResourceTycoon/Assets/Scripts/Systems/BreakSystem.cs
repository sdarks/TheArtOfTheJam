using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakSystem : BaseSystem
{

	public override void Start()
	{
		ComponentTypes.Add(typeof(BreakableComponent));
		ComponentTypes.Add(typeof(DamageableComponent));
	}

	public override void SystemUpdate( Archetype Arc )
	{

        List<BaseComponent> Damageables = Arc.Components[Arc.ComponentTypeMap[typeof(DamageableComponent)]];
		List<BaseComponent> Breakables = Arc.Components[Arc.ComponentTypeMap[typeof(BreakableComponent)]];

		for (int i = 0; i < Damageables.Count; i++)
		{
			DamageableComponent dam = (DamageableComponent)Damageables[i];
			BreakableComponent brk = (BreakableComponent)Breakables[i];
			if (dam.CurrentHP <= 0)
			{
				//Break here
				foreach (GameObject GO in brk.PrefabsToBreakInto)
				{
					SystemSystem.inst.CreateEntity(GO, null, brk.transform.position, brk.transform.rotation, new Vector3(), new Vector3(), -1);
				}
			}
		}
        
    }
}
