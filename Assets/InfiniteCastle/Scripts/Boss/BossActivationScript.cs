using UnityEngine;
using System.Collections;

public class BossActivationScript : MonoBehaviour
{

    [SerializeField]
    BossScript bossScript;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            bossScript.PlayerIsOnArea = true;
        }
    }
}
