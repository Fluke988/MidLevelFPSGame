using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharController : MonoBehaviour
{
    public float playerSpeed;
    Rigidbody rb;
    public float playerJumpValue;
    private bool isGrounded;
    private CapsuleCollider capsuleCollider;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();   
        capsuleCollider = GetComponent<CapsuleCollider>();
    }

    void Start()
    {
        
    }
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        PlayerMovement();
        PlayerJumpMovement();
    }

    bool PlayerGrounded()
    {
        RaycastHit hitInfo;

        if(Physics.SphereCast(transform.position, capsuleCollider.radius, Vector3.down, out hitInfo, (capsuleCollider.height/2.0f) - capsuleCollider.radius+0.1f ))
        {
            print("true statement");
            return true;
            
        }
        else
        {
            print("false statement");
            return false;
        }
    }

    void PlayerMovement()
    {
        float horizontalMovement = Input.GetAxis("Horizontal") * playerSpeed;
        float forwardMovement = Input.GetAxis("Vertical") * playerSpeed;

        transform.position += new Vector3(horizontalMovement, 0, forwardMovement);
    }

    void PlayerJumpMovement()
    {
        if (Input.GetKeyDown(KeyCode.Space) && PlayerGrounded())
        {
            print("jump pressed");
            rb.AddForce(0, playerJumpValue, 0);
            //rb.velocity = new Vector3(0, playerJumpValue, 0);
        }
    }
}
