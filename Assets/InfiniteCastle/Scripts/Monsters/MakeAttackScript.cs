using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeAttackScript : MonoBehaviour {

	private Animator animator;

    private float  attackTimer = 0;

    

    private Collider collider;

    private bool canAttack = false;

    private MonsterScript monsterScript;

	// Use this for initialization
	void Start () {
		animator = transform.parent.GetComponent<Animator> ();
        monsterScript = transform.parent.GetComponent<MonsterScript>();
        attackTimer = monsterScript.AttackFrequency;
        collider = this.GetComponent<Collider>();
        //animator.GetBehaviour<AttackBehaviourScript>().attackScript = this;

	}

	void OnTriggerEnter(Collider c){
		if (c.tag == "Player") {
            //Attack(c);
            //canAttack = true;
            if (attackTimer >= monsterScript.AttackFrequency)
            {
                animator.SetTrigger("canAttack");
                attackTimer = 0;
                collider.enabled = false;
                canAttack = true;
            }
        }
	}

    /*private void OnTriggerStay(Collider c)
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
    }*/

    private void OnTriggerExit(Collider c)
    {
        attackTimer = 0;
    }

	
	// Update is called once per frame
	void Update () {
        attackTimer += Time.deltaTime;
        if (attackTimer >= monsterScript.AttackFrequency)
        {
            collider.enabled = true;
        }

        if (animator.GetCurrentAnimatorStateInfo(0).IsName(monsterScript.AttackAnimationName) && canAttack)
        {
            Attack();
            canAttack = false;
        }

    }

    public void Attack() {
        animator.SetBool("canWalk", false);
        int attackDamage = transform.parent.GetComponent<HumanoidScript>().AttackDamage;
        monsterScript.Player.GetComponent<PlayerScript>().GetDamage(attackDamage);
    }

}
