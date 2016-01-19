using UnityEngine;
using System.Collections;

public class HealthController : MonoBehaviour {

    public int Hp;
    public int MaxHp;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
        if(Hp <= 0)
        {
            Destroy(gameObject);
        }

	}

    public void ChangeHealth(int healthToChange)
    {
        Hp += healthToChange;
    }
}
