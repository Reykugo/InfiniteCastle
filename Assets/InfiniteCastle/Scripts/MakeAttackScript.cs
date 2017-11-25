using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeAttackScript : MonoBehaviour {

	private Animator animator;

    private float  attackTimer = 0;

    private float attackFrequency;

	// Use this for initialization
	void Start () {
		animator = transform.parent.GetComponent<Animator> ();
        attackFrequency = transform.parent.GetComponent<HumanoidScript>().AttackFrequency;
        attackTimer = attackFrequency;
	}

	void OnTriggerEnter(Collider c){
		if (c.tag == "Player") {
			Attack(c);
		}
	}

    private void OnTriggerStay(Collider c)
    {
        if (c.tag == "Player")
        {
            attackTimer += Time.deltaTime;
            if (attackTimer >= attackFrequency)
            {
                Attack(c);
                attackTimer = 0;
            }
            else if (animator.GetBool("canAttack")) {
                animator.SetBool("canAttack", false);
            }

        }
    }

    private void OnTriggerExit(Collider c)
    {
        attackTimer = 0;
        animator.SetBool("canAttack", false);
    }

	
	// Update is called once per frame
	void Update () {
		
	}

    private void Attack(Collider c) {
        animator.SetBool("canAttack", true);
        int attackDamage = transform.parent.GetComponent<HumanoidScript>().AttackDamage;
        c.GetComponent<HumanoidScript>().GetDamage(attackDamage);
    }

}
