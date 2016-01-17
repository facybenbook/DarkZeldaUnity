using UnityEngine;
using System.Collections;

public class Item : ScriptableObject {

	public virtual void Use()
    {
        Debug.Log("Base Item Called.");
    }
}
