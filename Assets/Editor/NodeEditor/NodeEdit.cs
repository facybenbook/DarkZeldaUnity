using UnityEngine;
using UnityEditor;
using System.Collections.Generic;


public class NodeEdit : EditorWindow
{
    public Dictionary<int, Node> NodeDict;
    public Dictionary<int, Rect> nodeWindows;
    public List<Node> dirtyList;

    NpcText npcText;

    NodeEdit editor;
    GameObject lastSelected;

    List<int> linkNodes;
    List<int> unLinkNodes;

    public Vector2 scrollPosition;

    [MenuItem("Custom Editors/NodeEdit")]
    static void ShowEditor()
    {
        NodeEdit editor = EditorWindow.GetWindow<NodeEdit>();
    }

     void OnEnable ()
    {
        linkNodes = new List<int>();
        dirtyList = new List<Node>();
        unLinkNodes = new List<int>();
        if (nodeWindows == null)
            nodeWindows = new Dictionary<int, Rect>();
        if (NodeDict == null)
            NodeDict = new Dictionary<int, Node>();
        if (scrollPosition == null)
            scrollPosition = Vector2.zero;

        InitConversation();
    }

    void OnGUI()
    {
        if (Selection.activeGameObject == null)
            return;

        if (npcText == null)
            return;

        if (linkNodes.Count == 2)
        {
            NodeDict[linkNodes[0]].childIDs.Add(linkNodes[1]);

            if (!dirtyList.Contains(NodeDict[linkNodes[0]]))
            {
                dirtyList.Add(NodeDict[linkNodes[0]]);
            }

            linkNodes.Clear();
        }

        if (unLinkNodes.Count == 2)
        {
            NodeDict[unLinkNodes[0]].childIDs.Remove(unLinkNodes[1]);

            if (!dirtyList.Contains(NodeDict[unLinkNodes[0]]))
            {
                dirtyList.Add(NodeDict[unLinkNodes[0]]);
            }

            unLinkNodes.Clear();
        }
        EditorGUILayout.BeginHorizontal();
        if (GUILayout.Button("Create Node"))
        {
            Node newNode = ScriptableObject.CreateInstance<Node>() as Node;
            AssetDatabase.AddObjectToAsset(newNode, npcText.conversation);

            newNode.id = npcText.conversation.nextID;
            npcText.conversation.nextID++;

            newNode.x = scrollPosition.x;
            newNode.y = scrollPosition.y;

            newNode.width = 250;
            newNode.height = 75;

            npcText.conversation.nodes.Add(newNode);
            NodeDict.Add(newNode.id, newNode);
            nodeWindows.Add(newNode.id, new Rect(newNode.x, newNode.y, newNode.width, newNode.height));

            AssetDatabase.SaveAssets();
        }

        if (GUILayout.Button("Save Conversation"))
        {
            for (int i = 0; i < dirtyList.Count; i++)
            {
                EditorUtility.SetDirty(dirtyList[i]);
            }
        }
        EditorGUILayout.EndHorizontal();

        scrollPosition = GUI.BeginScrollView(new Rect(0, 20, position.width, position.height-20), scrollPosition, new Rect(0, 0, 5000, 5000), true, true);
        BeginWindows();

        foreach (Node node in npcText.conversation.nodes)
        {
            if (nodeWindows.ContainsKey(node.id))
            {
                Rect newrect = GUILayout.Window(node.id, nodeWindows[node.id], nodeGUI, node.id.ToString());
                nodeWindows[node.id] = new Rect(newrect.x, newrect.y, nodeWindows[node.id].width, nodeWindows[node.id].height);
            }
            foreach (int childID in node.childIDs)
            {
                DrawNodeCurve(nodeWindows[node.id], nodeWindows[childID]);
            }
        }

        EndWindows();
        GUI.EndScrollView();
        AssetDatabase.SaveAssets();
    }

    void DrawNodeCurve(Rect start, Rect end)
    {
        Vector3 startPos = new Vector3(start.x + start.width, start.y + start.height / 2, 0);
        Vector3 endPos = new Vector3(end.x, end.y + end.height / 2, 0);
        Vector3 startTan = startPos + Vector3.right * 50;
        Vector3 endTan = endPos + Vector3.left * 50;
        Color shadowCol = new Color(0, 0, 0, 0.06f);

        for (int i = 0; i < 3; i++)
        {// Draw a shadow
            Handles.DrawBezier(startPos, endPos, startTan, endTan, shadowCol, null, (i + 1) * 5);
        }

        Handles.DrawBezier(startPos, endPos, startTan, endTan, Color.black, null, 1);
    }

