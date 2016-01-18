using UnityEngine;
using System.Collections;

public class Hands : ItemScript
{

    public int damage;

    Animator playerAnimator;
    BoxCollider2D hitbox;
    Transform imagePoint;

    void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");

        hitbox = gameObject.GetComponent<BoxCollider2D>();

        imagePoint = player.transform.FindChild("ImagePoints").FindChild("ImagePoint");

        playerAnimator = player.GetComponent<Animator>();

        damage = 1;

    }

    //void OnCollisionEnter2D(Collision2D other)
    //{
    //    //print("Hand Collision");
    //}

    public override void Use()
    {
        playerAnimator.SetTrigger("isAttacking");
    }
}
