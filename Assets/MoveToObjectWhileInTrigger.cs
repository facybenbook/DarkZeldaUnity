using UnityEngine;
using System.Collections;
using MonsterLove.StateMachine;

public class MoveToObjectWhileInTrigger : MonoBehaviour {

    Collider2D coll;
    GameObject ghost;
    GhostBehviour fsm;
    public Transform ghostTarget; 

	// Use this for initialization
	void Start () {

        coll = GetComponent<Collider2D>();
        ghost = GameObject.FindGameObjectWithTag("PlayerGhost");
        fsm = ghost.GetComponent<GhostBehviour>();
	}

    void OnTriggerEnter2D (Collider2D other) 
    {
        if (other.tag == "Player")
        {
            fsm.stateMachine.ChangeState(GhostBehviour.States.FloatAroundObject);
            fsm.target = ghostTarget;
        }
        
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            fsm.stateMachine.ChangeState(GhostBehviour.States.FollowPlayer);
        }
    }
}
