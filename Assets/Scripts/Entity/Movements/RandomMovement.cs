using UnityEngine;
using System.Collections;

public class RandomMovement : MonoBehaviour {

    public float moveSpd;
    public float spdRandomness;
    public float timeBetweenMovement;
    public float timerRandomness;
    private float timer;
    private Rigidbody2D rb;
    private EnemyMovementManager EMM;
    public bool runFromPlayer;
    public float runRandomness;

	// Use this for initialization
	void Start () {
        timer = timeBetweenMovement + Random.Range(-timerRandomness, timerRandomness);
        rb = GetComponent<Rigidbody2D>();
        EMM = GetComponent<EnemyMovementManager>();
	
	}
	
	// Update is called once per frame
	void Update () {
        if(EMM.stunTimer <= 0)
        {
            if(timer > 0)
            {
                timer -= Time.deltaTime;
            }
            if(timer <= 0)
            {
                if(runFromPlayer && EMM.sightToPlayer)
                {
                    rb.velocity += (new Vector2(transform.position.x - EMM.player.transform.position.x, transform.position.y - EMM.player.transform.position.y) + new Vector2 (Random.Range(-runRandomness,runRandomness),Random.Range(-runRandomness,runRandomness))).normalized * (moveSpd + Random.Range(-spdRandomness, spdRandomness));
                }
                else
                {
                    rb.velocity += new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized * (moveSpd + Random.Range(-spdRandomness, spdRandomness));
                }
                timer = timeBetweenMovement + Random.Range(-timerRandomness, timerRandomness);

            }
        }
	}
}
