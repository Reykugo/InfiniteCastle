using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.PostProcessing;

public class PlayerScript : HumanoidScript
{

    [SerializeField]
    private GameObject GameOverText;


    [SerializeField]
    private Collider weaponsCollider;

    [SerializeField]
    private PostProcessingProfile DamageProfile;

    private Animator animator;

    private ShieldScript shield;

    private bool isDead = false;

    private Vector3 oldPosition;

    private bool canAttack = true;

    private PostProcessingBehaviour postProcessingBehaviour;

    private PostProcessingProfile postProfile;



    protected override void Start()
    {
        base.Start();
        animator = GetComponent<Animator>();
        postProcessingBehaviour = Camera.main.gameObject.GetComponent<PostProcessingBehaviour>();
        postProfile = postProcessingBehaviour.profile;
        shield = this.GetComponent<ShieldScript>();
    }

    public void GetDamage(int damage, bool cancelable=true)
    {
        if (!shield.IsActive || !cancelable) {
            base.GetDamage(damage);
            postProcessingBehaviour.profile = DamageProfile;
            Invoke("RestorePostProfile", 2);
        }
        else if(shield.IsActive && cancelable){
            int unblockedDamage = (int)shield.Pv - damage;
            shield.GetDamage(damage);
            if (unblockedDamage < 0)
            {
                base.GetDamage(-unblockedDamage);
                postProcessingBehaviour.profile = DamageProfile;
                Invoke("RestorePostProfile", 2);
            }
            
        }

        if (Pv <= 0)
        {
            GameOverText.SetActive(true);
            isDead = true;
            Destroy(transform.GetComponent<CharacterControls>());
        }

    }

    private void RestorePostProfile()
    {
        postProcessingBehaviour.profile = postProfile;
    }

    private void Update()
    {
        if (isDead) {
            if (Input.GetKeyDown(KeyCode.R)) {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }

        if (Input.GetMouseButton(1) && !weaponsCollider.enabled && shield.Pv >= 10) {
            shield.Shield.SetActive(true);
            shield.IsActive = true;
        }

        if (Input.GetMouseButtonUp(1))
        {
            shield.Shield.SetActive(false);
            shield.IsActive = false;
        }

        if (Input.GetMouseButtonDown(0)  && canAttack && !shield.IsActive)
        {
            weaponsCollider.enabled = true;
            animator.SetTrigger("canAttack");
            canAttack = false;
        }

        if (this.animator.GetCurrentAnimatorStateInfo(0).IsName("Footman_Attack")) {
            weaponsCollider.enabled = false;
            canAttack = true;
        }

        if(Pv < PvMax)
        {
            Pv += Time.deltaTime;
            UpdateHealthBar();

            if(Pv < PvMax / 4)
            {
                postProcessingBehaviour.profile = DamageProfile;
            }
            else
            {
                RestorePostProfile();
            }
        }


    }

}
