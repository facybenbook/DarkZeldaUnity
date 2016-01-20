using UnityEngine;
using System.Collections.Generic;

[System.Serializable]
public class Node : ScriptableObject {

    int id;
    string text;
    List<int> childIDs;

    public void OnGUI ()
    {
        GUILayout.Label(id.ToString());
        text = GUILayout.TextArea(text);
    }

}
