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
    private float walkSpeed = 0.3f, sprintSpeed = 0.6f;
    private int maxAmmo = 75, currAmmo = 0;
    private int maxMedPickup = 15, medPack = 0;
    public int ammoFireCount = 0;

    private Rigidbody rb;
    private CapsuleCollider capsuleCollider;
    public GameObject cam;
    private Quaternion playerRotation;
    private Quaternion camRotation;

    public Animator animator;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();   
        capsuleCollider = GetComponent<CapsuleCollider>();
    }

    void Start()
    {
        currAmmo = 25;
        medPack = maxMedPickup;
        camRotation = cam.transform.localRotation;
        playerRotation = transform.localRotation;
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(1))
        {
            animator.SetBool("Aiming", !animator.GetBool("Aiming"));
        }

        if (Input.GetMouseButtonDown(0) && !animator.GetBool("Firing"))
        {
            if (currAmmo > 0)
            {
                //animator.SetBool("Firing", !animator.GetBool("Firing"));
                currAmmo = Mathf.Clamp(currAmmo - 1, 0, currAmmo);
                animator.SetTrigger("Firing");
                Debug.Log("Ammo left= " + currAmmo);
                ammoFireCount++;
                print("Ammo Fire Count: " + ammoFireCount);
                ZombieHit();
            }
            
        }

        //if(Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.D))
        //{
        //    animator.SetBool("Walking", true);
        //}
        //else if(Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.D))
        //{
        //    animator.SetBool("Walking", false);
        //}

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            animator.SetBool("Running", true);
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            animator.SetBool("Running", false);
        }
        else if ((Input.GetKeyDown(KeyCode.LeftShift)) && Input.GetMouseButtonDown(0))
        {
            print("Running and Firing On");
            animator.SetBool("RunFire", true);
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift) && Input.GetMouseButtonUp(0))
        {
            print("Running and Firing Off");
            animator.SetBool("RunFire", false);
        }

        //if ((Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.D)) && (Input.GetMouseButtonDown(0)))
        //{
        //    animator.SetBool("WalkFire", !animator.GetBool("WalkFire"));
        //}

        if (Input.GetKeyDown(KeyCode.R))
        {
            animator.SetTrigger("Reloading");
            //int ammoNeeded = maxAmmoPickup - ammunition;
            //print("ammoNeeded: "+ ammoNeeded);

            //if(ammoNeeded < ammunition)
            //{
            //    ammunition = ammunition + ammoNeeded;
            //    print("current ammo: "+ ammunition);
            //}
            //else if(ammoNeeded > ammunition)
            //{
            //    ammunition = ammunition + ammoNeeded;
            //    print("current ammo: " + ammunition);
            //}
            currAmmo = currAmmo + ammoFireCount;
            maxAmmo = maxAmmo - ammoFireCount;
            
            print("Curr Ammo: " + currAmmo + "  Max Ammo: " + maxAmmo);

            //if (ammoFireCount == 25)
            //{
            //    animator.SetTrigger("Reloading");
            //}
            ammoFireCount = 0;
        }

        if (Input.GetKey(KeyCode.Space))
        {
            animator.SetTrigger("JumpRifle");
        }

        //if (Input.GetKey(KeyCode.F))
        //{
        //    animator.SetTrigger("Melee");
        //}
    }

    private void ZombieHit()
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
        if (Input.GetKey(KeyCode.LeftShift))
        {
            print("Speed Increased");
            playerSpeed = sprintSpeed;
        }
        else
        {
            playerSpeed = walkSpeed;
        }

        float horizontalMovement = Input.GetAxis("Horizontal") * playerSpeed;
        float forwardMovement = Input.GetAxis("Vertical") * playerSpeed;

        if (horizontalMovement != 0 || forwardMovement != 0)
        {
            animator.SetBool("Walking", true);
        }
        else
        {
            animator.SetBool("Walking", false);
        }

        //transform.position += new Vector3(horizontalMovement, 0, forwardMovement);
        
        transform.position += cam.transform.forward * forwardMovement + cam.transform.right * horizontalMovement;
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

    void OnCollisionEnter(Collision collision)
    {
       if(collision.gameObject.tag == "ammo" && maxAmmo < 75)
        {
            print("Ammo Collected");
            //ammoPickup += 5;
            //currAmmo = Mathf.Clamp(currAmmo + 5, 0, 25);
            maxAmmo = Mathf.Clamp(maxAmmo + 10, 0, 75);
            Destroy(collision.gameObject);
            Debug.Log("ammoPickup: " + maxAmmo);

        }
       else if (collision.gameObject.tag == "med" && medPack < maxMedPickup)
        {
            print("Medkit Collected");
            Destroy(collision.gameObject);
            medPack = Mathf.Clamp(medPack + 5, 0, maxMedPickup);
            Destroy(collision.gameObject);
            Debug.Log("medPickup= " + medPack);
        }
       else if(collision.gameObject.tag == "lava")
        {
            //medPack -= 5;
            //player death when health reaches zero (need to be done)
            medPack = Mathf.Clamp(medPack - 5, 0, maxMedPickup);
            Debug.Log("Health= " + medPack);
        }
    }
}
