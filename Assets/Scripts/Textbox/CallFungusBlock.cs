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
    private GameObject player;
    private CircleCollider2D col;

    // Use this for initialization
    void Start()
    {
        pauseScript = FindObjectOfType<Pause>();
        textbox = GameObject.FindGameObjectWithTag("Textbox");
        player = GameObject.FindGameObjectWithTag("Player");
        col = GetComponent<CircleCollider2D>();
        

    }

    // Update is called once per frame
    void Update()
    {
        if(player != null && Vector2.Distance(player.transform.position,transform.position) < col.radius)
        {
            if (textbox != null)
            {
                textboxActive = textbox.activeInHierarchy;
            }
            if ((textbox == null || !textboxActive) && Input.GetButtonDown("Interact") && pauseScript.paused == false)
            {
                flowchart.ExecuteBlock(blockToCall);
                pauseScript.PauseGame(true);
            }
        }
    }

}