    public void nodeGUI(int id)
    {
        bool dirty = false;
        Node node = NodeDict[id];

        EditorGUILayout.BeginHorizontal();
        if (GUILayout.Button("Link"))
        {
            if (!linkNodes.Contains(id))
            {
                linkNodes.Add(id);
            }
        }
        if (GUILayout.Button("UnLink"))
        {
            if (!unLinkNodes.Contains(id))
            {
                unLinkNodes.Add(id);
            }
        }
        EditorGUILayout.EndHorizontal();

        node.hideConditions = EditorGUILayout.Foldout(node.hideConditions, "Conditions");

        if (node.hideConditions)
        {
            string newConditions = GUILayout.TextArea(node.conditions);

            if (node.conditions != newConditions)
            {
                node.conditions = newConditions;
                dirty = true;
            }
        }

        node.hideText = EditorGUILayout.Foldout(node.hideText, "Text");

         if (node.hideText)
        {
            string newText = GUILayout.TextArea(node.text);
            if (node.text != newText)
            {
                node.text = newText;
                dirty = true;
            }
        }

        node.hideActions = EditorGUILayout.Foldout(node.hideActions, "Actions");

        if (node.hideActions)
        {
            for(int i = 0; i < node.actionNames.Count; i++)
            {
                EditorGUILayout.BeginHorizontal();
                NpcAction newAction = (NpcAction)EditorGUILayout.EnumPopup(node.actionNames[i], GUILayout.Width(60));

                if (newAction != node.actionNames[i])
                {
                    node.actionNames[i] = newAction;
                    dirty = true;
                }
                string newParam = GUILayout.TextField(node.actionParams[i]);

                if (newParam != node.actionParams[i])
                {
                    node.actionParams[i] = newParam;
                    dirty = true;
                }

                if (GUILayout.Button("-", GUILayout.Width(20)))
                {
                    node.actionParams.RemoveAt(i);
                    node.actionNames.RemoveAt(i);
                    dirty = true;
                }

                EditorGUILayout.EndHorizontal();
            }

            if (GUILayout.Button("+"))
            {
                // create a new action.
                node.actionNames.Add(new NpcAction());
                node.actionParams.Add("");
                dirty = true;
                
            }
        }

        if (node.x != nodeWindows[id].position.x)
        {
            node.x = nodeWindows[id].position.x;
            dirty = true;
        }
        if (node.y != nodeWindows[id].position.y)
        {
            node.y = nodeWindows[id].position.y;
            dirty = true;
        }

        if (dirty)
        {
            if (!dirtyList.Contains(node)) {
                dirtyList.Add(node);
            }
        }
        GUI.DragWindow();
    }

    public void InitConversation ()
    {
        if (Selection.activeGameObject == null)
        {
            return;
        }

        lastSelected = Selection.activeGameObject;
        npcText = Selection.activeGameObject.GetComponentInChildren<NpcText>();

        if (npcText == null)
            return;

        if (npcText.conversation != null)
        {
            NodeDict.Clear();
            nodeWindows.Clear();

            foreach (Node node in npcText.conversation.nodes)
            {
                if (NodeDict.ContainsKey(node.id))
                {
                    NodeDict[node.id] = node;
                }
                else
                {
                    NodeDict.Add(node.id, node);
                }

                if (!nodeWindows.ContainsKey(node.id))
                {
                    nodeWindows.Add(node.id, new Rect(node.x, node.y, node.width, node.height));
                }
 
            }
        }
        else
        {
            npcText.conversation = ScriptableObject.CreateInstance<Conversation>();
            AssetDatabase.CreateAsset(npcText.conversation, AssetDatabase.GenerateUniqueAssetPath("Assets/" + npcText.name + ".asset"));
            AssetDatabase.SaveAssets();
        }
    }

    void OnSelectionChange ()
    {
        if (lastSelected != Selection.activeGameObject)
        {
            InitConversation();
            Repaint();
        }
    }


}