using UnityEngine;
using System.Collections;
using Fungus;

public class ToggleBlockState : MonoBehaviour {
    private bool inRange;
    private Pause pauseScript;
    private BlockState blockState;
    private Animator anim;
    private CameraShake cam;
    private float timer;
    private CallFungusBlock callBlock;
    public Flowchart flowchart;


    // Use this for initialization
    void Start () {
        blockState = FindObjectOfType<BlockState>();
        pauseScript = FindObjectOfType<Pause>();
        anim = GetComponent<Animator>();
        cam = FindObjectOfType<CameraShake>();


	}
	
	// Update is called once per frame
	void Update () {
        anim.SetBool("active", blockState.state);
        if (inRange && Input.GetButtonDown("Interact") && pauseScript.paused == false && timer <= 0)
        {
            //flowchart.ExecuteBlock("Lever");
            timer = 0.9f;
            //pauseScript.PauseGame(true);
            blockState.changeState = true;
            cam.Shake(0.5f, 0.1f);
        }
	
        if(timer >0)
        {
            timer -= Time.deltaTime;
        }
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.name == "Player")
        {
            inRange = true;
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.name == "Player")
        {
            inRange = false;
        }
    }
}
