using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour {

	[SerializeField]
	private int speed;

	// Use this for initialization
	void Start () {
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown ("z")) {
			this.transform.position = new Vector3 (this.transform.position.x, this.transform.position.y + speed, this.transform.position.z);
		} else if (Input.GetKeyDown ("s")) {
			this.transform.position = new Vector3 (this.transform.position.x, this.transform.position.y - speed, this.transform.position.z);
		} else if (Input.GetKeyDown ("d")) {
			this.transform.position = new Vector3 (this.transform.position.x + speed, this.transform.position.y, this.transform.position.z);
		} else if (Input.GetKeyDown ("q")) {
			this.transform.position = new Vector3 (this.transform.position.x - speed, this.transform.position.y, this.transform.position.z);
		}			
		
	}
}
