using UnityEngine;
using UnityEditor;
using System.Collections.Generic;

public class MyNodeEditor : EditorWindow {

    private Dictionary<int, Node> nodes = new Dictionary<int, Node>();
    private static EditorWindow editor;
    List<int> Linked = new List<int>();

    [MenuItem("Custom Editors/Mikes Editor")]
    static void ShowEditor()
    {
        editor = GetWindow<MyNodeEditor>();
    }

    void OnGUI()
    {
        if (GUILayout.Button("Create Node"))
        {
            Node node = new Node(new Rect (0,0,400,200));
            nodes.Add(node.id, node);
        }
        if (GUILayout.Button("Import"))
        {

        }
        if (GUILayout.Button("Export"))
        {

        }
        foreach(Node node in nodes.Values)
        {
            foreach(int id in node.children)
            {
                DrawNodeCurve(node.rect, nodes[id].rect);
            }
        }

        BeginWindows();
        foreach (Node node in nodes.Values)
        {
            nodes[node.id].rect = GUI.Window(node.id, node.rect, OnNode, node.id.ToString());
        }
        EndWindows();
    }

    void OnNode (int id)
    {
        if (GUILayout.Button("Remove Node"))
        {
            nodes.Remove(id);
        }

        if (GUILayout.Button("Link"))
        {
            Linked.Add(id);
            if(Linked.Count == 2)
            {
                nodes[Linked[0]].children.Add(Linked[1]);
                Linked.Clear();
            }
        }
        GUI.DragWindow();
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
}
