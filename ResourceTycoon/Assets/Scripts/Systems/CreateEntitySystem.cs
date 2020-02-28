using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static SystemSystem;
using UnityEngine.SceneManagement;

public class CreateEntitySystem : BaseSystem
{
    public List<CreateEntityEvent> CreateEntityEvents = new List<CreateEntityEvent>();
    public void CreateEntity(CreateEntityEvent e)
    {
        CreateEntityEvents.Add(e);
    }

	public override void Start()
	{
		
	}

	public override void SystemUpdate( Archetype Arc )
	{

		foreach (CreateEntityEvent E in CreateEntityEvents)
        {
            GameObject obj = GameObject.Instantiate(E.Prefab, E.Position, E.Rotation, E.Parent);
            if(obj!=null)
            {
                Rigidbody rbody = obj.GetComponent<Rigidbody>();
                if(rbody)
                {
                    rbody.velocity = E.InitialVelocity;
                    rbody.AddForce(E.InitialForce);
                }
            }
            
        }

        CreateEntityEvents.Clear();
    }
}
