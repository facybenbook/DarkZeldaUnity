using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    public float moveSpd;

    private Rigidbody2D player;
    private static bool playerExists;
    //private Animator anim;

	// Use this for initialization
	void Start () {
        player = GetComponent<Rigidbody2D>();
        //anim = GetComponent<Animator>();

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

        player.velocity = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")).normalized * moveSpd;

        //anim.SetFloat("curX", Input.GetAxis("Horizontal"));
        //anim.SetFloat("curY", Input.GetAxis("Vertical"));

    }
}
