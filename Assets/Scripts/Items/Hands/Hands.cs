using UnityEngine;
using System.Collections;

public class Hands : ItemScript
{

    public int damage;

    GameObject player;
    Transform imagePoint;
    Animator playerAnimator;
    BoxCollider2D hitbox;

    int attackHash;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        hitbox = gameObject.GetComponent<BoxCollider2D>();

        imagePoint = player.transform.FindChild("ImagePoints").FindChild("ImagePoint").transform;

        playerAnimator = player.GetComponent<Animator>();
        damage = 1;
        attackHash = Animator.StringToHash("Base Layer.Attack");


    }

    void Update ()
    {
        hitbox.transform.position = imagePoint.position;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        AnimatorStateInfo stateInfo = playerAnimator.GetCurrentAnimatorStateInfo(0);
        if(stateInfo.fullPathHash == attackHash)
        {
            print(name + " Collided");
        }

    }

    public override void Use()
    {
        playerAnimator.SetTrigger("isAttacking");
    }
}
