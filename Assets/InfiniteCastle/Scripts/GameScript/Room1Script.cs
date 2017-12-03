using UnityEngine;
using System;

public class Room1Script : RoomScript
{
    public override void MonsterHasBeenKilled(GameObject monster)
    {
        base.MonsterHasBeenKilled(monster);
        if (Monsters.Count == 0)
        {
            Finish();            
        }
    }
}
