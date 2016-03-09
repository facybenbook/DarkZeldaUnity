using UnityEngine;
using System.Collections;
using Fungus;

public class SetBlockState : MonoBehaviour {

    private Pause pauseScript;
    private BlockState blockState;
    private CallFungusBlock callBlock;
    public Flowchart flowchart;
    private SpriteRenderer sprite;
    public bool setBlockStateActive;
    private CameraShake cam;

    // Use this for initialization
    void Start () {
        blockState = FindObjectOfType<BlockState>();
        pauseScript = FindObjectOfType<Pause>();
        sprite = GetComponent<SpriteRenderer>();
        cam = FindObjectOfType<CameraShake>();
    }
	
	// Update is called once per frame
	void Update () {

        if(blockState.state == setBlockStateActive)
        {
            sprite.enabled = false;
        }
        else
        {
            sprite.enabled = true;
        }
	
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if(blockState.state != setBlockStateActive)
        {
            blockState.state = setBlockStateActive;
            cam.Shake(0.5f, 0.1f);
        }
        /*
        if (blockState.state != setBlockStateActive)
        {
            blockState.state = setBlockStateActive;
        }
        */
    }

    void OnTriggerExit2D(Collider2D other)
    {
    }
}
