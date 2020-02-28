using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireSystem : BaseSystem
{
	public override void Start()
	{
		ComponentTypes.Add(typeof(FireComponent));
	}

	public override void SystemUpdate( Archetype Arc )
	{

		List<BaseComponent> FireComponents = Arc.Components[Arc.ComponentTypeMap[typeof(FireComponent)]];

		//Loop through all the components this could be burst compiled
		for (int i = 0; i < FireComponents.Count; i++)
		{
			FireComponent FC = (FireComponent)FireComponents[i];
            if (FC.Firing)
            {
                if (Time.time >= FC.LastFiredTime + FC.Cooldown)
                {
                    FC.LastFiredTime = Time.time;
						
					SystemSystem.inst.CreateEntity(FC.Projectile, null, FC.ParentEntity.transform.position, FC.ParentEntity.transform.rotation, Vector3.zero, FC.FireForce * FC.ParentEntity.transform.forward, -1);
				}
                FC.Firing = false;
            }
        }
        

        
    }
}
