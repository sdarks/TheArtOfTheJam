using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SystemSystem : MonoBehaviour
{
	


	public static SystemSystem inst;
    public EntityManageSystem EMSystem;
	public BreakSystem BreakSystem;
	public CreateEntitySystem CreateEntitySystem;
	public DeathCleanupSystem DeathCleanupSystem;
	public FireOnMouseClickSystem FireOnMouseClickSystem;
	public FireSystem FireSystem;
	public InputSystem InputSystem;
	public PlayerControllerSystem PlayerControllerSystem;
	public GraphSystem GraphSystem;
	public MoveForwardSystem MoveForwardsSystem;
	public RotateTowardsMouseSystem RotateTowardsMouseSystem;
	public RotateTowardsTargetSystem RotateTowardsTargetSystem;
    void Awake()
    {
        if (inst)
        {
            Destroy(this);
        }
        else
        {
            inst = this;

			EMSystem = new EntityManageSystem();

			CreateEntitySystem = new CreateEntitySystem();
			InputSystem = new InputSystem();
			PlayerControllerSystem = new PlayerControllerSystem();

			RotateTowardsMouseSystem = new RotateTowardsMouseSystem();
			RotateTowardsTargetSystem = new RotateTowardsTargetSystem();
			MoveForwardsSystem = new MoveForwardSystem();

			FireOnMouseClickSystem = new FireOnMouseClickSystem();
			FireSystem = new FireSystem();

			BreakSystem = new BreakSystem();

			GraphSystem = new GraphSystem();

			EMSystem.Start();
			CreateEntitySystem.Start();
			GraphSystem.Start();
			InputSystem.Start();
			PlayerControllerSystem.Start();
			RotateTowardsMouseSystem.Start();
			RotateTowardsTargetSystem.Start();
			MoveForwardsSystem.Start();
			FireOnMouseClickSystem.Start();
			FireSystem.Start();
			BreakSystem.Start();
		}

    }

   
    // Update is called once per frame
    void Update()
    {
		/*
         * Current systems flow:
		 * 
		 * 
		 */


		//Manage entities always first!
		EMSystem.Update();

		CreateEntitySystem.Update();

		InputSystem.Update();
		PlayerControllerSystem.Update();

		RotateTowardsMouseSystem.Update();
		RotateTowardsTargetSystem.Update();
		MoveForwardsSystem.Update();

		FireOnMouseClickSystem.Update();
		FireSystem.Update();

		BreakSystem.Update();

		GraphSystem.Update();

	}


	/******************* EVENTS ******************/


	public struct CreateEntityEvent
	{
		public GameObject Prefab;
		public Transform Parent;
		public Vector3 Position;
		public Quaternion Rotation;
		public Vector3 InitialForce;
		public Vector3 InitialVelocity;
		public int TeamID;
	}

	public void CreateEntity( GameObject inpPrefab, Transform inpParent, Vector3 inpPosition, Quaternion inpRotation, Vector3 inpInitialForce, Vector3 inpInitialVelocity, int TeamID )
	{
		CreateEntityEvent CEE = new CreateEntityEvent();
		CEE.Prefab = inpPrefab;
		CEE.Parent = inpParent;
		CEE.Position = inpPosition;
		CEE.Rotation = inpRotation;
		CEE.InitialForce = inpInitialForce;
		CEE.InitialVelocity = inpInitialVelocity;
		CEE.TeamID = TeamID;

		CreateEntitySystem.CreateEntity(CEE);

	}
}
