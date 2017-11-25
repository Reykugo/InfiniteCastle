using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeAttackScript : MonoBehaviour {

	private Animator animator;

	// Use this for initialization
	void Start () {
		animator = transform.parent.GetComponent<Animator> ();
	}

	void OnTriggerEnter(Collider c){
		if (c.tag == "Player") {
			animator.SetBool ("canAttack", true);
			int attackDamage = transform.parent.GetComponent<HumanoidScript> ().AttackDamage;
			transform.parent.GetComponent<HumanoidScript> ().GetDamage (attackDamage);
		}

	}

	void OnTriggerExit(){
		animator.SetBool ("canAttack", false);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
