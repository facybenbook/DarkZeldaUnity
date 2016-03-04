using UnityEngine;
using System.Collections;

public class PlayerAnimationManager : MonoBehaviour {

    public Animator anim;

    public Rigidbody2D player;
    public bool isAttacking;
    public GameObject imagePoint;
    public bool lockDirWhenAttacking;

    private Pause pauseScript;
    private float lockTimer;

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
        pauseScript = FindObjectOfType<Pause>();
        anim.SetFloat("lastY", -1f);
        anim.SetFloat("lastX", 0f);
    }
	
	// Update is called once per frame
	void Update () {
        if(pauseScript.paused)
        {
            anim.SetFloat("curX", 0f);
            anim.SetFloat("curY", 0f);
            anim.SetBool("isMoving", false);
            return;
        }

        if (player.velocity.magnitude == 0)
        {
            anim.SetBool("isMoving", false);
        }
        else
        {
            anim.SetBool("isMoving", true);
        }

        if(Input.GetButtonDown("Fire1")  || Input.GetButtonDown("Fire2"))
        {
            lockTimer = 0.15f;
        }

        if(lockTimer <= 0)
        {
            if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
            {
                if (Mathf.Abs(Input.GetAxis("Horizontal")) > Mathf.Abs(Input.GetAxis("Vertical")))
                {
                    anim.SetFloat("lastX", FloorOrCeil(Input.GetAxis("Horizontal")));
                    anim.SetFloat("lastY", 0f);
                }
                else
                {
                    anim.SetFloat("lastX", 0f);
                    anim.SetFloat("lastY", FloorOrCeil(Input.GetAxis("Vertical")));
                }
            }
            if (Input.GetAxis("LookX") != 0 || Input.GetAxis("LookY") != 0)
            {

                if (Mathf.Abs(Input.GetAxis("LookX")) > Mathf.Abs(Input.GetAxis("LookY")))
                {
                    anim.SetFloat("lastX", FloorOrCeil(Input.GetAxis("LookX")));
                    anim.SetFloat("lastY", 0f);
                }
                else
                {
                    anim.SetFloat("lastX", 0f);
                    anim.SetFloat("lastY", FloorOrCeil(Input.GetAxis("LookY")));
                }
            }
        }
        else
        {
            lockTimer -= Time.deltaTime;
        }


        //anim.SetFloat("curX", Input.GetAxis("Horizontal"));
        //anim.SetFloat("curY", Input.GetAxis("Vertical"));

        imagePoint.transform.position = player.transform.position + new Vector3(anim.GetFloat("lastX"), anim.GetFloat("lastY")).normalized/2;
    }
}
