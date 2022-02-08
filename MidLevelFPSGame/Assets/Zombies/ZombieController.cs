//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.AI;

///*                  FINITE STATE MACHINE(FSM)
// *                  
// * It is an artificial intelligence system for storing state data and transition between them.
// * Eg: Animation System
// * 
// * A FSM that defines all the states they can be in and how they can get from one state to another state.
// * 
// *1.Determine the states of the character
// *  In zombie character, we determined five states: a)Idle b)Wander c)Chase d)Attack e)Death
// *  
// */

//public class ZombieController : MonoBehaviour
//{
//    Animator anim;
//    public GameObject targetPlayer;
//    NavMeshAgent enemyAgent;
//    public float walkingSpeed, runningSpeed;

//    enum STATE { IDLE, WANDER, CHASE, ATTACK, DEATH }
//    STATE state = STATE.IDLE;

//    void Start()
//    {
//        anim = this.GetComponent<Animator>();
//        enemyAgent = GetComponent<NavMeshAgent>();

//        //anim.SetBool("isWalking", true);
//    }

//    void TurnOffAnimTriggers()
//    {
//        anim.SetBool("isWalking", false);
//        anim.SetBool("isAttacking", false);
//        anim.SetBool("isRunning", false);
//        anim.SetBool("isDead", false);
//    }

//    bool ZombieCanSeePlayer()
//    {
//        //Logic for Zombie to see the player and chase
//        //Need to calculate the distance between the zombie and the player
//        if (DistanceToPlayer() > 10.0f)
//        {
//            return true;
//        }

//        return false;
//    }

//    float DistanceToPlayer()
//    {
//        return Vector3.Distance(targetPlayer.transform.position, this.transform.position);
//    }
//    bool isVisible()
//    {
//        //logic for zombie to see the player and chase
//        if (DistanceToPlayer() < 10.0f)
//        {
//            return true;
//        }
//        else
//        {
//            return false;
//        }
//    }

//    void Update()
//    {
//        switch (state)
//        {
//            case STATE.IDLE:
//                if (isVisible())
//                {
//                    state = STATE.CHASE;
//                }
//                else if(Random.Range(0,5000) < 5)
//                {
//                    state = STATE.WANDER;
//                }
//                break;

//            case STATE.WANDER:
//                if (!enemyAgent.hasPath)
//                {
//                    float newRandompositionX = this.transform.position.x + Random.Range(-10, 10);
//                    float newRandompositionZ = this.transform.position.z + Random.Range(-10, 10);
//                    float newRandompositionY = Terrain.activeTerrain.SampleHeight(new Vector3(newRandompositionX, 0, newRandompositionZ));
//                    Vector3 finalDestination = new Vector3(newRandompositionX, newRandompositionY, newRandompositionZ);
//                    enemyAgent.SetDestination(finalDestination);
//                    enemyAgent.stoppingDistance = 0f;
//                    TurnOffAnimTriggers();
//                    enemyAgent.speed = walkingSpeed;
//                    anim.SetBool("isWalking", true);
//                }
//                else if (isVisible())
//                {
//                    state = STATE.CHASE;
//                }
//                else if(Random.Range(0,1000)<5)
//                {
//                    state=STATE.IDLE;
//                    TurnOffAnimTriggers();
//                    enemyAgent.ResetPath();
//                }
//                break;

//            case STATE.CHASE:
//                enemyAgent.SetDestination(targetPlayer.transform.position);
//                enemyAgent.stoppingDistance = 2.0f;
//                enemyAgent.speed = runningSpeed;
//                TurnOffAnimTriggers();
//                anim.SetBool("isRunning", true);
//                if (enemyAgent.remainingDistance <= enemyAgent.stoppingDistance && !enemyAgent.pathPending)
//                {
//                    state = STATE.ATTACK;
//                }
//                else if (ZombieCanSeePlayer())
//                {
//                    state = STATE.WANDER;
//                    enemyAgent.ResetPath();
//                }
//                break;

