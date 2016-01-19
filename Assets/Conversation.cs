using UnityEngine;
using System.Collections.Generic;
using System.Reflection;

[CreateAssetMenu]
public class Conversation : ScriptableObject {

    public static GameProgress progress;

    public string[] currentConditions;
    public string[] completedConditions;
    public string[] actions;


    void OnEnable()
    {
        progress = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameProgress>();
        //functions = GameObject.FindGameObjectWithTag("GameManager").GetComponent<ScriptableFunctionsManager>();

    }

    bool evalConditions ()
    {
        foreach (string condition in currentConditions)
        {
            if (condition.StartsWith("!"))
            {
                if (progress.currentEvents.Contains(condition)) {
                    return false;
                }
            }
            else
            {
                if (!progress.currentEvents.Contains(condition))
                {
                    return false;
                }
            }
        }

        foreach (string condition in completedConditions)
        {
            if (condition.StartsWith("!"))
            {
                if (progress.completedEvents.Contains(condition)) {
                    return false;
                }
            }
            else
            {
                if (!progress.completedEvents.Contains(condition))
                {
                    return false;
                }
            }
        }
        return true;
    }
    public void runActions()
    {
        foreach(string action in actions)
        {
            switch (action)
            {
                case "ShowTextBox":
                    //functions.showTextBox("sometext", true, false);
                    break;
                case "This would get super tedious..":
                    break;
            }
        }
    }
}