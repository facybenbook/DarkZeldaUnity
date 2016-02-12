using UnityEngine;
using System.Collections;

public class EnemyMovementManager : MonoBehaviour {

    public float stunTimer;
    public bool flipSpriteBasedOnVelX;
    private Rigidbody2D rb;
    private float drag;
    private SpriteRenderer sprite;
    private Rigidbody2D obj;

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody2D>();
        drag = rb.drag;
        sprite = GetComponent<SpriteRenderer>();
        obj = GetComponent<Rigidbody2D>();

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

    }
}
