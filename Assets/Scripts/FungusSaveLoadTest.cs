using UnityEngine;
using System.Collections;
using Fungus;

public class FungusSaveLoadTest : MonoBehaviour {

    public Flowchart flowchart;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown("1"))
        {
            flowchart.SendFungusMessage("Save");
        }
        if (Input.GetKeyDown("2"))
        {
            flowchart.SendFungusMessage("Load");
        }

    }
}
