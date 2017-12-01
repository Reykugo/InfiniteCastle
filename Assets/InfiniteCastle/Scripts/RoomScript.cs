using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class RoomScript : MonoBehaviour
{

    public GameObject DoorToNextLevel;
    public List<GameObject> Monsters = new List<GameObject>();

    public List<GameObject> ObjectsToFind = new List<GameObject>();
    // Use this for initialization
    void Start()
    {
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
    }
}
