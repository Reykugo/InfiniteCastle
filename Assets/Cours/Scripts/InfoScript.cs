using UnityEngine;
using System.Collections;

public class InfoScript : MonoBehaviour
{

    public string Difficulty;
    public int CurrentLife;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        PlayerPrefs.SetInt("Life", CurrentLife);
        PlayerPrefs.SetString("Difficulty", Difficulty);

        int i = PlayerPrefs.GetInt("Life");
        Debug.Log(i);
    }

}
