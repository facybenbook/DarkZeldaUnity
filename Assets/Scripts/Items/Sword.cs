using UnityEngine;
using System.Collections;

public class Sword : Item {

    Animator playerAnimator;
    public int damage;
    BoxCollider2D hitbox;

    void OnEnable()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");

        GameObject go = Instantiate(Resources.Load("SwordHitBox") as GameObject);
        go.transform.parent = player.transform;
        hitbox = go.GetComponent<BoxCollider2D>();

        playerAnimator = player.GetComponent<Animator>();

        name = "Sword";
        damage = 5;
    }

    public override void Use()
    {
        playerAnimator.SetTrigger("isAttacking");
    }
}
