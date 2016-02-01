using UnityEngine;
using System.Collections.Generic;

[System.Serializable]
public class Node : ScriptableObject {

    public int id;

    public float x;
    public float y;
    public float width;
    public float height;

    public bool hideConditions= false;
    public bool hideText = false;
    public bool hideActions = false;

    public string text;

    public List<int> childIDs;

    public string conditions;

    public List<NpcAction> actionNames;
    public List<string> actionParams;

    public int lastparentID;

    void OnEnable()
    {
        if (childIDs == null)
        {
            childIDs = new List<int>();
        }
        if (conditions == null)
        {
            conditions = "";
        }
        if (text == null)
        {
            text = "";
        }
        if (actionNames == null)
        {
            actionNames = new List<NpcAction>();
        }
        if (actionParams == null)
        {
            actionParams = new List<string>();
        }

        //hideFlags = HideFlags.HideInHierarchy;
    }

}
