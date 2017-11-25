using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanoidScript : MonoBehaviour {

	private int pv;


	public int Pv{get{return pv;}}

	private int attackDamage;

	public int AttackDamage{get{return attackDamage;}}

	void Start(){
		attackDamage = AttackDamage;
		pv = Pv; 
	}
	public virtual void GetDamage(int damage){
		pv -= damage;
	}



}
