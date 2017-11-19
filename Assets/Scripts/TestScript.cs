using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScript : MonoBehaviour {

    [SerializeField]
    private float Speed;

	// Use this for initialization
	void Start () {
        //this.transform.localScale = new Vector3(10, 10, 10);
        this.transform.GetComponent<SphereCollider>().radius = 0.5f;
		
	}
	
	// Update is called once per frame
	void Update () {
        float factor = Time.deltaTime * Speed;
        this.transform.localScale += new Vector3(factor, factor, factor);
    }
}
