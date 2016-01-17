using UnityEngine;
using System.Collections;

public class UIManager : MonoBehaviour {

    GameObject UiRoot;

    [HideInInspector]
    public bool MenuOpen;

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

        ActiveMenu = defaultMenu;
    }
	
	void LateUpdate () {
        if (Input.GetButtonUp("Submit"))
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
                output = "Menu Opened";
            }
            else
            {
                _ActiveMenu.gameObject.SetActive(false);
                output = "Menu Closed";
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
