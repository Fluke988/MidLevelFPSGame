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

    bool ZombieCanSeePlayer()
    {
        //Logic for Zombie to see the player and chase
        //Need to calculate the distance between the zombie and the player
        if (DistanceToPlayer()<10.0f)
        {
            return true;
        }

        return false;
    }

    float DistanceToPlayer()
    {
        return Vector3.Distance(targetPlayer.transform.position, this.transform.position);
    }

    void Update()
    {
        switch (state)
        {
            case STATE.IDLE:
                if (ZombieCanSeePlayer())
                {
                    state = STATE.CHASE;
                }
                else
                {
                    state = STATE.WANDER;
                }
                break;

            case STATE.WANDER:
                if(!enemyAgent.hasPath)
                {
                    float newRandPosX = this.transform.position.x + Random.Range(-10, 10);
                    float newRandPosZ = this.transform.position.z + Random.Range(-10, 10);
                    float newRandPosY = Terrain.activeTerrain.SampleHeight(new Vector3(newRandPosX, 0, newRandPosZ));
                    Vector3 finalDestination = new Vector3(newRandPosX, newRandPosY, newRandPosZ);
                    enemyAgent.SetDestination(finalDestination);
                    enemyAgent.stoppingDistance = 3.5f;
                    TurnOffAnimTriggers();
                    anim.SetBool("isWalking", true);
                }
                break;

            case STATE.CHASE:
                enemyAgent.SetDestination(targetPlayer.transform.position);
                enemyAgent.stoppingDistance = 3.5f;
                TurnOffAnimTriggers();
                anim.SetBool("isRunning", true);
                if (enemyAgent.remainingDistance <= enemyAgent.stoppingDistance && !enemyAgent.pathPending)
                {
                    state = STATE.ATTACK;
                }
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
