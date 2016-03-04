using UnityEngine;
using System.Collections;

public class DestroyOnCollision : MonoBehaviour
{

    public GameObject particleWhenDestroyed;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (particleWhenDestroyed != null)
        {
            Instantiate(particleWhenDestroyed, gameObject.transform.position, gameObject.transform.rotation);
        }
        Destroy(gameObject);
        Debug.Log(other.gameObject.name);
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if(particleWhenDestroyed != null)
        {
            Instantiate(particleWhenDestroyed, gameObject.transform.position, gameObject.transform.rotation);
        }
        Destroy(gameObject);

        Debug.Log(other.gameObject.name);
    }

}
