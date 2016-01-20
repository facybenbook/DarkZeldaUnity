using UnityEngine;
using System.Collections.Generic;
using System.Reflection;


public class Conversation : ScriptableObject {

    //public  Dictionary<int, Node> nodes = new Dictionary<int, Node>();
    public List<Node> nodes = new List<Node>();
    private int id = 0;
    public int nextId
    {
        get
        {
            int nextId = id;
            id++;
            return nextId;

        }
    }

}