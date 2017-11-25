using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimCubeTransition : MonoBehaviour {

    [SerializeField]
    private float timer = 0;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;
        if (timer > 10)
        {
            timer = 0;
            GetComponent<Animator>().SetTrigger("trigger");
        }
        
	}
}
