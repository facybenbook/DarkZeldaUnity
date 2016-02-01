using UnityEngine;
using System.Collections;

public class Hands : ItemScript
{

    public int damage;
    public float knockback;
    public float stun;

    GameObject player;
    Transform imagePoint;
    Animator playerAnimator;
    BoxCollider2D hitbox;
    float timer;

    int attackHash;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        hitbox = gameObject.GetComponent<BoxCollider2D>();

        imagePoint = player.transform.FindChild("ImagePoints").FindChild("ImagePoint").transform;

        playerAnimator = player.GetComponent<Animator>();

        damage = -1;
        knockback = 8f;
        stun = 0.5f;
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

        HealthController hpController = other.GetComponent<HealthController>();
        AnimatorStateInfo stateInfo = playerAnimator.GetCurrentAnimatorStateInfo(0);
        Rigidbody2D rb = other.GetComponent<Rigidbody2D>();
        EnemyMovementManager emm = other.GetComponent<EnemyMovementManager>();
 
        if(stateInfo.fullPathHash == attackHash)
        {
            print(name + " hit " +other.name);

            if (hpController != null)
            {
                hpController.ChangeHealth(damage);
            }
            if(rb != null)
            {
                rb.velocity = (rb.transform.position-player.transform.position) * knockback;
            }
            if(emm != null)
            {
                emm.stunTimer = stun;
            }
        }
    }

    public override void Use()
    {
        playerAnimator.SetTrigger("isAttacking");
        timer = 0.2f;
    }
}
