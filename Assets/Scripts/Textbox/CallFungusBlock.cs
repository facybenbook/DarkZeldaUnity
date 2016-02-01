using UnityEngine;
using System.Collections;
using Fungus;

public class CallFungusBlock : MonoBehaviour
{

    public Flowchart flowchart;
    public string blockToCall;
    private GameObject textbox;
    private bool textboxActive;
    private float timer = 0.1f;
    private bool buttonPressed;
    private Pause pauseScript;

    // Use this for initialization
    void Start()
    {
        pauseScript = FindObjectOfType<Pause>();
        textbox = GameObject.FindGameObjectWithTag("Textbox");
        

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            if (textbox != null)
            {
                textboxActive = textbox.activeInHierarchy;
            }

            if ((textbox == null || !textboxActive) && Input.GetButtonDown("Interact"))
            {
                //flowchart.ExecuteBlock(blockToCall);
                buttonPressed = true;
            }
            if((textbox == null || !textboxActive) && buttonPressed)
            {
                timer -= Time.deltaTime;
            }
            if(timer < 0)
            {
                timer = 0.1f;
                flowchart.ExecuteBlock(blockToCall);
                buttonPressed = false;
                pauseScript.PauseGame(true);
                
            }

        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        textboxActive = textbox.activeInHierarchy;
        if (other.tag == "Player")
        {
            if(textboxActive)
            {


            }
        }
    }
}
