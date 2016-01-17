using UnityEngine;
using System.Collections;

public class Sword : Item {

    Animator playerAnimator;
    public int damage;

    void OnEnable()
    {
        name = "Sword";
        damage = 5;
        this.playerAnimator = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();
    }

    public override void Use()
    {
        //base.Use();
        Debug.Log(name + " Used.");
        playerAnimator.SetTrigger("isAttacking");
    }
}
