using UnityEngine;
using System.Collections;

public class PlayerAnimationManager : MonoBehaviour {

    public Animator anim;

    public Rigidbody2D player;
    public bool isAttacking;

	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
	
	}
	
	// Update is called once per frame
	void Update () {

        if(player.velocity.magnitude == 0)
        {
            anim.SetBool("isMoving", false);
        }
        else
        {
            anim.SetBool("isMoving", true);
            anim.SetFloat("curX", player.velocity.x);
            anim.SetFloat("curY", player.velocity.y);
        }
        if (isAttacking)
        {
            anim.SetTrigger("isAttacking");
            isAttacking = false;
        }

    }
}
