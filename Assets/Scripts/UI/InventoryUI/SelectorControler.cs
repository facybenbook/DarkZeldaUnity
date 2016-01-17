using UnityEngine;
using System.Collections;

public class SelectorControler : MonoBehaviour {

    GameObject ItemsPanel;
    RectTransform rectTransform;
    int cIndex = 0;
    PlayerAttacking playerAttack;

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
        if (Input.GetButtonDown("Horizontal") || Input.GetButtonDown("Vertical"))
        {
            int nindex = cIndex + Mathf.RoundToInt(Input.GetAxisRaw("Horizontal"));
            nindex += Mathf.RoundToInt(-Input.GetAxisRaw("Vertical")) * 4;
      
            if (nindex < transform.parent.childCount - 1 && nindex >= 0)
            {
                cIndex = nindex;
                setPosition(cIndex);
            }
        }

        if(Input.GetButtonDown("Fire1"))
        {
            playerAttack.fire1 = cIndex;
        }
        if (Input.GetButtonDown("Fire2"))
        {
            playerAttack.fire2 = cIndex;
        }
    }
}
