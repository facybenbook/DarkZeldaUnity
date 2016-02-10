using UnityEngine;
using System.Collections;

public class Hands : ItemScript
{

    public int damage;
    public float knockback;
    public float stun;
    public float attackDelay;

    GameObject player;
    Transform imagePoint;
    Animator playerAnimator;
    BoxCollider2D hitbox;
    PlayerAttacking playerAtkScript;
    float timer;
    CameraShake cam;

    int attackHash;

    void Start()
    {
        cam = FindObjectOfType<CameraShake>();

        player = GameObject.FindGameObjectWithTag("Player");

        hitbox = gameObject.GetComponent<BoxCollider2D>();

        imagePoint = player.transform.FindChild("ImagePoints").FindChild("ImagePoint").transform;

        playerAnimator = player.GetComponent<Animator>();

        playerAtkScript = player.GetComponent<PlayerAttacking>();

        damage = -1;
        knockback = 8f;
        stun = 0.5f;
        attackDelay = 0.25f;
        attackHash = Animator.StringToHash("Base Layer.Attack");


    }

    void Update ()
    {
        hitbox.transform.position = imagePoint.position;

        if( timer <= 0 && hitbox.enabled)
        {
            hitbox.enabled = false;
        }
        else if(timer > 0)
        {
            timer -= Time.deltaTime;
            hitbox.enabled = true;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        //the Enemys Rigidbodys sleeping mode must be set to never sleep for collisions to take place when the object is stoped...

        //theres got be be a better way to do this...
        if (other.tag == "Player" || other.name.Contains("CameraZone") == true || other.tag == "Npc") {
            return;
        }
        cam.Shake(0.1f, 0.2f);
        HealthController hpController = other.GetComponent<HealthController>();
        AnimatorStateInfo stateInfo = playerAnimator.GetCurrentAnimatorStateInfo(0);
        Rigidbody2D rb = other.GetComponent<Rigidbody2D>();
        EnemyMovementManager emm = other.GetComponent<EnemyMovementManager>();
 
        if(stateInfo.fullPathHash == attackHash)
        {
            print(name + " hit " +other.name);

            if (hpController != null && hpController.timer <= 0)
            {
                hpController.ChangeHealth(damage);
                cam.Shake(0.1f, 0.2f);

                if (rb != null)
                {
                    rb.velocity = (rb.transform.position - player.transform.position) * knockback;
                }
                if (emm != null)
                {
                    emm.stunTimer = stun;
                }
            }
           
        }
    }

    public override void Use()
    {
        playerAnimator.SetTrigger("isAttacking");
        timer = 0.2f;
        playerAtkScript.attackDelay = attackDelay;
    }
}
