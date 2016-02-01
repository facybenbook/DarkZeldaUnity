using UnityEngine;
using System.Collections;

public class CameraShake : MonoBehaviour {

    public float timer;
    public float intensity;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if(timer > 0)
        {
            timer -= Time.deltaTime;
            gameObject.transform.position += new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f),0f) * intensity;
        }
	
	}

    public void Shake(float time, float str)
    {
        timer = time;
        intensity = str;

    }
}
