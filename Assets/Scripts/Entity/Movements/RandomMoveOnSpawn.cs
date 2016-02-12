using UnityEngine;
using System.Collections;

public class RandomMoveOnSpawn : MonoBehaviour {

    public float moveSpd;
    public float spdRandomness;
    private Rigidbody2D rb;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity += new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized * (moveSpd + Random.Range(-spdRandomness, spdRandomness));

    }
	
	// Update is called once per frame
	void Update () {

	}
}
