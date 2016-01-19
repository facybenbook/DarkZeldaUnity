using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

public class TextboxManager : MonoBehaviour
{
    public GameObject textBox;
    public Text text;
    public float writeSpeed;
    public float holdSpeed;
    public TextAsset textFile;

    private string[] textLines;
    private int currentLine;
    private int endAtLine;
    private int curPos;
    private bool isActive;
    private float pauseTimer;
    private bool paused;
    private Dictionary<string, float> pauseLengths = new Dictionary<string, float>();
    private Image textboxBG;


    // Use this for initialization
    void Start()
    {
        textboxBG = textBox.GetComponent<Image>();

        pauseLengths.Add(".", 1f);
        pauseLengths.Add(",", 1f);
        pauseLengths.Add("!", 1f);
        pauseLengths.Add("?", 1f);
        pauseLengths.Add("\n", 2f);


    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Submit")&&!isActive)
        {
            ShowTextBox(textFile.text, true, false);
        }



        if (isActive)
        {
            if (Input.GetButtonDown("Submit"))
            {
                if (curPos >= textLines[currentLine].Length - 1)
                {
                    pauseTimer = 2f;
                    currentLine++;
                    curPos = 0;

                    if (currentLine > endAtLine)
                    {
                        HideTextBox();
                    }
                    else
                    {
                        DisplayText();
                    }
                }
            }
            if (Input.GetButton("Submit") && curPos > 1)
            {
                pauseTimer -= Time.deltaTime * holdSpeed;
            }


            if (pauseTimer > 0)
            {
                pauseTimer -= Time.deltaTime * writeSpeed;
            }
            else
            {

                if (curPos < textLines[currentLine].Length)
                {
                    curPos++;
                    paused = false;
                    pauseTimer = 0.1f;
                }

                if (pauseLengths.ContainsKey(textLines[currentLine].ToCharArray()[curPos - 1].ToString()) && curPos > 1 && !paused)
                {
                    pauseTimer = pauseLengths[textLines[currentLine].ToCharArray()[curPos - 1].ToString()];
                    paused = true;
                }


                DisplayText();
            }

        }

    }

    public void ShowTextBox(string textToShow, bool showBG, bool centerText)
    {
        pauseTimer = 2f;
        textBox.SetActive(true);
        textLines = textToShow.Split(new string[] { "~" }, System.StringSplitOptions.RemoveEmptyEntries);
        endAtLine = textLines.Length - 1;

        DisplayText();

        isActive = true;
        if (showBG)
        {
            textboxBG.enabled = true;
        }
        else
        {
            textboxBG.enabled = false;
        }
        if (centerText)
        {
            text.alignment = TextAnchor.MiddleCenter;

        }
        else
        {
            text.alignment = TextAnchor.UpperLeft;
        }

    }

    public void HideTextBox()
    {
        currentLine = 0;
        textBox.SetActive(false);
        isActive = false;
    }

    void DisplayText()
    {
        text.text = textLines[currentLine].Substring(0, Mathf.Clamp(curPos, 0, textLines[currentLine].Length));
    }

}

