using UnityEngine;
using System.Collections;

public class SpikeTrap : MonoBehaviour {

    public bool waitForPlayerInteraction;
    public float timeToActivate;
    public float timeBetweenActivation;
    public float timeRandomness;
    public float startDelay;

    private float timer;
    private Pause pauseScript;
    private Animator anim;
    private bool playerInteract;

	// Use this for initialization
	void Start () {
        pauseScript = FindObjectOfType<Pause>();
        anim = GetComponent<Animator>();
        timer = startDelay;

    }
	
	// Update is called once per frame
	void Update () {
        if(pauseScript.paused)
        {
            return;
        }
        if(playerInteract)
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                Activate();
            }
        }
        if(waitForPlayerInteraction)
        {
            return;
        }
        if(timer > 0)
        {
            timer -= Time.deltaTime;
        }
        else
        {
            Activate();
        }

	
	}

    void Activate()
    {
        timer = timeBetweenActivation + Random.Range(-timeRandomness, timeRandomness);
        anim.SetTrigger("Activate");
        playerInteract = false;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(waitForPlayerInteraction && other.tag == "Player" && !playerInteract)
        {
            timer = timeBetweenActivation + Random.Range(-timeRandomness, timeRandomness);
            playerInteract = true;
        }
    }
    void OnTriggerExit2d(Collider2D other)
    {
        if(waitForPlayerInteraction && other.tag == "Player")
        {
            timer = timeBetweenActivation + Random.Range(-timeRandomness, timeRandomness);
        }
    }
}
