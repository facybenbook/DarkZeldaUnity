using UnityEngine;
using System.Collections;

public class NpcText : MonoBehaviour {

    CircleCollider2D coll;
    CircleCollider2D playerColl;

    public Conversation[] conversation;

	// Use this for initialization
	void Start ()
    {
        coll = gameObject.GetComponent<CircleCollider2D>();
        playerColl = GameObject.FindGameObjectWithTag("Player").GetComponent<CircleCollider2D>();
    }
	
	
	void Update()
    {
        if(Input.GetButtonDown("Fire1") || Input.GetButtonDown("Fire2"))
        {
            if(playerColl.IsTouching(coll))
            {
                //do textbox stuff if some game events are completed/active/not started
                print("npc Triggered.");
            }
        }
    }
}
