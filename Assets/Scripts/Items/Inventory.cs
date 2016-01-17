using UnityEngine;
using System.Collections.Generic;

public class Inventory : MonoBehaviour {

    public List<Item> items;

	// Use this for initialization
	void Start () {
        items = new List<Item>();
        items.Add(ScriptableObject.CreateInstance("Sword") as Item);
	}

    public void useItem(int index)
    {
        items[index].GetType().GetMethod("Use").Invoke(items[index], null);
    }
}
