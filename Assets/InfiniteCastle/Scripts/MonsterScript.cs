using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MonsterScript : HumanoidScript {

	[SerializeField]
	protected Transform[] Destination;

	protected Animator animator;

	private NavMeshAgent agent;

	private bool moveOnPLayer = false;
	private Transform player;

	[SerializeField]
	protected int AttackDamage;

	protected virtual void OnTriggerEnter(Collider c){
		if (c.tag == "Player") {
			player = c.transform;
			agent.enabled = true;
		}
	}

	protected virtual void OnTriggerExit(Collider c){
		if (c.tag == "Player") {
			moveOnPLayer = false;
			player = null;
			agent.enabled = false;
		}
	}


	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator> ();
		agent = GetComponent<NavMeshAgent> ();
		int r = Random.Range (0, Destination.Length);
		agent.destination = Destination[r].position;
	}


	public override void GetDamage(int damage){
		base.GetDamage (damage);
		animator.SetInteger ("pv", Pv);
		//GetComponent<Animator> ().SetInteger("Pv", Pv);
		if (Pv <= 0) {
			GetComponent<BoxCollider> ().enabled = false;
			agent.enabled = false;
			Destroy (this);
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

	//tster les differents positions
}
