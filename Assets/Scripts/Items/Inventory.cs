using UnityEngine;
using System.Collections.Generic;

public class Inventory : MonoBehaviour {

    public List<Item> items;
    public PlayerAttacking playerAttacking;

	// Use this for initialization
	void Start () {
        // this Hard codes an item in to the first slot.
        playerAttacking = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerAttacking>();
        playerAttacking.item1 = CreateItem(items[0]);
        playerAttacking.item1Script = playerAttacking.item1.GetComponent<ItemScript>();
	}

    public GameObject CreateItem (Item itemAsset)
    {
        GameObject item = Instantiate(itemAsset.itemPrefab, transform.position, Quaternion.identity) as GameObject;
        item.transform.SetParent(transform);
        return item;
    }
}
