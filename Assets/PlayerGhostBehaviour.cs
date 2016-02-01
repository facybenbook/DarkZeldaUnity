using UnityEngine;
using System.Collections;

using BehaviorLibrary;
using BehaviorLibrary.Components.Actions;
using BehaviorLibrary.Components.Conditionals;
using BehaviorLibrary.Components.Composites;
using BehaviorLibrary.Components.Decorators;

public class PlayerGhostBehaviour : MonoBehaviour {

    public float speed;

    public BlackBoard Memory;
    BehaviorLibrary.Behavior behaviour;

	// Use this for initialization
	void Start () {
        Memory = new BlackBoard();

        Memory.Set<GameObject>("Player", GameObject.FindGameObjectWithTag("Player"));

        Conditional playerClose = new Conditional(isCloseToPlayer);
        Conditional playerMoving = new Conditional(isPlayerMoving);

        BehaviorAction MoveToPlayer = new BehaviorAction(moveToPlayer);
        BehaviorAction WanderAroundPlayer = new BehaviorAction(wanderAroundPlayer);

        Selector stayCloseToPlayer = new Selector(

            new Sequence(
                new Inverter(playerClose),
                playerMoving,
                MoveToPlayer                
                ),
            WanderAroundPlayer
            );

        behaviour = new BehaviorLibrary.Behavior(stayCloseToPlayer);
	
	}
	
	// Update is called once per frame
	void Update () {

            behaviour.Behave();
	}

    bool isCloseToPlayer ()
    {
        GameObject player = Memory.Get<GameObject>("Player");

        if (Vector3.Distance(gameObject.transform.position, player.transform.position) < 2)
        {
            return true;
        }
        return false;
    }

    bool isPlayerMoving ()
    {
        GameObject player = Memory.Get<GameObject>("Player");

        return player.GetComponent<Rigidbody2D>().velocity != Vector2.zero;
    }

    BehaviorReturnCode moveToPlayer ()
    {
        GameObject player = Memory.Get<GameObject>("Player");

        gameObject.transform.position = Vector3.Lerp(gameObject.transform.position, player.transform.position, speed * Time.deltaTime);
        return BehaviorReturnCode.Success;
        

    }

    BehaviorReturnCode wanderAroundPlayer ()
    {
        Vector2 targetPos;
        Vector3 playerPos = Memory.Get<GameObject>("Player").transform.position;

        if (Memory.Contains("targetPos"))
        {
            targetPos = Memory.Get<Vector2>("targetPos");
        }
        else
        {
            targetPos = Random.insideUnitSphere;

            Memory.Set<Vector2>("targetPos", targetPos);
        }


        if (!isAtTargetPos())
        {
            gameObject.transform.position = Vector3.Lerp(gameObject.transform.position, targetPos + new Vector2(playerPos.x, playerPos.y), speed * Time.deltaTime);
            return BehaviorReturnCode.Running;
        }
        else
        {
            Memory.Remove("targetPos");
            return BehaviorReturnCode.Success;
        }
    }

    bool isAtTargetPos ()
    {
        Vector2 targetPos = Memory.Get<Vector2>("targetPos");
        Vector3 playerPos = Memory.Get<GameObject>("Player").transform.position;

        if (Vector3.Distance(gameObject.transform.position, targetPos + new Vector2(playerPos.x, playerPos.y)) < 0.1)
        {
            return true;
        }
        return false;
    }

}
