using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour {

	[SerializeField]
	private int Dammage;

	// Use this for initialization
	void Start () {
		Destroy (gameObject, 4);
	}
	
	// Update is called once per frame
	void Update () {
	}

	void OnCollisionEnter(Collision collision){
		if (collision.gameObject.GetComponent<HumanoidScript>()) {
			HumanoidScript script = collision.gameObject.GetComponent<HumanoidScript> ();
			script.GetDamage (Dammage);
		}

		Destroy (gameObject);
	}
}
