using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineHandler : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	private void OnTriggerEnter( Collider other )
	{
		//Do some logic here to check if it's the correct card

		RoomStateManager.inst.IncrementProgress();
		Destroy(other.gameObject);
	}
}
