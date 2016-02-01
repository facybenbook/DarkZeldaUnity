using UnityEngine;
using System.Collections;
using Fungus;

public class Pause : MonoBehaviour {

    public bool paused;
    public bool pauseGame;
    private GameObject textbox;
    private Flowchart flowchart;

	// Use this for initialization
	void Start () {
        flowchart = FindObjectOfType<Flowchart>();
        textbox = GameObject.FindGameObjectWithTag("Textbox");
	
	}
	
	// Update is called once per frame
	void Update () {
        if(pauseGame)
        {
            PauseGame();
            pauseGame = false;
        }

	}


    public void PauseGame()
    {
        paused = !paused;
        if(paused)
        {
            //Time.timeScale = 0f;
        }
        else
        {
            //Time.timeScale = 1f;
        }
    }

    public void PauseGame(bool flag)
    {
        if(flag)
        {
            paused = true;
            //Time.timeScale = 0f;
        }
        else
        {
            paused = false;
            if (!textbox.activeInHierarchy)
            {
                paused = false;
                //Time.timeScale = 1f;
            }
        }
    }
}
