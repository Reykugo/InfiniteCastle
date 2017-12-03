using UnityEngine;
using System.Collections;

public class BossMoveScript : MonoBehaviour
{

    [SerializeField]
    private Transform[] Destination;

    [SerializeField]
    private float moveFrequency;

    [SerializeField]
    private Transform PlayerPos;

    private float timer;

    private BossScript bossScript;

    // Use this for initialization
    void Start()
    {
        bossScript = this.GetComponent<BossScript>();
    }

    // Update is called once per frame
    void Update()
    {

        if (bossScript.PlayerIsOnArea)
        {
            timer += Time.deltaTime;
            if (timer >= moveFrequency)
            {
                int r = UnityEngine.Random.Range(0, Destination.Length);
                transform.position = Destination[r].position;
                timer = 0;
            }

            Vector3 lookAt = new Vector3(PlayerPos.position.x, transform.position.y, PlayerPos.position.z);
            transform.LookAt(lookAt);
        }

    }
}
