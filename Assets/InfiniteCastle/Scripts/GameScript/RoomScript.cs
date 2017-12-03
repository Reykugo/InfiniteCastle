using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class RoomScript : MonoBehaviour
{

    public GameObject DoorToNextLevel;
    public List<GameObject> Monsters = new List<GameObject>();

    public List<GameObject> ObjectsToFind = new List<GameObject>();

    public GameObject FinishInfo;

    public bool isFinish = false; //only for debug to test next room
    // Use this for initialization
    void Start()
    {
        if(isFinish == true)
        {
            Finish();
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public virtual void MonsterHasBeenKilled(GameObject monster)
    {
        Monsters.Remove(monster);
        
    }

    public virtual void ObjectFinded(GameObject obj)
    {
        ObjectsToFind.Remove(obj);
    }

    public void Finish()
    {
        transform.parent.GetComponent<GameManagerScript>().NextRoom();
        if (FinishInfo)
        {
            DoorToNextLevel.GetComponent<SphereCollider>().enabled = true;
            FinishInfo.SetActive(true);
            Destroy(FinishInfo, 4);
        }
    }
}
