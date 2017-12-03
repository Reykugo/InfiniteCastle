using UnityEngine;
using System.Collections;

public class MonsterDetectorScript : MonoBehaviour
{

    private MonsterScript monsterScript;

    private void Start()
    {
        monsterScript = transform.parent.GetComponent<MonsterScript>();
    }

    void OnTriggerEnter(Collider c)
    {
        if (c.tag == "Player")
        {
            monsterScript.MoveOnPlayer = true;
        }
    }

    void OnTriggerExit(Collider c)
    {
        if (c.tag == "Player")
        {
            monsterScript.MoveOnPlayer = false;
        }
    }
}
