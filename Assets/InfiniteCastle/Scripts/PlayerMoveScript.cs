using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveScript : MonoBehaviour {


	[SerializeField]
	private int Speed;

	[SerializeField]
	private int RunningSpeed;

	[SerializeField]
	private int JumpPower;

	private int speed;

	private bool CanJump;


	// Use this for initialization
	void Start () {
		speed = Speed;
	}
	
	//est apellé 60 fois par seconde automatiquement
	void FixedUpdate () {

		if (GetComponent<Rigidbody> ().velocity.magnitude < RunningSpeed)
		{
			if (Input.GetKey (KeyCode.LeftShift)) {
				Speed = RunningSpeed;
			} 
			else 
			{
				Speed = speed;
			}
			if (Input.GetKey (KeyCode.Z)) 
			{
				GetComponent<Rigidbody> ().AddForce (transform.forward * Speed);
			} 
			if (Input.GetKey (KeyCode.Q))
			{
				GetComponent<Rigidbody> ().AddForce (-transform.right * Speed);
			} 
			if (Input.GetKey (KeyCode.S)) 
			{
				GetComponent<Rigidbody> ().AddForce (-transform.forward * Speed);
			}
			if (Input.GetKey (KeyCode.D)) 
			{
				GetComponent<Rigidbody> ().AddForce(transform.right * Speed);
			} 
			if (Input.GetKeyDown (KeyCode.Space) && CanJump) 
			{
				GetComponent<Rigidbody> ().AddForce (new Vector3 (0, JumpPower, 0));
			}
		}

		CanJump = false;
			
	}

	private void OnTriggerStay(Collider c)
	{
		CanJump = true;		
	}
		
}
