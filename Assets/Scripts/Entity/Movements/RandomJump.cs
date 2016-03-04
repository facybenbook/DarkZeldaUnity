using UnityEngine;
using System.Collections;

public class RandomJump : MonoBehaviour {
    public float moveSpd;
    public float spdRandomness;
    public float jumpLength;
    public float jumpRandomness;
    public float timeBetweenMovement;
    public float timerRandomness;
    private float waitTimer;
    private float jumpTimer;
    private bool isJumping;
    private Rigidbody2D rb;
    private EnemyMovementManager EMM;
    private Animator anim;

    // Use this for initialization
    void Start()
    {
        waitTimer = timeBetweenMovement + Random.Range(-timerRandomness, timerRandomness);
        rb = GetComponent<Rigidbody2D>();
        EMM = GetComponent<EnemyMovementManager>();
        anim = GetComponent<Animator>();


    }

    // Update is called once per frame
    void Update()
    {
        anim.SetBool("isMoving",isJumping);

        if (EMM.stunTimer <= 0)
        {
            if(!isJumping)
            {
                if (waitTimer > 0)
                {
                    waitTimer -= Time.deltaTime;
                }
                if (waitTimer <= 0)
                {
                    rb.velocity += new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized * (moveSpd + Random.Range(-spdRandomness, spdRandomness));
                    jumpTimer = jumpLength + Random.Range(-jumpRandomness,jumpRandomness);
                    isJumping = true;
                }
            } else
            {
                if(jumpTimer > 0)
                {
                    jumpTimer -= Time.deltaTime;
                } else
                {
                    isJumping = false;
                    waitTimer = timeBetweenMovement + Random.Range(-timerRandomness, timerRandomness);
                    rb.velocity = Vector3.zero;
                }
            }
        } else
        {
            isJumping = false;
            waitTimer = timeBetweenMovement + Random.Range(-timerRandomness, timerRandomness);
        }
    }
}
