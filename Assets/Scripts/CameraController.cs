using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

    public Transform camTarget;
    public float targetSize;
    public float moveSpd;
    public float zoomSpd;

    private static bool cameraExists;
    public Vector3 targetPos;
    private Camera cam;

    public float horExtent;                                // 1/2 the horizontal size of the camera.
    public float verExtent;                                // 1/2 the vertical size of the camera.

    public float minX;
    public float maxX;
    public float minY;
    public float maxY;

    // Use this for initialization
    void Start () {

        DontDestroyOnLoad(transform.gameObject);

        if (!cameraExists)
        {
            cameraExists = true;
            DontDestroyOnLoad(transform.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        cam = GetComponent<Camera>();

        verExtent = cam.orthographicSize;
        horExtent = verExtent * Screen.width / Screen.height;

    }
	
	// Update is called once per frame
	void LateUpdate () {

        if(cam.orthographicSize != targetSize)
        {
            cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, targetSize, zoomSpd*Time.deltaTime);

            verExtent = cam.orthographicSize;
            horExtent = verExtent * Screen.width / Screen.height;
        }

        targetPos = new Vector3(camTarget.transform.position.x, camTarget.transform.position.y, -10);
        targetPos.x = Mathf.Clamp(targetPos.x, minX+horExtent, maxX-horExtent);
        targetPos.y = Mathf.Clamp(targetPos.y, minY+verExtent, maxY-verExtent);

        transform.position = Vector3.Lerp(transform.position, targetPos, moveSpd * Time.deltaTime);

    }

    public void SetMinMax(float miX,float maX,float miY,float maY)
    {
        minX = miX;
        maxX = maX;
        minY = miY;
        maxY = maY;
    }
    public void SetBaseOrthoSize(float size)
    {
        targetSize = size;
    }
}
