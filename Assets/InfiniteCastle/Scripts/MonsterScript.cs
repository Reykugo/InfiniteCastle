using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MonsterScript : HumanoidScript {

	[SerializeField]
	private Transform[] Destination;

	private  Animator animator;

	private NavMeshAgent agent;

	private bool moveOnPLayer = false;
	private Transform player;

    private MakeAttackScript[] attackScripts;

	void OnTriggerEnter(Collider c){
		if (c.tag == "Player") {
            moveOnPLayer = true;
			player = c.transform;
		}
	}

	void OnTriggerExit(Collider c){
		if (c.tag == "Player") {
			moveOnPLayer = false;
			player = null;
		}
	}


	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator> ();
		agent = GetComponent<NavMeshAgent> ();
		int r = Random.Range (0, Destination.Length);
		agent.destination = Destination[r].position;
        attackScripts = this.GetComponentsInChildren<MakeAttackScript>();
        animator.SetBool("canMove", true); 
    }


	public override void GetDamage(int damage){
		base.GetDamage (damage);
		//GetComponent<Animator> ().SetInteger("Pv", Pv);
		if (Pv <= 0) {
            animator.SetBool("isDie", true);
			GetComponent<BoxCollider> ().enabled = false;
			agent.enabled = false;
			Destroy (this);
            foreach( MakeAttackScript script in attackScripts)
            {
                Destroy(script);
            }
            
		}

	}



	// Update is called once per frame
	void Update () {
		if (agent.remainingDistance <= 5 && moveOnPLayer == false) {
			int r = Random.Range (0, Destination.Length);
			agent.destination = Destination[r].position;
		} 
		else if (moveOnPLayer == true) {
			agent.destination = player.position;
		}
	}

}
