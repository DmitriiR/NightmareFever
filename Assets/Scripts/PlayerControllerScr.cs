using UnityEngine;
using System.Collections;

public class PlayerControllerScr : MonoBehaviour {

    // Use this for initialization

    ///  public float speed = 6.0F;
    //  public float jumpSpeed = 16.0F;
    // possible use public float jumpHeight; 
    //  public float gravity = 20.0F;
    // private Vector3 moveDirection = Vector3.zero;


    // new code and variable declarations
    public bool playerAlive = true;
    public float playerLife;
    public float playerMaxLife;

    public float speed = 6.0f;
    public float jumpSpeed = 8.0f;
    public float gravity = 20.0f;
    public float rotateSpeedGrounded = 0.0f;    // Rotation speed at ground

    public float inAirSpeed = 2.0f;             // Adds or substracts to the movementspeed in air
    public float inAirDrift = 0.5f;             // Adds Sidewards drift in air
    public float inAirRotation = 0.5f;          // Rotation speed in air. Uncomment this to let the player change the face direction in air

    public float extraJumpForce = 5.0f;         //How much extra force to give to our jump when the button is held down
    public float maxExtraJumpTime = 2.0f;       //Maximum amount of time the jump button can be held down for
    public float delayToExtraJumpForce = 2.0f;  //Delay in how long before the extra force is added
    private float jumpTimer;             //Used in calculating the extra jump delay
    private bool playerJumped = false;           //Tell us if the player has jumped
    private bool playerJumping = false;          //Tell us if the player is holding down the jump button

    private Vector3 moveDirection = Vector3.zero;
    private float inputModifyFactor = 1.0f;
    private bool isGrounded = false;
    public Transform groundChecker;
    private bool pressedJump = false;
    private bool unpressedJump = false;

    CharacterController controller;

    ParticleSystem damageEffect;

    public Animator anim;
    private Animation animationRef;

  

    void Start ()
    {
       controller = this.GetComponent<CharacterController>();
        damageEffect = this.GetComponentInChildren<ParticleSystem>();
        damageEffect.enableEmission = false;
       // anim = GetComponent<Animator>();
        animationRef = GetComponent<Animation>();

      

    }


    void ProcessAnimations()
    {
        pressedJump = Input.GetButton("Jump");
        unpressedJump = Input.GetButtonUp("Jump");

        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
        {
            anim.SetBool("Run", true);
        }
        else
        {
            anim.SetBool("Run", false);
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            anim.SetBool("RunLeft", true);
        }
        else
        {
            anim.SetBool("RunLeft", false);
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            anim.SetBool("RunRight", true);
        }
        else
        {
            anim.SetBool("RunRight", false);
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            anim.SetBool("RunBack", true);
        }
        else
        {
            anim.SetBool("RunBack", false);
        }

        if (Input.GetKey(KeyCode.Space))
        {
            anim.SetBool("Attack", true);
            // animationRef.GetClip("jump").;
        }
        else
        {
            anim.SetBool("Attack", false);
        }

    }
    
    void Update()
    {
        ProcessAnimations();

     //   controller.Move(moveDirection * Time.deltaTime);
       

    }

    void FixedUpdate()
    {

        isGrounded = Physics.Linecast(this.GetComponent<Transform>().transform.position, groundChecker.position);
        float rayDistance = controller.bounds.extents.y;
        isGrounded = Physics.Raycast (transform.position, Vector3.down, rayDistance );
        //If our player hit the jump key, then it's true that we jumped!
        if (pressedJump)
        {
            if (isGrounded)
            {
                pressedJump = false;
                playerJumped = true;   //Our player jumped!
                playerJumping = true;  //Our player is jumping!
                jumpTimer = Time.time; //Set the time at which we jumped
            }
        }

        //If our player lets go of the Jump button OR if our jump was held down to the maximum amount...
        if (unpressedJump || Time.time - jumpTimer > maxExtraJumpTime)
        {
            unpressedJump = false;
            playerJumping = false; //... then set PlayerJumping to false
        }

       // CharacterController controller = GetComponent<CharacterController>();
        //            // ---------------------------------------- At Ground -----------------------------------------
        if (isGrounded)
        {
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            moveDirection *= speed;
            inputModifyFactor = (moveDirection.x != 0.0f && moveDirection.z != 0.0f) ? 0.7071f : 1.0f;
            moveDirection *= inputModifyFactor;


            if (playerJumped)
            {
                moveDirection.y = jumpSpeed;
                playerJumped = false;
            }
        }
        // ---------------------------------------------------- In Air  ----------------------------
        else
        {
            // We are not grounded. We can still influence the movement with the horizontal and vertical axis, but not so strong.
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), moveDirection.y, Input.GetAxis("Vertical"));
            moveDirection.x *= speed;
            moveDirection.z *= speed;
            moveDirection.y -= gravity * Time.deltaTime;
        }

        // ---------------------------------------------------------------------------------------------        
        //Rotate
        Vector3 curDir = new Vector3(moveDirection.x, 0, moveDirection.z);
        Vector3 newDir = Vector3.RotateTowards(transform.forward, curDir, (isGrounded ? rotateSpeedGrounded : inAirRotation) * Time.deltaTime, 0.0F);
        Debug.DrawRay(transform.position, newDir * 10, Color.red);
        transform.rotation = Quaternion.LookRotation(newDir);

        //Move the controller
        if (moveDirection != Vector3.zero)
        {

            if (playerJumping && Time.time - jumpTimer > delayToExtraJumpForce)
            {
                moveDirection.y = moveDirection.y + extraJumpForce;
                playerJumping = false;
            }

            if (controller)
            controller.Move(moveDirection * Time.deltaTime);
        }
    }


}

    
