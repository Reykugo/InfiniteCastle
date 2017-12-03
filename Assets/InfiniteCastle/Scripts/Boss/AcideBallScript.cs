using UnityEngine;
using System.Collections;

public class AcideBallScript : MonoBehaviour
{

    [SerializeField]
    private int Dammage;

    [SerializeField]
    private int lifeDuration;

    [SerializeField]
    private GameObject PrefabPoison;

    [SerializeField]
    private int PoisonDuration;
    // Use this for initialization
    void Start()
    {
        Destroy(gameObject, lifeDuration);
    }

    // Update is called once per frame
    void Update()
    {
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<PlayerScript>())
        {
            PlayerScript script = collision.gameObject.GetComponent<PlayerScript>();
            script.GetDamage(Dammage);
        }
        GameObject Poison = Instantiate<GameObject>(PrefabPoison);
        Poison.transform.position = transform.position;
        Destroy(gameObject);
        Destroy(Poison, PoisonDuration);
    }
}
