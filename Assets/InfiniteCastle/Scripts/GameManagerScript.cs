using UnityEngine;
using System;

public class GameManagerScript : MonoBehaviour
{

    private float inputTimer;

    [SerializeField]
    private GameObject[] ElementsToShowWhenInactive;

    [SerializeField]
    private GameObject[] Rooms;

    public int currentRoom = 0;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        ShowElementsWhenInactive();
    }


    void ShowElementsWhenInactive()
    {
        if (!Input.anyKey)
        {
            inputTimer += Time.deltaTime;
        }
        else
        {
            inputTimer = 0;
            foreach (GameObject go in ElementsToShowWhenInactive)
            {
                go.SetActive(false);
            }
        }

        if (inputTimer >= 2)
        {
            foreach (GameObject go in ElementsToShowWhenInactive)
            {
                go.SetActive(true);
            }
        }
    }

    public void MonsterHasBeenKilled(GameObject monster)
    {
        GameObject room = Rooms[currentRoom];
        room.GetComponent<RoomScript>().MonsterHasBeenKilled(monster);
    }

    public void ObjectFinded(GameObject obj)
    {
        GameObject room = Rooms[currentRoom];
        room.GetComponent<RoomScript>().ObjectFinded(obj);
    }

    public void NextRoom()
    {
        currentRoom += 1;
    }

}

