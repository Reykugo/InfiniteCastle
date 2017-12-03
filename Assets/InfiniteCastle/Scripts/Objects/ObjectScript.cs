using UnityEngine;
using System.Collections;

public class ObjectScript : MonoBehaviour
{

    public GameObject TakeText;
    public string Name;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            TakeText.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            TakeText.SetActive(false);
        }
    }
}
