using UnityEngine;
using System.Collections;

public class ToggleObjectBasedOnValue : MonoBehaviour {

    public bool activeWhenBlockStateActive;
    public GameObject objectToActivate;
    public GameObject particleWhenChanged;
    private BlockState blockState;
    private bool state;

	// Use this for initialization
	void Start () {
        blockState = FindObjectOfType<BlockState>();
	

	}
	
	// Update is called once per frame
	void Update () {
        if(state != blockState.state)
        {
            ChangeBlocks();
        }

	}


    public void ChangeBlocks()
    {
        state = blockState.state;

        if (particleWhenChanged)
        {
            Instantiate(particleWhenChanged, transform.position, transform.rotation);
        }
        if (blockState.state)
        {
            if (activeWhenBlockStateActive)
            {
                objectToActivate.SetActive(true);
            }
            else
            {
                objectToActivate.SetActive(false);
            }
        }
        else
        {
            if (activeWhenBlockStateActive)
            {
                objectToActivate.SetActive(false);
            }
            else
            {
                objectToActivate.SetActive(true);
            }
        }

    }
}
