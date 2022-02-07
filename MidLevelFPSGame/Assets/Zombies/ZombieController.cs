using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

/*                  FINITE STATE MACHINE(FSM)
 *                  
 * It is an artificial intelligence system for storing state data and transition between them.
 * Eg: Animation System
 * 
 * A FSM that defines all the states they can be in and how they can get from one state to another state.
 * 
 *1.Determine the states of the character
 *  In zombie character, we determined five states: a)Idle b)Wander c)Chase d)Attack e)Death
 *  
 */

public class ZombieController : MonoBehaviour
{
    Animator anim;
    public GameObject targetPlayer;
    NavMeshAgent enemyAgent;

    enum STATE { IDLE, WANDER, CHASE, ATTACK, DEATH }
    STATE state = STATE.IDLE;


    void Start()
    {
        anim = this.GetComponent<Animator>();
        enemyAgent = GetComponent<NavMeshAgent>();

        //anim.SetBool("isWalking", true);
    }

    void TurnOffAnimTriggers()
    {
        anim.SetBool("isWalking", false);
        anim.SetBool("isAttacking", false);
        anim.SetBool("isRunning", false);
        anim.SetBool("isDead", false);
    }

    void Update()
    {
        switch (state)
        {
            case STATE.IDLE:
                break;
            case STATE.WANDER:
                break;
            case STATE.CHASE:
                break;
            case STATE.ATTACK:
                break;
            case STATE.DEATH:
                break;
            default:
                break;
        }
    }





    //void Update()
    //{
    //    //if (Input.GetKey(KeyCode.W))
    //    //{
    //    //    anim.SetBool("isWalking", true);
    //    //}
    //    //else
    //    //    anim.SetBool("isWalking", false);

    //    //if (Input.GetKey(KeyCode.R))
    //    //{
    //    //    anim.SetBool("isRunning", true);
    //    //}
    //    //else
    //    //    anim.SetBool("isRunning", false);

    //    //if (Input.GetKey(KeyCode.A))
    //    //{
    //    //    anim.SetBool("isAttacking", true);
    //    //}
    //    //else
    //    //    anim.SetBool("isAttacking", false);

    //    //if (Input.GetKey(KeyCode.D))
    //    //{
    //    //    anim.SetBool("isDead", true);
    //    //}
    //    enemyAgent.SetDestination(targetPlayer.transform.position);

    //    if(enemyAgent.remainingDistance > enemyAgent.stoppingDistance)
    //    {
    //        anim.SetBool("isWalking", true);
    //        anim.SetBool("isAttacking", false);
    //    }
    //    else
    //    {
    //        anim.SetBool("isWalking", false);
    //        anim.SetBool("isAttacking", true);
    //    }
    //}
}
