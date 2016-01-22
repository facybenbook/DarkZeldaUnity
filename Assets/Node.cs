using UnityEngine;
using System.Collections.Generic;

[System.Serializable]
public class Node : ScriptableObject {

    public int id;

    public float x;
    public float y;
    public string text;
    public List<int> childIDs;

    void OnEnable()
    {
        if (childIDs == null)
        {
            childIDs = new List<int>();
        }

        if (text == null)
        {
            text = "";
        }

        //hideFlags = HideFlags.HideInHierarchy;
    }

}
