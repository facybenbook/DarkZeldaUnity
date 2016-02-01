using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public enum NpcAction
{
    None,
    StartEvent,
    EndEvent,
    RemoveEvent
}

[Serializable]
public class SerialDictionary : ScriptableObject
{
    [SerializeField]
    private List<string> keys;
    [SerializeField]
    private List<string> values;

    void OnEnable()
    {
        if (keys == null || values == null)
        {
            keys = new List<string>();
            values = new List<string>();
        }
    }

    public string Get(string key)
    {
        return values[keys.IndexOf(key)];
    }

    public void Set (string key, string newValue)
    {
        values[keys.IndexOf(key)] = newValue;
    }

    public bool Contains (string key)
    {
        if (keys.Contains(key)) {
            return true;
        }
        return false;
    }

    public void Add (string key , string value)
    {
        if (keys.Contains(key))
        {
            Set(key, value);
        }
        else
        {
            keys.Add(key);
            values.Add(value);
        }
    }

    public void Remove (string key)
    {
        if (keys.Contains(key))
        {
            values.RemoveAt(keys.IndexOf(key));
            keys.Remove(key);
        }
    }
}