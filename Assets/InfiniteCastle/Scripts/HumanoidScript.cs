using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HumanoidScript : MonoBehaviour {

    protected int Pv;

    public int PvMax;
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
        float factor = ((float)Pv) / ((float)PvMax);
        //healthBar.sizeDelta = new Vector2(Pv, healthBar.sizeDelta.y);
        healthBar.localScale = new Vector3(factor, 1, 1);
        if (Pv <= 0)
        {
            Destroy(healthCanvas,2);
        }
	}

    


}
