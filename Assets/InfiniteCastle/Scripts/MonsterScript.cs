using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MonsterScript : HumanoidScript {

	[SerializeField]
	private Transform[] Destination;

    [SerializeField]
    private string MoveMode;

    private Transform currentDestination;
    
    public string AttackAnimationName;

    public Transform Player;

    private  Animator animator;

	private NavMeshAgent agent;

	public bool MoveOnPlayer = false;
	

    private MakeAttackScript[] attackScripts;

    private float baseSpeed;

    private GameObject gameManager;

	// Use this for initialization
	protected override void Start () {
        base.Start();

		animator = GetComponent<Animator> ();
		agent = GetComponent<NavMeshAgent> ();
        SelectMoveByMode(MoveMode);
        attackScripts = this.GetComponentsInChildren<MakeAttackScript>();
        animator.SetBool("canMove", true);
        baseSpeed = agent.speed;
        gameManager = GameObject.Find("GameManager");
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
            gameManager.GetComponent<GameManagerScript>().MonsterHasBeenKilled(this.gameObject);
            
		}
	}

    private void SelectMoveByMode(string mode)
    {
        int r = 0;
        if (mode == "random")
        {
            r = UnityEngine.Random.Range(0, Destination.Length);
        }
        else if(mode == "next")
        {
            int currentIndex = Array.IndexOf(Destination, currentDestination);
            
            if(currentIndex < Destination.Length)
            {
               r = currentIndex + 1;
            }
            else
            {
                r = 0;
            }
        }
        currentDestination = Destination[r];
        agent.destination = Destination[r].position;
    }

	// Update is called once per frame
	void Update () {
		if (agent.remainingDistance <= 5 && !MoveOnPlayer) {
            SelectMoveByMode(MoveMode);
		} 
		else if (MoveOnPlayer) {
            agent.destination = Player.position;
            /*if (agent.remainingDistance <= 7)
            {
                agent.speed = baseSpeed/2;
                //animator.SetBool("canMove", false);
            }
            else
            {
                agent.speed = baseSpeed;
                //animator.SetBool("canMove", true);
            }*/
		}

        else if(!MoveOnPlayer && Pv < PvMax)
        {
            Pv += Time.deltaTime * 5;
            UpdateHealthBar();
        }

	}

}
