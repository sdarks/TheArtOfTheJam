using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseSystem
{
    public abstract void SystemUpdate(Archetype Arc);
	public abstract void Start();
	public List<System.Type> ComponentTypes = new List<System.Type>();
	public void Update()
	{
		//Get the list of archetypes
		List<Archetype> ArchetypesToUpdate = EntityManageSystem.inst.GetArchetypesForUpdate(ComponentTypes);

		//Loop through the archetypes
		foreach (Archetype arc in ArchetypesToUpdate)
		{
			SystemUpdate(arc);
		}
	}
}
