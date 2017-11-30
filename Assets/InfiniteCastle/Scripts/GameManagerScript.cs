using UnityEngine;
using System.Collections;

public class GameManagerScript : MonoBehaviour
{

    private float inputTimer;

    [SerializeField]
    private GameObject[] ElementsToShowWhenInactive;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        showElementsWhenInactive();
    }


    void showElementsWhenInactive()
    {
        if (!Input.anyKey)
        {
            inputTimer += Time.deltaTime;
        }
        else
        {
            inputTimer = 0;
            foreach (GameObject go in ElementsToShowWhenInactive)
            {
                go.SetActive(false);
            }
        }

        if (inputTimer >= 2)
        {
            foreach (GameObject go in ElementsToShowWhenInactive)
            {
                go.SetActive(true);
            }
        }
    }

}
