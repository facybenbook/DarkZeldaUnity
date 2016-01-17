using UnityEngine;
using System.Collections;

public class CameraZone : MonoBehaviour {

    public float camOrthoSize;

    private CameraController cam;

    private float minX;
    private float maxX;
    private float minY;
    private float maxY;

    private BoxCollider2D camZone;


	// Use this for initialization
	void Start () {
        cam = FindObjectOfType<CameraController>();

        camZone = GetComponent<BoxCollider2D>();

        minX = transform.position.x - (camZone.size.x / 2);
        maxX = transform.position.x + (camZone.size.x / 2);
        minY = transform.position.y - (camZone.size.y / 2);
        maxY = transform.position.y + (camZone.size.y / 2);

    }
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            cam.SetMinMax(minX,maxX,minY,maxY);
            cam.SetBaseOrthoSize(camOrthoSize);
        }
    }
}
