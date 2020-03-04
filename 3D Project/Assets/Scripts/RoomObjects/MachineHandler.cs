using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineHandler : MonoBehaviour
{



    private void OnTriggerEnter(Collider other)
    {
        //Do some logic here to check if it's the correct card

        RoomStateManager.inst.IncrementProgress();
        Destroy(other.gameObject);
    }
}
