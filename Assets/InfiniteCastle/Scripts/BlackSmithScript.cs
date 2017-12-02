using UnityEngine;
using System.Collections;

public class BlackSmithScript : MonoBehaviour
{

    [SerializeField]
    private GameObject key;

    [SerializeField]
    private string hammer;

    [SerializeField]
    private string ironBar;

    private bool playerHaveIronBar;

    private bool playerHaveHammer;

    GameObject gameManager;

    private void Start()
    {
        gameManager = GameObject.Find("GameManager");
    }


    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "Player")
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                Debug.Log("OK");
                PlayerInventoryScript inventoryScript = other.GetComponent<PlayerInventoryScript>();
                if (inventoryScript)
                {
                    foreach ( GameObject item in inventoryScript.Items)
                    {
                        if(item.GetComponent<ObjectScript>().Name == hammer)
                        {
                            playerHaveHammer = true;
                        }

                        if (item.GetComponent<ObjectScript>().Name == ironBar)
                        {
                            playerHaveIronBar = true;
                        }
                    }
                    if(playerHaveHammer && playerHaveIronBar)
                    {
                        inventoryScript.RemoveItem(hammer);
                        inventoryScript.RemoveItem(ironBar);
                        key.SetActive(true);
                        gameManager.GetComponent<GameManagerScript>().ObjectFinded(key);

                    }
                }
            }
        }
    }
}
