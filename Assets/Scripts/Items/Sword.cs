using UnityEngine;
using System.Collections;

public class Sword : ItemScript {

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

        damage = 5;

    }

    void OnCollisionEnter2D(Collision2D other)
    {
        print("Sword Collision");
    }

    public override void Use()
    {
        print("Sword Used");
        playerAnimator.SetTrigger("isAttacking");
    }
}
