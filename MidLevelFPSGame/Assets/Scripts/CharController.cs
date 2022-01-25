using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharController : MonoBehaviour
{
    public float playerSpeed;
    public float playerJumpValue;
    private bool isGrounded;
    public float rotationSpeed;
    public float minX = -90.0f, maxX= 90.0f;

    private Rigidbody rb;
    private CapsuleCollider capsuleCollider;
    public GameObject cam;
    private Quaternion playerRotation;
    private Quaternion camRotation;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();   
        capsuleCollider = GetComponent<CapsuleCollider>();
    }

    void Start()
    {
        camRotation = cam.transform.localRotation;
        playerRotation = transform.localRotation;
    }

    void Update()
    {
        
    }

    void FixedUpdate()
    {
        PlayerMovement();
        PlayerJumpMovement();

        float mouseX = Input.GetAxis("Mouse X") * rotationSpeed;
        float mouseY = Input.GetAxis("Mouse Y") * rotationSpeed;

        camRotation = Quaternion.Euler(-mouseY, 0, 0) * camRotation;
        playerRotation = Quaternion.Euler(0, mouseX, 0) * playerRotation;

        transform.localRotation = playerRotation;
        cam.transform.localRotation = camRotation;

        camRotation = ClampRotationOnXaxis(camRotation);
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

    Quaternion ClampRotationOnXaxis(Quaternion value)
    {
        value.x /= value.w;
        value.y /= value.w;
        value.z /= value.w;

        value.w = 1.0f;

        float angleX = 2.0f * Mathf.Rad2Deg*Mathf.Atan(value.x);
        angleX = Mathf.Clamp(angleX, minX, maxX);
        value.x = Mathf.Tan(0.5f * Mathf.Deg2Rad * angleX);

        return value;
    }
}
