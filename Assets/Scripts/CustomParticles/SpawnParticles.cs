using UnityEngine;
using System.Collections;

public class SpawnParticles : MonoBehaviour {

    public GameObject particle;
    public float spawnRadius;
    public int numToSpawn;
    private GameObject particleInstance;

    // Use this for initialization
    void Start () {


        for(int i = 0; i < numToSpawn; i++)
        {
            Vector3 randomPos = transform.position + new Vector3(Random.Range(-spawnRadius, spawnRadius), Random.Range(-spawnRadius, spawnRadius));
            particleInstance = Instantiate(particle, randomPos, transform.rotation) as GameObject;
            particleInstance.GetComponent<SpriteRenderer>().sortingOrder = 10 + i;
        }
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
