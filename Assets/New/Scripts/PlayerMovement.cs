#if ENABLE_INPUT_SYSTEM 
using UnityEngine.InputSystem;
#endif

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    InputSystemActions inputStm;
    public CharacterController controller;
    public CrouchSeen seeCrouch;
    public GameObject sight;
    public float saveSpeed, crouchChange, staminaJumpCost;
    private float speed = 12f, divideMulti;
    public float multiplierSpeed, dividerSpeed;
    public float gravity = -10f;
    public float jumpHeight = 2f;
    bool tryCrouching;
    public Transform groundCheck;
    public float groundDistance;
    public LayerMask groundMask;
    [HideInInspector]
    public float altitude;
    
    private Stamina staminaCount;
    
    Vector3 velocity;
    [HideInInspector]
    public bool isGrounded, moving, running, crouching, runningWall, stunned;
    private bool jumper;

    float x;
    float z;
    bool jumpPressed = false;

    [HideInInspector]
    public GameObject poseser;

#if ENABLE_INPUT_SYSTEM
    InputAction movement;
    InputAction jump;
    void Awake()
    {
        inputStm = new InputSystemActions();
        inputStm.GamePlay.Run.performed += ctx => running = true;
        inputStm.GamePlay.Run.canceled += ctx => running = false;
        inputStm.GamePlay.Crouch.performed += ctx => tryCrouching = true;
        inputStm.GamePlay.Crouch.canceled += ctx => tryCrouching = false;
        inputStm.GamePlay.Jump.performed += _ => Jumping();
        inputStm.GamePlay.Movement.performed += ctx => moving = true;
        inputStm.GamePlay.Movement.canceled += ctx => moving = false;
    }
    void Start()
    {
        speed = saveSpeed;
        movement = new InputAction("PlayerMovement", binding: "<Gamepad>/leftStick");
        movement.AddCompositeBinding("Dpad")
            .With("Up", "<Keyboard>/w")
            .With("Up", "<Keyboard>/upArrow")
            .With("Down", "<Keyboard>/s")
            .With("Down", "<Keyboard>/downArrow")
            .With("Left", "<Keyboard>/a")
            .With("Left", "<Keyboard>/leftArrow")
            .With("Right", "<Keyboard>/d")
            .With("Right", "<Keyboard>/rightArrow");

        jump = new InputAction("PlayerJump", binding: "<Gamepad>/a");
        jump.AddBinding("<Keyboard>/space");

        movement.Enable();
        jump.Enable();
        staminaCount = gameObject.GetComponent<Stamina>();
    }
#endif

    // Update is called once per frame
    void Update()
    {
        if (poseser == null)
        {
            Movement();
            MovementStat();
            HeightStat();
        }

    }
    void Movement()
    {
        //Debug.Log(jumpPressed);

#if ENABLE_INPUT_SYSTEM
        var delta = movement.ReadValue<Vector2>();
        x = delta.x;
        z = delta.y;
        jumpPressed = Mathf.Approximately(jump.ReadValue<float>(), 1);
#else
        x = Input.GetAxis("Horizontal");
        z = Input.GetAxis("Vertical");
        jumpPressed = Input.GetButtonDown("Jump");

#endif
        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);
        if (velocity.y < 0)
        {
            jumper = false;
        }
        if (isGrounded && !jumper)
        {
            velocity.y = 0;
        }
        else
        {
            velocity.y += gravity * Time.deltaTime;
        }
        if (controller.velocity.x != 0 || controller.velocity.z != 0)
        {
            Debug.Log("Hold");
            runningWall = true;
        }
        else
        {
            runningWall = false;
        }
        controller.Move(velocity * Time.deltaTime);
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, 1 << 3);

    }

    private void OnEnable()
    {
        inputStm.Enable();
    }
    private void OnDisable()
    {
        inputStm.Disable();
    }

    void Jumping()
    {
        if (isGrounded && !tryCrouching && staminaCount.actStamina >= staminaJumpCost && poseser == null)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            staminaCount.actStamina -= staminaJumpCost;
            jumper = true;
        }

    }
    void MovementStat()
    {
        if (crouching)
        {
            speed = saveSpeed / dividerSpeed;
        }
        else if (running && !crouching)
        {
            speed = saveSpeed * (multiplierSpeed / divideMulti);
        }
        else if (!running&&!crouching)
        {
            speed = saveSpeed;
        }
        if (staminaCount.empty)
        {
            divideMulti = multiplierSpeed;
        }
        else
        {
            divideMulti = 1;
        }
    }
    void HeightStat()
    {
        if (tryCrouching)
        {
            controller.height = 1.8f - crouchChange * 2;
            controller.center = new Vector3(0, -crouchChange, 0);
            sight.transform.localPosition = new Vector3(0, -crouchChange * 2, 0);
            altitude = crouchChange;
            crouching = true;
        }
        else
        {
            if (seeCrouch.can)
            {
                controller.height = 1.8f;
                controller.center = new Vector3(0, 0, 0);
                sight.transform.localPosition = new Vector3(0, 0, 0);
                altitude = crouchChange;
                crouching = false;
            }
            else
            {
                controller.height = 1.8f - crouchChange * 2;
                controller.center = new Vector3(0, -crouchChange, 0);
                sight.transform.localPosition = new Vector3(0, -crouchChange * 2, 0);
                crouching = true;
            }
        }
    }
}