//            case STATE.ATTACK:
//                TurnOffAnimTriggers();
//                anim.SetBool("isAttacking", true);
//                transform.LookAt(targetPlayer.transform);
//                if (DistanceToPlayer() > enemyAgent.stoppingDistance + 2f)
//                {
//                    state = STATE.CHASE;
//                }
//                break;

//            case STATE.DEATH:
//                break;

//            default:
//                break;
//        }
//    }





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
//}

//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.AI;

///*
// FINITE STATE MACHINE
//-it is an artificial inteligence system to store state's data and transition between them, example: animation system.
//-A finite state machine that defines all the states they can be in and how they can get from one state to another state.
//-determine the states of the character.
//-Zombie we determined five states.
//1. idle, 2. wander , 3. chase, 4. attack, 5. death. 


// */

//public class ZombieController : MonoBehaviour
//{
//    Animator anim;
//    public GameObject targetPlayer;
//    private NavMeshAgent agent;
//    public float walkingSpeed;
//    public float runningSpeed;


//    enum STATE { IDLE, WANDER, CHASE, ATTACK, DEAD };

//    STATE state = STATE.IDLE;


//    // Start is called before the first frame update
//    void Start()
//    {
//        anim = this.GetComponent<Animator>();
//        agent = this.GetComponent<NavMeshAgent>();
//        ///anim.SetBool("isWalking", true);
//    }

//    // Update is called once per frame
//    void Update()
//    {

//        switch (state)
//        {
//            case STATE.IDLE:
//                if (isVisible())
//                {
//                    state = STATE.CHASE;
//                }
//                else
//                {
//                    state = STATE.WANDER;
//                }


//                break;
//            case STATE.WANDER:
//                if (!agent.hasPath)
//                {
//                    float newRandompositionX = this.transform.position.x + Random.Range(-10, 10);
//                    float newRandompositionZ = this.transform.position.z + Random.Range(-10, 10);
//                    float newRandompositionY = Terrain.activeTerrain.SampleHeight(new Vector3(newRandompositionX, 0, newRandompositionZ));
//                    Vector3 finalDestination = new Vector3(newRandompositionX, newRandompositionY, newRandompositionZ);
//                    agent.SetDestination(finalDestination);
//                    agent.stoppingDistance = 0f;
//                    TrunOffAnimtriggers();
//                    agent.speed = walkingSpeed;
//                    anim.SetBool("isWalking", true);
//                }
//                if (isVisible())
//                {
//                    state = STATE.CHASE;
//                }

//                break;
//            case STATE.CHASE:
//                agent.SetDestination(targetPlayer.transform.position);
//                agent.stoppingDistance = 2.0f;
//                TrunOffAnimtriggers();
//                agent.speed = runningSpeed;
//                anim.SetBool("isRunning", true);
//                if (agent.remainingDistance <= agent.stoppingDistance && !agent.pathPending)
//                {
//                    state = STATE.ATTACK;
//                }
//                else if (ZombieCanSeeplayer())
//                {
//                    state = STATE.WANDER;
//                    agent.ResetPath();
//                }
//                break;
//            case STATE.ATTACK:
//                TrunOffAnimtriggers();
//                anim.SetBool("isAttacking", true);
//                transform.LookAt(targetPlayer.transform);
//                if (DistanceToThePlayer() > agent.stoppingDistance + 2f)
//                {
//                    state = STATE.CHASE;
//                }
//                break;
//            case STATE.DEAD:
//                break;
//            default:
//                break;
//        }
//    }
//    bool ZombieCanSeeplayer()
//    {
//        if (DistanceToThePlayer() > 10)
//        {
//            return true;
//        }
//        return false;
//    }

//    void TrunOffAnimtriggers()
//    {
//        anim.SetBool("isWalking", false);
//        anim.SetBool("isRunning", false);
//        anim.SetBool("isAttacking", false);
//        anim.SetBool("isDead", false);
//    }

//    private float DistanceToThePlayer()
//    {
//        return Vector3.Distance(targetPlayer.transform.position, this.
//            transform.position);
//    }
//    bool isVisible()
//    {
//        //logic for zombie to see the player and chase
//        if (DistanceToThePlayer() < 10f)
//        {
//            return true;
//        }
//        else
//        {
//            return false;
//        }
//    }
//}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;



