using UnityEngine;
using System.Collections;

public class PlayerRaycastScript : MonoBehaviour
{

    [SerializeField]
    private float RayCastLength;

    private GameObject raycastedObject;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.A))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, RayCastLength))
            {
                Debug.Log(hit.collider.tag);
                if (hit.collider.tag =="Object")
                {
                    PlayerInventoryScript inventoryScript = this.GetComponent<PlayerInventoryScript>();
                    if (inventoryScript)
                    {
                        inventoryScript.AddItem(hit.collider.gameObject);
                        hit.collider.gameObject.SetActive(false);
                    }
                }   

            }
         
        }
        
    }
}
