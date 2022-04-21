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
    public float saveSpeed, crouchChange;
    private float speed = 12f;
    public float multiplierSpeed;
    public float gravity = -10f;
    public float jumpHeight = 2f;
    bool running, crouching;
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    [HideInInspector]
    public float altitude;

    Vector3 velocity;
    bool isGrounded;


    float x;
    float z;
    bool jumpPressed = false;

#if ENABLE_INPUT_SYSTEM
    InputAction movement;
    InputAction jump;
    void Awake()
    {
        inputStm = new InputSystemActions();
        inputStm.GamePlay.Run.performed += ctx => running = true;
        inputStm.GamePlay.Run.canceled += ctx => running = false;
        inputStm.GamePlay.Crouch.performed += ctx => crouching = true;
        inputStm.GamePlay.Crouch.canceled += ctx => crouching = false;

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
    }
#endif

    // Update is called once per frame
    void Update()
    {
        Movement();
        MovementStat();
        HeightStat();
    }

    void Movement()
    {
        Debug.Log(jumpPressed);

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

        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);

        if (jumpPressed && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
    }

    private void OnEnable()
    {
        inputStm.Enable();
    }
    private void OnDisable()
    {
        inputStm.Disable();
    }

    void MovementStat()
    {
        if (running)
        {
            speed = saveSpeed * multiplierSpeed;
        }
        else
        {
            speed = saveSpeed;
        }
    }
    void HeightStat()
    {
        if (crouching)
        {
            controller.height = 1.8f - crouchChange * 2;
            controller.center = new Vector3(0, -crouchChange, 0);
            sight.transform.localPosition = new Vector3(0, -crouchChange * 2, 0);
            altitude = crouchChange;
        }
        else
        {
            if (seeCrouch.can)
            {
                controller.height = 1.8f;
                controller.center = new Vector3(0, 0, 0);
                sight.transform.localPosition = new Vector3(0, 0, 0);
                altitude = crouchChange;
            }
            else
            {
                controller.height = 1.8f - crouchChange * 2;
                controller.center = new Vector3(0, -crouchChange, 0);
                sight.transform.localPosition = new Vector3(0, -crouchChange * 2, 0);

            }
        }
    }
}
