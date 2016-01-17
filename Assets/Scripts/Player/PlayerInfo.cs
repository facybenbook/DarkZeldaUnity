using UnityEngine;
using System.Collections;

public class PlayerInfo : MonoBehaviour {

    [HideInInspector]
    public string facing;

    static bool Exists;


    void Start ()
    {
        if(!Exists)
        {
            DontDestroyOnLoad(gameObject);
            Exists = true;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}