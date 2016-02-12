using UnityEngine;
using System.Collections;

public class DestroyAfterTime : MonoBehaviour {

    public float timer;
    public float randomness;

    public GameObject particleWhenDestroyed;

    // Use this for initialization
    void Start () {
        timer += Random.Range(-randomness, randomness);
	
	}
	
	// Update is called once per frame
	void Update () {
        timer -= Time.deltaTime;
        if(timer < 0)
        {
            DestroyObject();
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
