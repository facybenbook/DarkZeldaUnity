using UnityEngine;
using System.Collections.Generic;

public class BlackBoard {

    Dictionary<string, object> _data;

    public BlackBoard ()
    {
        _data = new Dictionary<string, object>();
    }

    public T Get<T> (string name)
    {
        return (T)_data[name];
    }

    public void Set<T> (string name, T value)
    {
        if (_data.ContainsKey(name))
        {
            _data[name] = value;
        }
        else
        {
            _data.Add(name, value);
        }
        
    }

    public bool Contains (string name)
    {
        return _data.ContainsKey(name);
    }

    public void Remove (string name)
    {
        if (_data.ContainsKey(name))
        {
            _data.Remove(name);
        }
    }

}
