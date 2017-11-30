using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ChangeSceneScript : MonoBehaviour
{
    private float timer = 0;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        SceneManager.LoadScene("Dungeon");
    }
}
