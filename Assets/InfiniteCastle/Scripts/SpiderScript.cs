using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderScript : MonsterScript{

	protected override void OnTriggerEnter (Collider c)
	{
		base.OnTriggerEnter (c);
		animator.SetBool ("canMove", true);
	}

	protected override void OnTriggerExit (Collider c)
	{
		base.OnTriggerExit (c);
		animator.SetBool ("canMove", false);
	}

	void OnTriggerStay(Collider c){
		if(this.transform.position == c.transform.position){
			animator.SetBool ("canAttack", true);
		}
	}
}
