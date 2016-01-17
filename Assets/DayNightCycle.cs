using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DayNightCycle : MonoBehaviour {

    public float timeOfDay;                                                     //cur time of day 0-100
    public bool isDay;                                                          //should timeOfDay count up or down
    public float pauseTime;                                                     //time it waits at noon and midnight (0 & 100)
    public float timeSpd;                                                       //speed time moves at


    private float waitTimer;



	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        if(isDay && waitTimer <= 0 && timeOfDay <= 100)
        {
            timeOfDay += Time.deltaTime * timeSpd;
        } 
        else if (!isDay && waitTimer <= 0 && timeOfDay >= 0)
        {
            timeOfDay -= Time.deltaTime * timeSpd;
        }


        if(isDay && timeOfDay >= 100 && waitTimer <= 0)
        {
            waitTimer = pauseTime;
            isDay = !isDay;
        }
        else if(!isDay && timeOfDay <= 0 && waitTimer <= 0)
        {
            waitTimer = pauseTime;
            isDay = !isDay;
        }

        if(waitTimer > 0)
        {
            waitTimer -= Time.deltaTime;
        } else
        {
            waitTimer = 0f;
        }
    }

}
