using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HumanoidScript : MonoBehaviour {

    public int Pv;

    public int AttackDamage;

    public float AttackFrequency;

    public RectTransform healthBar;

	void Start(){

	}
	public virtual void GetDamage(int damage){
		Pv -= damage;
        healthBar.sizeDelta = new Vector2(Pv, healthBar.sizeDelta.y);
	}



}
