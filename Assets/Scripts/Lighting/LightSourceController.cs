using UnityEngine;
using System.Collections;

public class LightSourceController : MonoBehaviour {

    [HideInInspector]
    public Light lightInstance;
    [HideInInspector]
    public float lightStr;
    public bool isSun;

    private DayNightCycle DNC;


    // Use this for initialization
    void Start () {
        lightInstance = GetComponent<Light>();
        lightStr = lightInstance.intensity;
        DNC = FindObjectOfType<DayNightCycle>();
	
	}
	
	// Update is called once per frame
	void Update () {
        if(isSun)
        {
            lightInstance.intensity = (DNC.timeOfDay / 100) * lightStr;
        }
        else
        {
            lightInstance.intensity = ((100 - DNC.timeOfDay) / 100) * lightStr;
        }
	
	}
}
