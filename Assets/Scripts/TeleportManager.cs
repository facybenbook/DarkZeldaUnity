using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class TeleportManager : MonoBehaviour {

    PlayerInfo player;
    GameObject[] teleporters;
    public TeleportInfo lastTeleporter;
    public Dictionary<string, GameObject[]> Teleporters = new Dictionary<string, GameObject[]>();

    void GetTeleporters ()
    {
        Teleporters.Clear();

        GameObject[] x = GameObject.FindGameObjectsWithTag("Teleport");

        foreach(GameObject tp in x)
        {
            TeleportInfo info = tp.GetComponent<Teleport>().info;

            if (Teleporters.ContainsKey(info.id))
            {
                Teleporters[info.id][1] = tp;
            }
            else
            {
                Teleporters[info.id] = new GameObject[2];
                Teleporters[info.id][0] = tp;
            }
        }
    }

    void Start ()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInfo>();

        //// OnLevelWasLoaded isnt called for the first scene for some reason.. so we need to get the list of teleporters when this manager is created.
        //teleporters = GameObject.FindGameObjectsWithTag("Teleport");
        GetTeleporters();
    }

    void OnLevelWasLoaded(int lvl)
    {

        //teleporters = GameObject.FindGameObjectsWithTag("Teleport");
        GetTeleporters();

        if (lastTeleporter != null)
            Teleport();
    }

    public void Teleport()
    {
        // instead of a for each loop we could put all of the teleporters in a dictionary maped to there Id but that wouldnt work 
        // for teleporting in the same scene because all the keys need to be unique. maybe a dictionary with lists of teleporters that are looped through.
        foreach (GameObject go in Teleporters[lastTeleporter.id])

        {

            Teleport tp = go.GetComponent<Teleport>();

            if (tp.info.id == lastTeleporter.id && tp.info != lastTeleporter)
            {
                lastTeleporter = null;
                // facing is a string containing a direction that the animation should be... not used currently just set.
                player.facing = tp.info.facing;

                //if the player is on the teleport zone it will call OnEnterTrigger2D and be stuck in an endless loop.
                //so we move it over depending on the teleporters facing string.
                Vector3 facing = new Vector3(0f, 0f, 0f);

                switch (tp.info.facing.ToLower())
                {
                    case "up":
                        facing.y = 1.1f;
                        break;
                    case "down":
                        facing.y = -1.1f;
                        break;
                    case "left":
                        facing.x = -1.1f;
                        break;
                    case "right":
                        facing.x = 1.1f;
                        break;
                    default:
                        print("Unknown Facing: " + tp.info.facing.ToLower());
                        break;
                }

                player.transform.position = go.transform.position + facing;

                //Once we find the teleporter we were looking for, and after we move the player we break out of the foreach loop
                //so were not needlessly looping though the rest of the teleporters in that Scene.
                break;
            }
        }
    }
}
