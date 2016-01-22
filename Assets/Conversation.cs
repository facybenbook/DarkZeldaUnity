using UnityEngine;
using System.Collections.Generic;
using System.Reflection;

[System.Serializable]
public class Conversation : ScriptableObject {

    public List<Node> nodes;
    public int nextID;

    public void OnEnable ()
    {
        if (nodes == null)
            nodes = new List<Node>();
    }
}