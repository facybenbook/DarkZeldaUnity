using UnityEngine;
using System.Collections;

public class HurtEnemyOnTouch : MonoBehaviour {

    public int dmg;

    public float knockback;
    public float knockbackRandomness;
    public float stunLock;
    public bool destroyAfter;
    public GameObject particleWhenDestroyed;

    private Collider col;

    // Use this for initialization
    void Start()
    {

        col = GetComponent<Collider>();

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            HealthController enemyHpCon = other.gameObject.GetComponent<HealthController>();
            if (enemyHpCon != null && enemyHpCon.timer <= 0)
            {
                enemyHpCon.ChangeHealth(dmg);

                if (knockback > 0)
                {
                    Rigidbody2D enemy = other.gameObject.GetComponent<Rigidbody2D>();
                    enemy.velocity = (enemy.transform.position - gameObject.transform.position) * (knockback + Random.Range(-knockbackRandomness, knockbackRandomness));
                }
                if (stunLock > 0)
                {
                    EnemyMovementManager ec = other.gameObject.GetComponent<EnemyMovementManager>();
                    if (ec != null)
                    {
                        ec.stunTimer = stunLock;
                    }
                }

                Debug.Log("Enemy Hit");

                if (destroyAfter)
                {
                    DestroyObject();
                }
            }
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            HealthController enemyHpCon = other.gameObject.GetComponent<HealthController>();
            if (enemyHpCon != null && enemyHpCon.timer <= 0)
            {
                enemyHpCon.ChangeHealth(dmg);

                if (knockback > 0)
                {
                    Rigidbody2D enemy = other.gameObject.GetComponent<Rigidbody2D>();
                    enemy.velocity = (enemy.transform.position - gameObject.transform.position) * (knockback + Random.Range(-knockbackRandomness, knockbackRandomness));
                }
                if (stunLock > 0)
                {
                    EnemyMovementManager ec = other.gameObject.GetComponent<EnemyMovementManager>();
                    if (ec != null)
                    {
                        ec.stunTimer = stunLock;
                    }
                }

                Debug.Log("Enemy Hit");

                if (destroyAfter)
                {
                    DestroyObject();
                }
            }
        }

    }

    void DestroyObject()
    {
        if (particleWhenDestroyed != null)
        {
            Instantiate(particleWhenDestroyed, gameObject.transform.position, gameObject.transform.rotation);
        }

        Destroy(gameObject);
    }
}