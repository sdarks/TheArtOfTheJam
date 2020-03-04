using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineHandler : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Collidor was hit");
        // Run our machine process
        SendMessage("machineProcess", other.gameObject);
    }
}
