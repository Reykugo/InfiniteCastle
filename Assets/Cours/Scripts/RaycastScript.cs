using UnityEngine;
using System.Collections;

public class RaycastScript : MonoBehaviour
{

    [SerializeField]
    private GameObject particles;

    private LineRenderer line;
    // Use this for initialization
    void Start()
    {
        line = this.GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit))
        {
            line.enabled = true;
            Debug.Log(hit.collider.gameObject.name);

            /*Debug.DrawRay(transform.position, transform.forward.normalized * hit.distance, Color.red);*/

            line.SetPosition(0, transform.position + new Vector3(0, -5.1f, 0));
            line.SetPosition(1, hit.point);
            particles.SetActive(true);
            particles.transform.position = hit.point;
        }
        else
        {
            line.enabled = false;
            particles.SetActive(false);
        }
    }
}
