using UnityEngine;
using System.Collections;

public class EnemyMovementManager : MonoBehaviour {

    public float stunTimer;
    private Rigidbody2D rb;
    private float drag;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
        drag = rb.drag;
	
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
        }
	
	}
}
