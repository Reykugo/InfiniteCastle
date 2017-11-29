using UnityEngine;
using System.Collections;

public class WeaponsScript : MonoBehaviour
{

    [SerializeField]
    private int Dammage;

    private Collider collider;

    // Use this for initialization
    void Start()
    {
        collider = this.GetComponent<Collider>();
    }

    // Update is called once per frame
    void Update()
    {

    }


    void OnTriggerEnter(Collider c)
    {
        Debug.Log(c.name);
        if (c.tag == "monster") {
            HumanoidScript script = c.GetComponent<HumanoidScript>();
            if (script)
            {
                script.GetDamage(Dammage);
                /*collider.enabled = false;*/
            }
        }
        

        //Destroy(gameObject);
    }
}
