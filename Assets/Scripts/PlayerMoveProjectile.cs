using UnityEngine;
using System.Collections;

public class PlayerMoveProjectile : MonoBehaviour {

    public float moveSpd;
    private Vector3 target;
    private Rigidbody2D rb;
    private Animator playerAnim;
    private Animator anim;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
        playerAnim = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();
        anim = GetComponent<Animator>();

        target = new Vector3(playerAnim.GetFloat("lastX"), playerAnim.GetFloat("lastY"), 0f);

        rb.velocity = target.normalized * moveSpd;

        Debug.Log(target);

    }
	
	// Update is called once per frame
	void Update () {

        anim.SetFloat("x", rb.velocity.x);
        anim.SetFloat("y", rb.velocity.y);

    }
}
