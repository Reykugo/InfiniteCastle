using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{

    private bool isOpen = false;
    private float timer;

    [SerializeField]
    private float Speed;

    [SerializeField]
    private Vector3 StartPosition;


    [SerializeField]
    private Vector3 EndPosition;

    public Color StColor, EndColor, CurrentColor;


    void OnTriggerEnter(Collider c)
    {
        Debug.Log(c.tag);
        if(c.tag == "Player")
        {
            isOpen = true;
            timer = 0;
        }
    }

    private void OnTriggerExit(Collider c)
    {
        if(c.tag == "Player")
        {
            isOpen = false;
            timer = 1;
        }
    }

    void Update()
    {
        if (isOpen)
        {
            timer += Time.deltaTime;
        }
        else
        {
            timer -= Time.deltaTime;
        }
        transform.localPosition = Vector3.Lerp(StartPosition, EndPosition, timer);

		//Lerp get value betwen start and end by facto example: 0,10 ,0.5 return 5
		/*transform.localPosition = Vector3.Lerp(StartPosition, EndPosition, (Mathf.Sin(Time.time) +1)/2);
        CurrentColor = Color.Lerp(StColor, EndColor, timer);*/
    }

}
