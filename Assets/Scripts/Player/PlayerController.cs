using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    public float moveSpd;

    private Rigidbody2D player;
    private static bool playerExists;
    [HideInInspector]
    public float stunTimer;
    public Pause pauseScript;
    private PlayerAttacking attackScript;

	// Use this for initialization
	void Start () {
        player = GetComponent<Rigidbody2D>();
        pauseScript = FindObjectOfType<Pause>();
        attackScript = GetComponent<PlayerAttacking>();


        if (!playerExists)
        {
            playerExists = true;
            DontDestroyOnLoad(transform.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

	
	}
	
	// Update is called once per frame
	void Update () {
        if(stunTimer > 0)
        {
            stunTimer -= Time.deltaTime;
        }
        else
        {
            stunTimer = 0;
            if (pauseScript.paused)
            {
                player.velocity = Vector2.zero;
                return;
            }
            if(attackScript.attackDelay <= 0)
            {
                player.velocity = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")).normalized * moveSpd;
            } else
            {
                player.velocity = Vector3.Lerp(player.velocity, Vector3.zero, 0.2f);
            }
        }


    }
}
