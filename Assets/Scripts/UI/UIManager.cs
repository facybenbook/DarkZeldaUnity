using UnityEngine;
using System.Collections;

public class UIManager : MonoBehaviour {

    GameObject UiRoot;

    [HideInInspector]
    public bool MenuOpen;

    Pause pauseScript;
    GameObject textbox;
    

    Transform _ActiveMenu;
    public string ActiveMenu
    {
        get
        {
            if (_ActiveMenu == null)
            {
                return "";
            }
            else
            {
                return _ActiveMenu.name;
            }
        }

        set
        {
            _ActiveMenu = UiRoot.transform.FindChild(value);
        }
    }

    public string defaultMenu;

    void Start ()
    {
        UiRoot = GameObject.Find("Canvas");
        DontDestroyOnLoad(UiRoot);
        pauseScript = FindObjectOfType<Pause>();
        textbox = GameObject.FindGameObjectWithTag("Textbox");

        ActiveMenu = defaultMenu;
    }
	
	void LateUpdate () {
        if (Input.GetButtonUp("Submit") && !textbox.activeInHierarchy)
        {
            MenuOpen = !MenuOpen;

            if (ActiveMenu == UiRoot.name)
            {
                return;
            }

            string output;
            if (MenuOpen)
            {

                _ActiveMenu.gameObject.SetActive(true);
                output = " Menu Opened";
                pauseScript.PauseGame(true);
            }
            else
            {
                _ActiveMenu.gameObject.SetActive(false);
                output = " Menu Closed";
                pauseScript.PauseGame(false);
            }
            print(ActiveMenu + output);
        }
	}

    public void ChangeMenus (string menuName)
    {
        if (MenuOpen && menuName != ActiveMenu)
        {
            
                _ActiveMenu.gameObject.SetActive(false);
                ActiveMenu = menuName;
                _ActiveMenu.gameObject.SetActive(true);
        }
    }
}
