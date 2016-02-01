using UnityEngine;
using System.Collections;

public class PlayerAttacking : MonoBehaviour {
    UIManager UI;
    Inventory inventory;

    public int fire1;
    public int fire2;
    public GameObject item1;
    public Object item1Script;
    public GameObject item2;
    public Object item2Script;
    private Pause pauseScript;

	// Use this for initialization
	void Start () {
        UI = GameObject.FindGameObjectWithTag("GameManager").GetComponent<UIManager>();
        pauseScript = FindObjectOfType<Pause>();

        inventory = gameObject.GetComponent<Inventory>();
        fire1 = 0;
        fire2 = 0;
	
	}

    // Update is called once per frame
    void Update()
    {
        if(pauseScript.paused)
        {
            return;
        }

        if (UI.MenuOpen == false)
        {
            if (Input.GetButtonUp("Fire1"))
            {
                //inventory.useItem(fire1);
                if (item1)
                {
                    item1Script.GetType().GetMethod("Use").Invoke(item1Script, null);
                }
            }
            if (Input.GetButtonDown("Fire2"))
            {
                //inventory.useItem(fire2);
                if(item2)
                {
                    item2Script.GetType().GetMethod("Use").Invoke(item2Script, null);
                }
            }
        }
    }
}
