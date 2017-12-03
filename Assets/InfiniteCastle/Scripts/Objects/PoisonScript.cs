using UnityEngine;
using System.Collections;

public class PoisonScript : MonoBehaviour
{

    [SerializeField]
    private int Damage;

    [SerializeField]
    private int IntervalDamage;

    private float timer = 0;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerStay(Collider other)
    {
        timer += Time.deltaTime;
        if(timer >= IntervalDamage && other.tag == "Player")
        {
            other.GetComponent<PlayerScript>().GetDamage(Damage, false);
            timer = 0;
        }
    }
}
