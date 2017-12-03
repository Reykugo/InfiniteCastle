using UnityEngine;
using System.Collections;

public class Room2Script : RoomScript
{
    public override void ObjectFinded(GameObject obj)
    {
        base.ObjectFinded(obj);
        if(ObjectsToFind.Count == 0)
        {
            Finish();
        }
    }
}
