using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerScript : HumanoidScript
{

    [SerializeField]
    private GameObject GameOverText;

    [SerializeField]
    private GameObject Shield;

    [SerializeField]
    private Collider weaponsCollider;

    private Animator animator;

    private bool shield;

    private bool isDead = false;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    public override void GetDamage(int damage)
    {
        if (shield == false) {
            base.GetDamage(damage);
            if (Pv <= 0)
            {
                GameOverText.SetActive(true);
                isDead = true;
                Destroy(transform.GetComponent<CharacterControls>());
            }
        }
        
    }

    private void Update()
    {
        if (isDead) {
            if (Input.GetKeyDown(KeyCode.R)) {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }

        if (Input.GetMouseButton(1)) {
            Shield.SetActive(true);
            shield = true;
        }

        if (Input.GetMouseButtonUp(1))
        {
            Shield.SetActive(false);
            shield = false;
        }

        if (Input.GetMouseButtonDown(0))
        {
            weaponsCollider.enabled = true;
            animator.SetTrigger("canAttack");
        }

        if (this.animator.GetCurrentAnimatorStateInfo(0).IsName("Footman_Attack_Return")) {
            weaponsCollider.enabled = false;
        }


    }

}
