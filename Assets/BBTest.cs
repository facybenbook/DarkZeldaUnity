using UnityEngine;
using System.Collections;

public class BBTest : MonoBehaviour {

    BlackBoard bb;
	// Use this for initialization
	void Start () {
        bb = new BlackBoard();

        bb.Set<int>("testInt", 123);
        bb.Set<Vector2>("TestVector2", new Vector2());

        print(bb.Get<int>("testInt"));
        print(bb.Get<Vector2>("TestVector2"));

    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
