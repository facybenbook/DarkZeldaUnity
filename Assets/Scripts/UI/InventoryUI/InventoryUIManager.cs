using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class InventoryUIManager : MonoBehaviour
{

    bool initalized;

    UIManager UI;
    Inventory inventory;
    Transform itemsPanel;

    void Update ()
    {
        if (UI.ActiveMenu != "InventoryUI")
        {
            this.enabled = false;
            return;
        }
    }

    void OnEnable()
    {
        if(initalized == false)
        {
            UI = GameObject.FindGameObjectWithTag("GameManager").GetComponent<UIManager>();
            inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
            itemsPanel = gameObject.transform.FindChild("ItemsPanel");
            initalized = true;
        }

        if (UI.ActiveMenu != "InventoryUI")
        {
            this.enabled = false;
            return;
        }

        for (int i = 0; i < itemsPanel.childCount - 2; i++)
        {
            if (i <= inventory.items.Count - 1)
            {
                GameObject inventorySlot = itemsPanel.GetChild(i).gameObject;
                Sprite icon = inventory.items[i].uiTexture;
                inventorySlot.GetComponent<Image>().overrideSprite = icon;
            }
            break;
        }
    }
}