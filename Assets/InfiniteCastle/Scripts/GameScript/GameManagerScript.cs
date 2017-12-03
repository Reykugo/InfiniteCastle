using UnityEngine;
using System;

public class GameManagerScript : MonoBehaviour
{

    private float inputTimer;

    [SerializeField]
    private GameObject[] ElementsToShowWhenInactive;

    [SerializeField]
    private GameObject[] Rooms;

    [SerializeField]
    private GameObject InGamePanel;

    [SerializeField]
    private GameObject DiedPanel;

    [SerializeField]
    private GameObject VictoryPanel;

    [SerializeField]
    private GameObject Player;

    [SerializeField]
    private GameObject Boss;

    public int currentRoom = 0;

    private PlayerScript playerScript;
    private BossScript bossScript;

    // Use this for initialization
    void Start()
    {
        playerScript = Player.GetComponent<PlayerScript>();
        bossScript = Boss.GetComponent<BossScript>();
    }

    // Update is called once per frame
    void Update()
    {
        ShowElementsWhenInactive();
    }

    public void PlayerWin()
    {
        InGamePanel.SetActive(false);
        VictoryPanel.SetActive(true);
    }

    public void PlayerDied()
    {
        InGamePanel.SetActive(false);
        DiedPanel.SetActive(true);
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

