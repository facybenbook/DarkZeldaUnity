using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerLocation : MonoBehaviour {

    public string playerLocation;
    public Text locationText;
    public float fadeSpd;
    private float timer;
    private Color newColor;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if(timer <= 0)
        {
            if (locationText.color.a > 0)
            {
                newColor = locationText.color;
                newColor.a = locationText.color.a - (Time.deltaTime * fadeSpd);
                locationText.color = newColor;
            }
        }
        else
        {
            timer -= Time.deltaTime;
        }
	
	}

    public void SetLocation(string location)
    {
        if(location != playerLocation)
        {
            ShowLocationText(location);
        }
        playerLocation = location;
    }

    public void ShowLocationText(string location)
    {
        timer = 2f;
        locationText.color = Color.white;
        Debug.Log(location);
        locationText.text = "- " + location + " -";
    }
}
