using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HumanoidScript : MonoBehaviour {

    protected float Pv;

    public float PvMax;
    public int AttackDamage;

    public float AttackFrequency;

    public RectTransform healthBar;

    [SerializeField]
    private GameObject healthCanvas;

    protected virtual void Start()
    {
        Pv = PvMax;
    }

    public virtual void GetDamage(int damage){
		Pv -= damage;

        
        if (Pv <= 0)
        {
            Pv = 0;
            UpdateHealthBar();
            Destroy(healthCanvas,1);
        }
        else
        {
            UpdateHealthBar();
        }
        
    }

    protected void UpdateHealthBar()
    {
        float factor = Pv / PvMax;
        //healthBar.sizeDelta = new Vector2(Pv, healthBar.sizeDelta.y);
        healthBar.localScale = new Vector3(factor, 1, 1);
    }


    


}
