using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TimerScript : MonoBehaviour
{

    [SerializeField]
    private float timer;

    private Text text; 

    // Use this for initialization
    void Start()
    {
        text = this.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        text.text = (timer + "");
    }

    public void Reset()
    {
        timer = 0;
        text.text = timer + "";
    }
}
