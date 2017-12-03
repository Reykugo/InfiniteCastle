using UnityEngine;
using System.Collections;

public class BossScript : HumanoidScript
{
    [SerializeField]
    private GameObject PrefabAcidBall;

    [SerializeField]
    private Transform[] AcidBallStartPosition;

    [SerializeField]
    private int AcidBallSpeed = 1000;

    [SerializeField]
    private GameObject Fire;

    [SerializeField]
    private float FireDuration;

    public bool PlayerIsOnArea;


    private float timer;

    private bool isOnFire = false;

    private float fireTimer;


    private string[] attackpossibility = {"Acid", "Fire"};
    // Use this for initialization
    void Start()
    {
        Pv = PvMax;

    }

    public override void GetDamage(int damage)
    {
        base.GetDamage(damage);
        
        if(Pv <= 0)
        {
            GameObject.Find("GameManager").GetComponent<GameManagerScript>().PlayerWin();
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerIsOnArea)
        {
            timer += Time.deltaTime;
            if (timer >= AttackFrequency)
            {
                int r = Random.Range(0, attackpossibility.Length);
                string attack = attackpossibility[r];
                if (attack == "Acid")
                {
                    foreach(Transform startPos in AcidBallStartPosition)
                    {
                        AcidBall(startPos);
                    }
                    
                }
                else if (attack == "Fire" && !isOnFire)
                {
                    Fire.SetActive(true);
                    isOnFire = true;
                }
                timer = 0;
            }
            if (isOnFire)
            {
                fireTimer += Time.deltaTime;
                if (fireTimer >= FireDuration)
                {
                    Fire.SetActive(false);
                    isOnFire = false;
                    fireTimer = 0;
                }
            }
        }
        
    }

    void AcidBall(Transform startPos)
    {
        GameObject AcidBall = Instantiate<GameObject>(PrefabAcidBall);
        AcidBall.transform.position = startPos.position;
        AcidBall.GetComponent<Rigidbody>().AddForce(startPos.forward * AcidBallSpeed);
    }
}
