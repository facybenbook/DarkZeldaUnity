using UnityEngine;
using System.Collections;
using System.Collections.Generic;

using MonsterLove.StateMachine;

public class GhostBehviour : StateBehaviour {

    public float speed;
    public Transform target;


    public enum States
    {
        FollowPlayer,
        FloatAroundObject,
    }

	// Use this for initialization
	void Start () {
        Initialize<States>();
        ChangeState(States.FollowPlayer);
	
	}

    void FollowPlayer_Enter ()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void FollowPlayer_FixedUpdate ()
    {
        if(Vector3.Distance(gameObject.transform.position, target.position) > 1) {
            gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, target.position, speed);
            //Move
        }
        else {
            //stay
        }
    }

    void FollowPlayer_End ()
    {
        target = null;
    }

    void FloatAroundObject_Enter ()
    {

    }

    void FloatAroundObject_FixedUpdate()
    {
        if( Vector3.Distance(this.transform.position, target.transform.position) > 1)
        {
            //move to target
            gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, target.position, speed);
        }
        else
        {
            //float around the target.
        }
    }

}
