using UnityEngine;
using System.Collections;

using BehaviorLibrary;
using BehaviorLibrary.Components.Actions;
using BehaviorLibrary.Components.Conditionals;
using BehaviorLibrary.Components.Composites;
using BehaviorLibrary.Components.Decorators;

public class PlayerGhostBehaviour : MonoBehaviour {

    GameObject player;
    public float speed;
    public GameObject target;
    public Vector2 targetPos;

    BehaviorLibrary.Behavior behaviour;

	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");

        Sequence stayCloseToPlayer = new Sequence(
            new BehaviorLibrary.Components.BehaviorComponent[]
            {
                new Inverter(new Conditional(isCloseToPlayer)),
                new BehaviorAction(moveToPlayer)

            });

        Sequence WanderAroundPlayer = new Sequence
            (
            new Selector 
                (
                new Sequence(
                    new Conditional(isAtTargetPos),
                    new BehaviorAction(SetRandomPosAroundPlayer)),
                new BehaviorAction(moveToTargetPos)
                )
            );

        Selector moveAndWander = new Selector(
            new BehaviorLibrary.Components.BehaviorComponent[]
            {
                stayCloseToPlayer,
                WanderAroundPlayer
            });

        behaviour = new BehaviorLibrary.Behavior(WanderAroundPlayer);
        behaviour.Behave();
	
	}
	
	// Update is called once per frame
	void Update () {

            behaviour.Behave();
	}

    bool isCloseToPlayer ()
    {
        if (Vector3.Distance(gameObject.transform.position, player.transform.position) < 2)
        {
            return true;
        }
        return false;
    }

    BehaviorReturnCode moveToPlayer ()
    {
        if (!isCloseToPlayer())
        {
            gameObject.transform.position = Vector3.Lerp(gameObject.transform.position, player.transform.position, speed * Time.deltaTime);
            return BehaviorReturnCode.Running;
        }
        return BehaviorReturnCode.Success;
        

    }

    BehaviorReturnCode moveToTargetPos ()
    {
        if (!isAtTargetPos())
        {
            gameObject.transform.position = Vector3.Lerp(gameObject.transform.position, targetPos, speed * Time.deltaTime);
            return BehaviorReturnCode.Running;
        }
        return BehaviorReturnCode.Success;
    }

    BehaviorReturnCode SetRandomPosAroundPlayer ()
    {
        targetPos = Random.insideUnitSphere + player.transform.position;
        return BehaviorReturnCode.Success;
    }

    bool isAtTargetPos ()
    {
        if (Vector3.Distance(gameObject.transform.position, targetPos) < 0.1)
        {
            return true;
        }
        return false;
    }
}
