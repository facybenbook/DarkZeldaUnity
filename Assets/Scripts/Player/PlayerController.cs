using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    public float moveSpd;

    private Rigidbody2D player;
    private static bool playerExists;
    [HideInInspector]
    public float stunTimer;

	// Use this for initialization
	void Start () {
        player = GetComponent<Rigidbody2D>();


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
            player.velocity = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")).normalized * moveSpd;
            stunTimer = 0;
        }


    }
}
