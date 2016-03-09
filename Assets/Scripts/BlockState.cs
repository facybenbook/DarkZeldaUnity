using UnityEngine;
using System.Collections;

public class BlockState : MonoBehaviour {

    public bool state;
    public bool changeState;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (changeState)
        {
            state = !state;
            changeState = false;
        }
	
	}
}
