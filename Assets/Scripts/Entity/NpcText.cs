using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class NpcText : MonoBehaviour {

    CircleCollider2D coll;
    CircleCollider2D playerColl;

    TextboxManager textbox;
    GameProgress Progress;
    public Conversation conversation;
    public int nodeIndex;

    Dictionary<int, Node> nodeDict = new Dictionary<int, Node>();

	// Use this for initialization
	void Start ()
    {
        coll = gameObject.GetComponent<CircleCollider2D>();
        playerColl = GameObject.FindGameObjectWithTag("Player").GetComponent<CircleCollider2D>();
        textbox = GameObject.FindGameObjectWithTag("GameManager").GetComponent<TextboxManager>();
        Progress = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameProgress>();

        if (conversation != null)
        {
            foreach( Node node in conversation.nodes)
            {
                nodeDict.Add(node.id, node);
            }
        }
    }
	
	
	void Update()
    {
        if(Input.GetButtonDown("Fire1") || Input.GetButtonDown("Fire2"))
        {
            if(playerColl.IsTouching(coll))
            {
                //Node cNode = conversation.nodes[nodeIndex];

                //if (checkConditions(cNode.conditions))
                //{
                //    textbox.ShowTextBox(cNode.text, true, false);
                //    do actions
                //}

                List<Node> trueNodes = getTrueChildNodes(conversation.nodes[nodeIndex]);

                // if olny one node returned true the just display that node.
                if (trueNodes.Count == 1)
                {
                    RunActions(trueNodes[0]);
                    textbox.ShowTextBox(trueNodes[0].text, true, false);

                    trueNodes[0].lastparentID = nodeIndex;
                    nodeIndex = trueNodes[0].id;

                    
                }
                //if more than one node is true. we need to figure out witch one we want to display.
                //maybe a priority value?
                else if (trueNodes.Count > 1)
                {
                    // currently were just picking the first true node ade using that....

                    RunActions(trueNodes[0]);
                    textbox.ShowTextBox(trueNodes[0].text, true, false);

                    trueNodes[0].lastparentID = nodeIndex;
                    nodeIndex = trueNodes[0].id;

                    
                }
                // if all child nodes conditions return false we fall back to calling the last node called.
                else if (trueNodes.Count == 0)
                {
                    //if all the last nodes conditions are still true then we use that.
                    if (checkConditions(conversation.nodes[nodeIndex].conditions))
                    {

                        RunActions(conversation.nodes[nodeIndex]);

                        textbox.ShowTextBox(conversation.nodes[nodeIndex].text, true, false);
                    }
                    else if (true)
                    {
                        int lastID = findParentByConditions(conversation.nodes[nodeIndex].lastparentID);

                        if (lastID != 0)
                        {
                            RunActions(conversation.nodes[lastID]);
                            textbox.ShowTextBox(conversation.nodes[lastID].text, true, false);

                            nodeIndex = lastID;
                        }
                        else
                        {
                            List<Node> trueChilds = getTrueChildNodes(conversation.nodes[0]);

                            if (trueChilds.Count != 0)
                            {
                                nodeIndex = trueChilds[0].id;
                                RunActions(conversation.nodes[nodeIndex]);
                                textbox.ShowTextBox(conversation.nodes[nodeIndex].text, true, false);
                            }
                        }
                    }

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
            else
            {
                print("No Condition");
                return true;
            }
            
        }
        return true;
    }

    int findParentByConditions (int id)
    {
        Node node = conversation.nodes[id];
        Node lastParent = conversation.nodes[node.lastparentID];

        if (checkConditions(node.conditions))
        {
            return node.id;
        }
        else if (checkConditions(lastParent.conditions))
        {
            return lastParent.id;
        }
        else
        {
            if (node.id != 0)
            {
                return findParentByConditions(lastParent.lastparentID);
            }
            else
            {
                List<Node> childs = getTrueChildNodes(conversation.nodes[0]);
                if (childs.Count != 0)
                {
                    return childs[0].id;
                }
                return 0;
            }
        }
    }

    List<Node> getTrueChildNodes (Node node)
    {
        List<Node> trueNodes = new List<Node>();

        foreach (int id in node.childIDs)
        {
            // check if all conditions are met.
            if (checkConditions(conversation.nodes[id].conditions))
            {
                //if they are add it to the list of trueNodes.
                trueNodes.Add(conversation.nodes[id]);
            }
        }
        return trueNodes;
    }

    void RunActions (Node node)
    {
        for (int i = 0; i < node.actionNames.Count; i++)
        {
            switch (node.actionNames[i])
            {
                case NpcAction.StartEvent:
                    Progress.StartEvent(node.actionParams[i]);
                    break;
                case NpcAction.EndEvent:
                    Progress.EndEvent(node.actionParams[i]);
                    break;
                case NpcAction.RemoveEvent:
                    Progress.Remove(node.actionParams[i]);
                    break;
            }
        }
    }
}