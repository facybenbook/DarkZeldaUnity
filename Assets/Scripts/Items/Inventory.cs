using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;

public class Inventory : MonoBehaviour {

    public List<Item> items;

    public int fire1;
	// Use this for initialization
	void Start () {
        fire1 = 0;
        items = new List<Item>();
        items.Add(ScriptableObject.CreateInstance("Sword") as Item);
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Fire1"))
        {
            useItem(fire1);
        }
	
	}

    public void useItem(int index)
    {
        items[index].GetType().GetMethod("Use").Invoke(items[index], null);
    }
}
