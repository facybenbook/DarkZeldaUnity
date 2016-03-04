using UnityEngine;
using System.Collections;

public class Bow : ItemScript
{

    public int damage;
    public float knockback;
    public float stun;
    public float attackDelay;
    public GameObject projectile;

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
        player = GameObject.FindGameObjectWithTag("Player");

        imagePoint = player.transform.FindChild("ImagePoints").FindChild("ImagePoint").transform;

        playerAnimator = player.GetComponent<Animator>();

        playerAtkScript = player.GetComponent<PlayerAttacking>();
        attackDelay = 0.25f;
        attackHash = Animator.StringToHash("Base Layer.BowAttack");


    }

    public override void Use()
    {
        playerAnimator.SetTrigger("Bow");
        playerAtkScript.attackDelay = attackDelay;

        Vector3 spawn = new Vector3(playerAnimator.GetFloat("lastX")/2, playerAnimator.GetFloat("lastY")/2,0f);

        GameObject projectileInstance = Instantiate(projectile,transform.position+spawn,transform.rotation) as GameObject;
        Rigidbody2D projectileRB = projectileInstance.GetComponent<Rigidbody2D>();

    }
}
