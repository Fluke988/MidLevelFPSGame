using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharController : MonoBehaviour
{
    public float playerSpeed;
    Rigidbody rb;
    public float playerJumpValue;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();    
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

    void PlayerMovement()
    {
        float horizontalMovement = Input.GetAxis("Horizontal") * playerSpeed /** Time.deltaTime*/;
        float forwardMovement = Input.GetAxis("Vertical") * playerSpeed /** Time.deltaTime*/;

        transform.position += new Vector3(horizontalMovement, 0, forwardMovement);
    }

    void PlayerJumpMovement()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            rb.AddForce(0, playerJumpValue, 0);
    }
}
