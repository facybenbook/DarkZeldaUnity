using UnityEngine;
using System.Collections;

public class SpinObject : MonoBehaviour {

    public float spinSpeed;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        gameObject.transform.Rotate(new Vector3(0f, 0f, spinSpeed * Time.deltaTime));
	
	}
}
