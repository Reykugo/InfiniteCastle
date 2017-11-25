using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class follow : MonoBehaviour {

    [SerializeField]
    private Transform TargetTransform;



	// Use this for initialization
	void Start () {;
	}

    // Update is called once per frame
    void Update () {
		this.transform.localPosition = Vector3.Lerp(this.transform.localPosition, TargetTransform.localPosition, 0.1f);
	}

    
}