/* Finite StateMachine
 * A finite statemachine is an artificial intelligence system for storing state data and transition between them.
 * Animation system is an example for it.
 * A finite statemachine that defines all the states they can be in and how they can get from one state to another state.
 * First determine the states of the character.
 * In zombie character we determined five states
 * 1)Idle 2)wander 3)Chase 4)Attack 5)Dead
 */
public class ZombieController : MonoBehaviour
{
    Animator anim;
    public GameObject targetPlayer;
    NavMeshAgent enemyAgent;
    public float walkingSpeed;
    public float runningSpeed;


    enum STATE
    {
        IDLE, WANDER, CHASE, ATTACK, DEAD
    };
    STATE state = STATE.IDLE;


    // Start is called before the first frame update
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
        //logic for zombie to see the player and chase
        //need to calculate distance to the player
        if (DistanceToPlayer() < 10)
        {
            return true;
        }
        return false;

    }

    bool ZombieCantSeePlayer()
    {
        if (DistanceToPlayer() > 10)
        {
            return true;
        }
        return false;
    }

    private float DistanceToPlayer()
    {
        return Vector3.Distance(targetPlayer.transform.position, this.transform.position);
    }


    // Update is called once per frame
    void Update()
    {
        //enemyAgent.SetDestination(targetPlayer.transform.position);
        //if (enemyAgent.remainingDistance > enemyAgent.stoppingDistance)
        //{
        //    anim.SetBool("isWalking", true);
        //    anim.SetBool("isAttacking", false);

        //}
        //else
        //{
        //    anim.SetBool("isWalking", false);
        //    anim.SetBool("isAttacking", true);
        //}
        switch (state)
        {
            case STATE.IDLE:
                if (ZombieCanSeePlayer())
                {
                    state = STATE.CHASE;
                }
                else if (Random.Range(0, 500) < 5)
                {
                    state = STATE.WANDER;
                }


                break;
            case STATE.WANDER:
                if (!enemyAgent.hasPath)
                {
                    float newRandomPositionX = this.transform.position.x + Random.Range(-10, 10);
                    float newRandomPositionZ = this.transform.position.z + Random.Range(-10, 10);
                    float newRandomPositionY = Terrain.activeTerrain.SampleHeight(new Vector3(newRandomPositionX, 0, newRandomPositionZ));
                    Vector3 finalDestination = new Vector3(newRandomPositionX, newRandomPositionY, newRandomPositionZ);
                    enemyAgent.SetDestination(finalDestination);
                    enemyAgent.stoppingDistance = 2.0f;
                    TurnOffAnimTriggers();
                    enemyAgent.speed = walkingSpeed;
                    anim.SetBool("isWalking", true);
                }
                else if (ZombieCanSeePlayer())
                {
                    state = STATE.CHASE;
                }
                else if (Random.Range(0, 100) < 5)
                {
                    state = STATE.IDLE;
                    TurnOffAnimTriggers();
                    enemyAgent.ResetPath();
                }


                break;
            case STATE.CHASE:
                enemyAgent.SetDestination(targetPlayer.transform.position);
                enemyAgent.stoppingDistance = 2.0f;
                TurnOffAnimTriggers();
                enemyAgent.speed = runningSpeed;
                anim.SetBool("isRunning", true);
                if (enemyAgent.remainingDistance <= enemyAgent.stoppingDistance && !enemyAgent.pathPending)
                {
                    state = STATE.ATTACK;
                }
                if (ZombieCantSeePlayer())
                {
                    state = STATE.WANDER;
                    enemyAgent.ResetPath();
                }
                break;
            case STATE.ATTACK:
                TurnOffAnimTriggers();
                anim.SetBool("isAttacking", true);
                transform.LookAt(targetPlayer.transform);
                if (DistanceToPlayer() > enemyAgent.stoppingDistance)
                {
                    state = STATE.CHASE;
                }
                break;
            case STATE.DEAD:
                break;
            default:
                break;
        }


    }
}