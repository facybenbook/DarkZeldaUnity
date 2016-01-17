using UnityEngine;
using System.Collections;

public class Sword : Item {

    Animator playerAnimator;
    BoxCollider2D hitbox;

    public int damage;

    void OnEnable()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");

        GameObject go = Instantiate(Resources.Load("SwordHitBox") as GameObject);
        go.transform.SetParent(player.transform.FindChild("ImagePoints").FindChild("ImagePoint"), false);

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
