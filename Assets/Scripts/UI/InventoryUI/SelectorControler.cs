using UnityEngine;
using System.Collections;

public class SelectorControler : MonoBehaviour {

    GameObject ItemsPanel;
    RectTransform rectTransform;
    int cIndex = 0;
    PlayerAttacking playerAttack;
    bool movedMenuPos;

    Inventory inv;

	// Use this for initialization
	void Start () {

        inv = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
        playerAttack = inv.GetComponent<PlayerAttacking>();

        rectTransform = (RectTransform)transform;

        setPosition(cIndex);
    }

    public void setPosition(int index)
    {
        RectTransform next = (RectTransform)transform.parent.GetChild(index);
        rectTransform.anchorMax = next.anchorMax;
        rectTransform.anchorMin = next.anchorMin;
        rectTransform.anchoredPosition = next.anchoredPosition;
    }

    void Update ()
    {
        if(Input.GetAxisRaw("Horizontal") == 0 && Input.GetAxisRaw("Vertical") == 0)
        {
            movedMenuPos = false;
        }

        if ((Mathf.RoundToInt(Input.GetAxisRaw("Horizontal")) != 0 || Mathf.RoundToInt(Input.GetAxisRaw("Vertical")) != 0) && !movedMenuPos)
        {
            int nindex = cIndex + Mathf.RoundToInt(Input.GetAxisRaw("Horizontal"));
            nindex += Mathf.RoundToInt(-Input.GetAxisRaw("Vertical")) * 4;
      
            if (nindex < transform.parent.childCount - 1 && nindex >= 0)
            {
                cIndex = nindex;
                setPosition(cIndex);
            }
            movedMenuPos = true;
        }
        if(Input.GetButtonDown("Fire1"))
        {
            if (cIndex <= inv.items.Count - 1)
            {
                playerAttack.fire1 = cIndex;
                Destroy(playerAttack.item1);
                playerAttack.item1 = inv.CreateItem(inv.items[cIndex]);
                playerAttack.item1Script = playerAttack.item1.GetComponent<ItemScript>();
                print("item 1 changed.");
            }
        }
        if (Input.GetButtonDown("Fire2"))
        {
            if (cIndex <= inv.items.Count - 1)
            {
                playerAttack.fire2 = cIndex;
                Destroy(playerAttack.item2);
                playerAttack.item2 = inv.CreateItem(inv.items[cIndex]);
                playerAttack.item2Script = playerAttack.item2.GetComponent<ItemScript>();
                print("item 2 changed.");
            }
        }
    }
}
