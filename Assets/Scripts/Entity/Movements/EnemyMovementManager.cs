using UnityEngine;
using System.Collections;

public class EnemyMovementManager : MonoBehaviour {

    public float stunTimer;
    public bool flipSpriteBasedOnVelX;
    private Rigidbody2D rb;
    private float drag;
    private SpriteRenderer sprite;
    private Rigidbody2D obj;

    public float enemySightRange;
    public LayerMask playerLayerMask;
    public LayerMask sightLayerMask;
    public bool cardinalDirSightLock;

    private bool playerInRange;
    public bool sightToPlayer;
    private RaycastHit2D rayToPlayer;
    private RaycastHit2D rayUp;
    private RaycastHit2D rayDown;
    private RaycastHit2D rayLeft;
    private RaycastHit2D rayRight;
    [HideInInspector] public GameObject player;

    public bool trackDistance;
    public float distanceToPlayer;

    private float atkTimer;

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody2D>();
        drag = rb.drag;
        sprite = GetComponent<SpriteRenderer>();
        obj = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");
        stunTimer = 1f;
    }
	
	// Update is called once per frame
	void Update () {

        if(stunTimer > 0)
        {
            stunTimer -= Time.deltaTime;
            rb.drag = drag * 2;
        }
        else
        {
            stunTimer = 0f;
            rb.drag = drag;


            CheckVisionToPlayer();



            if (flipSpriteBasedOnVelX)
            {
                if (obj.velocity.x > 0)
                {
                    sprite.flipX = false;
                }
                else if (obj.velocity.x < 0)
                {
                    sprite.flipX = true;
                }
            }

        }


        if (atkTimer > 0)
        {
            atkTimer -= Time.deltaTime;
            sightToPlayer = true;
        }



    }

    public void SetVisionTrue()
    {
        if (player != null)
        {
            Debug.DrawRay(transform.position, (player.transform.position - transform.position), Color.white);
            sightToPlayer = true;
            if(atkTimer <= 0 && cardinalDirSightLock)
            {
                atkTimer = 0.5f;
            }
        }
    }

    public void CheckVisionToPlayer()
    {

        playerInRange = Physics2D.OverlapCircle(transform.position, enemySightRange, playerLayerMask);
        sightToPlayer = false;
        if (playerInRange)
        {

            if (trackDistance)
            {
                distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);
            }


            if (cardinalDirSightLock)
            {
                rayUp = Physics2D.Raycast(transform.position, Vector2.up, enemySightRange, sightLayerMask);
                rayDown = Physics2D.Raycast(transform.position, Vector2.down, enemySightRange, sightLayerMask);
                rayLeft = Physics2D.Raycast(transform.position, Vector2.left, enemySightRange, sightLayerMask);
                rayRight = Physics2D.Raycast(transform.position, Vector2.right, enemySightRange, sightLayerMask);

                if (rayUp.collider != null)
                {
                    if (rayUp.collider.gameObject.tag == "Player")
                    {
                        SetVisionTrue();
                    }

                }
                if (rayDown.collider != null)
                {
                    if (rayDown.collider.gameObject.tag == "Player")
                    {
                        SetVisionTrue();
                    }

                }
                if (rayLeft.collider != null)
                {
                    if (rayLeft.collider.gameObject.tag == "Player")
                    {
                        SetVisionTrue();
                    }

                }
                if (rayRight.collider != null)
                {
                    if (rayRight.collider.gameObject.tag == "Player")
                    {
                        SetVisionTrue();
                    }

                }

            }
            else
            {
                rayToPlayer = Physics2D.Raycast(transform.position, (player.transform.position - transform.position), enemySightRange, sightLayerMask);
                if (rayToPlayer.collider != null)
                {
                    if (rayToPlayer.collider.gameObject.tag == "Player")
                    {
                        SetVisionTrue();
                    }
                }
            }
        }






    }


}
