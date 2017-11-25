using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotationScript : MonoBehaviour {

	[SerializeField]
	private Transform CamTransform;

	[SerializeField]
	private float SpeedRotation;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		float y = Input.GetAxis("Mouse X");
		float x = Input.GetAxis("Mouse Y");

		//Clamp lock between two values
		float xClamp = Mathf.Clamp (CamTransform.eulerAngles.x + (x * SpeedRotation), -60 , 60);

		this.transform.eulerAngles += new Vector3 (0, y, 0) * SpeedRotation;
		CamTransform.eulerAngles += new Vector3 (-x, 0, 0) * SpeedRotation;
	}
}
