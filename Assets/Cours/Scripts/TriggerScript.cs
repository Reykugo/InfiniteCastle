using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerScript : MonoBehaviour {

    

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Debut");
    }

    private void OnTriggerStay(Collider other)
    {
        Debug.Log("Stay");
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("Exit");
    }
}
