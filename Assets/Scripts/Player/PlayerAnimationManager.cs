using UnityEngine;
using System.Collections;

public class PlayerAnimationManager : MonoBehaviour {

    public Animator anim;

    public Rigidbody2D player;
    public bool isAttacking;
    public GameObject imagePoint;

    float FloorOrCeil (float val)
    {
        if(val > 0)
        {
            return Mathf.Ceil(val);
        }
        else
        {
            return Mathf.Floor(val);
        }
    }

	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {

        anim.SetFloat("curX", Input.GetAxis("Horizontal"));
        anim.SetFloat("curY", Input.GetAxis("Vertical"));

        if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
        {
            anim.SetFloat("lastX", FloorOrCeil(Input.GetAxis("Horizontal")));
            anim.SetFloat("lastY", FloorOrCeil(Input.GetAxis("Vertical")));
        }

        if (player.velocity.magnitude == 0)
        {
            anim.SetBool("isMoving", false);
        }
        else
        {
            anim.SetBool("isMoving", true);
        }

        if (isAttacking)
        {
            anim.SetTrigger("isAttacking");
            isAttacking = false;
        }

        imagePoint.transform.position = player.transform.position + new Vector3(anim.GetFloat("lastX"), anim.GetFloat("lastY")).normalized/2;
    }
}
