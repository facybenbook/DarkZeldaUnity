using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Teleport : MonoBehaviour {

    public string TeleportID;
    public string SceneName;
    public string facing;

    static TeleportManager manager;

    public TeleportInfo info;

    void Awake()
    {
        info = new TeleportInfo(TeleportID, SceneName, facing);
    }

	void Start () {
        //theres olny one Gamemanager Obj during the lifetime of the game so we olny need to find the manager component once and we store it in a static variable(Class Variable).
        if(manager == null)
        {
            manager = GameObject.Find("GameManager").GetComponent<TeleportManager>();
        }
	}

    void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "Player")
        {
            manager.lastTeleporter = info;

            if (SceneManager.GetActiveScene().name != info.SceneName)
            {
                SceneManager.LoadScene(info.SceneName);
            }
            else
            {
                manager.Teleport();
            }
        }
    }
}
