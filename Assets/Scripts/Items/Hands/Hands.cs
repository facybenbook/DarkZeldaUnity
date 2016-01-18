using UnityEngine;
using System.Collections;

public class Hands : ItemScript
{

    public int damage;

    GameObject player;
    Transform imagePoint;
    Animator playerAnimator;
    BoxCollider2D hitbox;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        hitbox = gameObject.GetComponent<BoxCollider2D>();

        imagePoint = player.transform.FindChild("ImagePoints").FindChild("ImagePoint").transform;

        playerAnimator = player.GetComponent<Animator>();
        damage = 1;

    }

    void Update ()
    {
        hitbox.transform.position = imagePoint.position;
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
