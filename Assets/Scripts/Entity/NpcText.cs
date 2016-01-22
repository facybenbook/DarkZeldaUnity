using UnityEngine;
using System.Collections;
public class NpcText : MonoBehaviour {

    CircleCollider2D coll;
    CircleCollider2D playerColl;

    TextboxManager textbox;
    GameProgress Progress;
    public Conversation conversation;
    public int nodeIndex =0;

	// Use this for initialization
	void Start ()
    {
        coll = gameObject.GetComponent<CircleCollider2D>();
        playerColl = GameObject.FindGameObjectWithTag("Player").GetComponent<CircleCollider2D>();
        textbox = GameObject.FindGameObjectWithTag("GameManager").GetComponent<TextboxManager>();
        Progress = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameProgress>();
    }
	
	
	void Update()
    {
        if(Input.GetButtonDown("Fire1") || Input.GetButtonDown("Fire2"))
        {
            if(playerColl.IsTouching(coll))
            {
                Node cNode = conversation.nodes[nodeIndex];

                if (checkConditions(cNode.conditions))
                {
                    textbox.ShowTextBox(cNode.text, true, false);
                    //do actions
                }

                //do textbox stuff if some game events are completed/active/not started

                //public int Cnode;
                // Node cNode = conversation.nodes[cNode]
                // if (doConditions(cnode.conditions) == true)
                // ??       CallTextBox(cNode.text)
                // ?? for each action in cNode.actions
                //          Do simple Action like update the game progression dictionarys;
            }
        }
    }

    bool checkConditions (string conditionsString)
    {
        string[] conditions = conditionsString.Split(' ');

        foreach (string condition in conditions)
        {
            if (condition != "")
            {
                if (condition.StartsWith("!"))
                {
                    if (Progress.eventExists(condition.Remove(0, 1)))
                    {
                        return false;
                    }
                }
                else
                {
                    if (!Progress.eventExists(condition))
                    {
                        return false;
                    }
                }
            }
            
        }
        return true;
    }
}
