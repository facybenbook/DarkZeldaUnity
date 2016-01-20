using UnityEngine;
using System.Collections;

public class HurtPlayerOnTouch : MonoBehaviour {

    public int dmg;

    public float knockback;
    public float knockbackRandomness;
    public float stunLock;

    private CameraShake cam;
    private Collider col;

	// Use this for initialization
	void Start () {

        col = GetComponent<Collider>();
        cam = FindObjectOfType<CameraShake>();
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.name == "Player")
        {
            if(knockback > 0)
            {
                Rigidbody2D player = other.gameObject.GetComponent<Rigidbody2D>();
                player.velocity = (player.transform.position - gameObject.transform.position) * (knockback + Random.Range(-knockbackRandomness, knockbackRandomness));
            }
            HealthController playerHpCon = other.gameObject.GetComponent<HealthController>();
            if(playerHpCon != null)
            {
                playerHpCon.ChangeHealth(dmg);
            }
            if(stunLock > 0)
            {
                PlayerController pc = other.gameObject.GetComponent<PlayerController>();
                if(pc != null)
                {
                    pc.stunTimer = stunLock;
                }
            }
            Debug.Log("Player Hit");
            cam.Shake(0.1f, 0.2f);

        }
    }
}
