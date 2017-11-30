using UnityEngine;
using System.Collections;
using UnityEngine.AI;

public class RayCastDestination : MonoBehaviour
{

    public float Distance;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void GetRandomPosition()
    {
        Vector3 randomDirection = Random.insideUnitSphere * Distance;
        randomDirection += transform.position;
        NavMeshHit hit;
        NavMesh.SamplePosition(randomDirection, out hit, Distance, 1);
        Vector3 finalPosition = hit.position;
        GetComponent<NavMeshAgent>().destination = finalPosition;
    }
}
