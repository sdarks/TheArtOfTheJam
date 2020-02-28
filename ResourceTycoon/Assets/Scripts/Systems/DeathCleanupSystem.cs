using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathCleanupSystem : BaseSystem
{
	public override void Start()
	{
		ComponentTypes.Add(typeof(DamageableComponent));
	}

	public override void SystemUpdate( Archetype Arc )
	{
		List<BaseComponent> Damageables = Arc.Components[Arc.ComponentTypeMap[typeof(DamageableComponent)]];
		int numDamageables = Damageables.Count;
		for(int i=0; i < numDamageables; i++)
		{
			DamageableComponent dam = (DamageableComponent)Damageables[i];
			if (dam.CurrentHP <= 0)
			{
				GameObject.Destroy(dam.ParentEntity.gameObject);
			}

		}
        
    }
}
