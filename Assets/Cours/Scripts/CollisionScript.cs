using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionScript : MonoBehaviour {

    void OnCollisionEnter(Collision c)
    {
        Debug.Log(c.gameObject.tag = "GrowingSphere");
        //c.gameObject.transform.localScale = new Vector3(1, 1, 1);
    }
}
