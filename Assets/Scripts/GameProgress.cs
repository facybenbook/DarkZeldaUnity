using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameProgress : MonoBehaviour
{
    public List<string> currentEvents;
    public List<string> completedEvents;

    public void StartEvent(string eventName)
    {
        if(!eventExists(eventName))
        {
            currentEvents.Add(eventName);
            print("EVENT : '" + eventName + "' Started");
        }
        else
        {
            print("ERROR : '" + eventName + "' is already exists.");
        }
    }
    public void EndEvent(string eventName)
    {
        if (currentEvents.Contains(eventName))
        {
            currentEvents.Remove(eventName);
            completedEvents.Add(eventName);
            print("EVENT : '" + eventName + "' Complete");
        }
        else
        {
            print("ERROR : no event named '" + eventName + "' currently active.");
        }
    }

    public bool eventExists (string eventName)
    {
        if(currentEvents.Contains(eventName) || completedEvents.Contains(eventName))
        {
            return true;
        }
        return false;
    }

    void Start()
    {
        //string name = "Game Start";

        //if (!eventExists(name))
        //{
        //    StartEvent(name);
        //}

        //if(currentEvents.Contains(name))
        //{
        //    EndEvent(name);
        //}

        //if (completedEvents.Contains(name))
        //{
        //    print("yay.");
        //}

    }
}