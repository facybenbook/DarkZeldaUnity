using UnityEngine;
using System.Collections.Generic;

public class Node  {

    public static int Count = 0;

    public Rect rect;
    public int id;
    public List<int> children = new List<int>();

    public Node (Rect position)
    {
        rect = position;
        id = Count;
        Count++;
    }

}
