using UnityEngine;
using System.Collections;

public class PlayerAttacking : MonoBehaviour {

    Inventory inventory;

    public int fire1;
    public int fire2;

	// Use this for initialization
	void Start () {
        inventory = gameObject.GetComponent<Inventory>();
        fire1 = 0;
        fire2 = 0;
	
	}

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            inventory.useItem(fire1);
        }
        if (Input.GetButtonDown("Fire2"))
        {
            inventory.useItem(fire2);
        }

    }
}
