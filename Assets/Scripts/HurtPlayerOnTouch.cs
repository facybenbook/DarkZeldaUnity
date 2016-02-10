using UnityEngine;
using System.Collections;

public class HurtPlayerOnTouch : MonoBehaviour {

    public int dmg;

    public float knockback;
    public float knockbackRandomness;
    public float stunLock;
    public bool destroyAfter;
    public GameObject particleWhenDestroyed;

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
        if(other.gameObject.tag == "Player")
        {
            HealthController playerHpCon = other.gameObject.GetComponent<HealthController>();
            if (playerHpCon != null && playerHpCon.timer <= 0)
            {
                playerHpCon.ChangeHealth(dmg);

                if (knockback > 0)
                {
                    Rigidbody2D player = other.gameObject.GetComponent<Rigidbody2D>();
                    player.velocity = (player.transform.position - gameObject.transform.position) * (knockback + Random.Range(-knockbackRandomness, knockbackRandomness));
                }
                if (stunLock > 0)
                {
                    PlayerController pc = other.gameObject.GetComponent<PlayerController>();
                    if (pc != null)
                    {
                        pc.stunTimer = stunLock;
                    }
                }

                Debug.Log("Player Hit");
                cam.Shake(0.1f, 0.2f);

                if (destroyAfter)
                {
                    DestroyObject();
                }
            }
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            HealthController playerHpCon = other.gameObject.GetComponent<HealthController>();
            if (playerHpCon != null && playerHpCon.timer <= 0)
            {
                playerHpCon.ChangeHealth(dmg);

                if (knockback > 0)
                {
                    Rigidbody2D player = other.gameObject.GetComponent<Rigidbody2D>();
                    player.velocity = (player.transform.position - gameObject.transform.position) * (knockback + Random.Range(-knockbackRandomness, knockbackRandomness));
                }
                if (stunLock > 0)
                {
                    PlayerController pc = other.gameObject.GetComponent<PlayerController>();
                    if (pc != null)
                    {
                        pc.stunTimer = stunLock;
                    }
                }

                Debug.Log("Player Hit");
                cam.Shake(0.1f, 0.2f);

                if (destroyAfter)
                {
                    DestroyObject();
                }
            }
        }
    }

    void DestroyObject()
    {
        if(particleWhenDestroyed != null)
        {
            Instantiate(particleWhenDestroyed, gameObject.transform.position, gameObject.transform.rotation);
        }

        Destroy(gameObject);
    }
}
