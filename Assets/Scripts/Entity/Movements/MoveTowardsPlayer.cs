using UnityEngine;
using System.Collections;

public class MoveTowardsPlayer : MonoBehaviour {

    public float moveSpd;
    public float spdRandomness;
    public float AgroMoveSpd;
    public float AgroSpdRandomness;
    public float timeBetweenMovement;
    public float timerRandomness;
    public bool jumpWhenMoving;
    public float jumpLength;
    public float jumpRandomness;
    public bool lookForPlayer;
    public float targetRandomness;
    public float chaseTimeoutTime;
    private float chaseTimer;
    private float jumpTimer;
    private bool isJumping;
    private float waitTimer;
    private Rigidbody2D rb;
    private EnemyMovementManager EMM;
    private GameObject player;
    private Vector3 targetPos;
    private bool chasePlayer;

    private Animator anim;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        EMM = GetComponent<EnemyMovementManager>();
        player = GameObject.FindGameObjectWithTag("Player");
        anim = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        if(Vector2.Distance(transform.position,targetPos) < 1 || chaseTimer <= 0)
        {
            chasePlayer = false;
        }
        if(chaseTimer > 0)
        {
            chaseTimer -= Time.deltaTime;
        }
        if (EMM.stunTimer <= 0)
        {

            if (jumpWhenMoving)
            {
                anim.SetBool("isMoving", isJumping);

                if (!isJumping)
                {
                    if (waitTimer > 0)
                    {
                        waitTimer -= Time.deltaTime;
                    }
                    if (waitTimer <= 0)
                    {
                        if(EMM.sightToPlayer)
                        {
                            if(lookForPlayer)
                            {
                                chasePlayer = true;
                                chaseTimer = chaseTimeoutTime;
                            }
                            targetPos = player.transform.position + new Vector3(Random.Range(-targetRandomness, targetRandomness), Random.Range(-targetRandomness, targetRandomness));
                            rb.velocity += new Vector2(targetPos.x - transform.position.x, targetPos.y - transform.position.y).normalized * (AgroMoveSpd + Random.Range(-AgroSpdRandomness, AgroSpdRandomness));
                            jumpTimer = jumpLength + Random.Range(-jumpRandomness, jumpRandomness);
                            isJumping = true;
                        }
                        else
                        {
                            if(chasePlayer)
                            {
                                rb.velocity += new Vector2(targetPos.x - transform.position.x + Random.Range(-1f, 1f), targetPos.y - transform.position.y + Random.Range(-1f, 1f)).normalized * (AgroMoveSpd + Random.Range(-AgroSpdRandomness, AgroSpdRandomness));
                            }
                            else
                            {
                                targetPos = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f));
                                rb.velocity += new Vector2(targetPos.x, targetPos.y).normalized * (moveSpd + Random.Range(-spdRandomness, spdRandomness));
                            }
                            jumpTimer = jumpLength + Random.Range(-jumpRandomness, jumpRandomness);
                            isJumping = true;
                        }

                    }
                }
                else
                {
                    if (jumpTimer > 0)
                    {
                        jumpTimer -= Time.deltaTime;
                    }
                    else
                    {
                        isJumping = false;
                        waitTimer = timeBetweenMovement + Random.Range(-timerRandomness, timerRandomness);
                        rb.velocity = Vector3.zero;
                    }
                }
            }
            else
            {
                if (waitTimer > 0)
                {
                    waitTimer -= Time.deltaTime;
                }
                if (waitTimer <= 0)
                {
                    if (EMM.sightToPlayer)
                    {
                        if(lookForPlayer)
                        {
                            chasePlayer = true;
                            chaseTimer = chaseTimeoutTime;
                        }
                        targetPos = player.transform.position + new Vector3(Random.Range(-targetRandomness,targetRandomness), Random.Range(-targetRandomness, targetRandomness));
                        anim.SetBool("isMoving", true);
                        rb.velocity += new Vector2(targetPos.x - transform.position.x, targetPos.y - transform.position.y).normalized * (AgroMoveSpd + Random.Range(-AgroSpdRandomness, AgroSpdRandomness));
                        waitTimer = timeBetweenMovement + Random.Range(-timerRandomness, timerRandomness);
                    }
                    else
                    {
                        if(chasePlayer)
                        {
                            rb.velocity += new Vector2(targetPos.x - transform.position.x + Random.Range(-1f, 1f), targetPos.y - transform.position.y + Random.Range(-1f, 1f)).normalized * (AgroMoveSpd + Random.Range(-AgroSpdRandomness, AgroSpdRandomness));
                        }
                        else
                        {
                            targetPos = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f));
                            rb.velocity += new Vector2(targetPos.x, targetPos.y).normalized * (moveSpd + Random.Range(-spdRandomness, spdRandomness));
                            anim.SetBool("isMoving", false);
                        }
                        waitTimer = timeBetweenMovement + Random.Range(-timerRandomness, timerRandomness);
                    }
                }
            }
        }
        else
        {
            if(jumpWhenMoving)
            {
                isJumping = false;
                waitTimer = timeBetweenMovement + Random.Range(-timerRandomness, timerRandomness);
            }
        }



    }

}

