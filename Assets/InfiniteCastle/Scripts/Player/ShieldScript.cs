using UnityEngine;
using System.Collections;

public class ShieldScript : MonoBehaviour
{

    public GameObject Shield;

    [SerializeField]
    private float PvMax;

    [SerializeField]
    private GameObject ShieldCanvas;

    [SerializeField]
    private RectTransform ShieldBar;

    public bool IsActive;

    private float lifeTimer = 0;
    public float Pv;

    // Use this for initialization
    void Start()
    {
        Pv = PvMax;
    }

    // Update is called once per frame
    void Update()
    {
        if(Pv < PvMax && !IsActive)
        {
            Pv += Time.deltaTime *5;
            if(Pv > PvMax)
            {
                Pv = PvMax;
            }
            float factor = Pv / PvMax;
            ShieldBar.localScale = new Vector3(factor, 1, 1);
        }
    }

    public void GetDamage(int damage)
    {
        Pv -= damage;
        if (Pv <= 0)
        {
            Pv = 0;
            IsActive = false;
            Shield.SetActive(false);
        }

        float factor = Pv / PvMax;
        ShieldBar.localScale = new Vector3(factor, 1, 1);
    }
}
