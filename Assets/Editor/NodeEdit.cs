using UnityEngine;
using UnityEditor;
using System.Collections.Generic;


public class NodeEdit : EditorWindow
{
    Conversation convo;

    public List<Node> NodeList;
    public Dictionary<int, Node> NodeDict;

    NodeEdit editor;

    [MenuItem("Custom Editors/NodeEdit")]
    static void ShowEditor()
    {
        NodeEdit editor = EditorWindow.GetWindow<NodeEdit>();
    }

     void OnEnable ()
    {
        Debug.Log("Enabled.");

        if(Selection.activeGameObject != null)
        {
            NpcText npcText = Selection.activeGameObject.GetComponentInChildren<NpcText>();

            if (npcText != null)
            {
                if (npcText.conversation != null)
                {
                    Debug.Log("Conversation found.");
                    convo = npcText.conversation;
                }
                else
                {
                    Debug.Log("No conversation asset.");
                    convo = ScriptableObject.CreateInstance<Conversation>();
                    npcText.conversation = convo;
                }
            } 
        }
    }

    void OnDisable()
    {
        Debug.Log("Disabled.");
    }

    void OnGUI()
    {
        GUILayout.Label("Serealized Things");
        //node.OnGUI();
    }
}