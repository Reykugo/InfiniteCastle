using UnityEngine;
using System.Collections;

public class DoorsScript : MonoBehaviour
{


    private Animator animator;
    // Use this for initialization
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            animator.SetTrigger("openDoor");
            //Destroy(this);
        }
    }
}
