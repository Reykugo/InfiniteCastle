using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{

    private bool canOpen = false;

    void OnTriggerEnter(Collider c)
    {
        canOpen = true;
    }

  

    void Update()
    {
        if (canOpen)
        {
            Up();
        }     
    }

    void Up()
    {
        Vector3 pos = this.transform.position;
        this.transform.localPosition += this.transform.up * Time.deltaTime;
    }
}
