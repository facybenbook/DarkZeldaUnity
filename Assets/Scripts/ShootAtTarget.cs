using UnityEngine;
using System.Collections;

public class ShootAtTarget : MonoBehaviour {

    public float timeBetweenShots;
    public float timeRandomness;
    public float startDelay;
    public GameObject projectile;
    public float shootSpd;
    public GameObject spawn;
    public GameObject target;
    private float timer;
    private GameObject projectileInstance;

	// Use this for initialization
	void Start () {
        timer = startDelay;
	
	}
	
	// Update is called once per frame
	void Update () {
        if(timer > 0)
        {
            timer -= Time.deltaTime;
        } else
        {
            timer = timeBetweenShots + Random.Range(-timeRandomness, timeRandomness);
            ShootProjectile();
        }
	
	}

    void ShootProjectile()
    {
        projectileInstance = Instantiate(projectile, spawn.transform.position, spawn.transform.rotation) as GameObject;

        Rigidbody2D projectileRB = projectileInstance.GetComponent<Rigidbody2D>();

        if(projectileRB != null)
        {
            projectileRB.velocity = (target.transform.position- projectileRB.transform.position).normalized * shootSpd;
            //Debug.Log((projectileRB.transform.position - target.transform.position).normalized * shootSpd);
        }

    }
}
