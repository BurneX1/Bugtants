using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    [Tooltip("Es para ver si estarán bloqueadas o no en un nivel, true significa que no ejecute")]
    public bool runLock, hitLock, weaponLock, crouchLock;
    public PlayerData playerData;
    public WeaponStats[] weapons;
    private WeaponStats currentWeapon;
    private InputSystemActions inputStm;
    private FrontRayCaster c_ray;

    [HideInInspector]
    public Life c_life;
    [HideInInspector]
    public MP_System c_mp;
    [HideInInspector]
    public Stamina c_stm;
    [HideInInspector]
    public Movement c_mov;
    private AtackMele c_atk;
    [HideInInspector]
    public Jump c_jmp;
    [HideInInspector]
    public ChangeWeapon c_chWp;
    [HideInInspector]
    public ShootPlayer c_shoot;
    [HideInInspector]
    public Crouch c_crouch;
    [HideInInspector]
    public float stMultiplier;
    [HideInInspector]
    public int weaponNumber, numberMove;
    [HideInInspector]
    public bool moving, running, crouching, stunned, slowed;
    [HideInInspector]
    public WaysToSound shootSound, jumpSound, moveSound, crouchSound;
    private GameObject slowerings;

    void Awake()
    {
        //Component Settup -----------//
        currentWeapon = weapons[0];
        weaponNumber = 0;
        c_ray = gameObject.GetComponent<FrontRayCaster>();
        c_life = gameObject.GetComponent<Life>();
        c_mp = gameObject.GetComponent<MP_System>();
        c_stm = gameObject.GetComponent<Stamina>();
        c_mov = gameObject.GetComponent<Movement>();
        c_jmp = gameObject.GetComponent<Jump>();
        c_atk = gameObject.GetComponent<AtackMele>();
        c_crouch = gameObject.GetComponent<Crouch>();
        c_chWp = GameObject.Find("Main Camera/FBX_Brazo-infectado").GetComponent<ChangeWeapon>();
        c_shoot = GameObject.Find("Main Camera/FBX_Brazo-infectado/GunPointer").GetComponent<ShootPlayer>();
        //-------------------------<<<//

        //Sounds Setup -----------//
        shootSound.sounds = gameObject.GetComponent<SoundActive>();
        jumpSound.sounds = gameObject.GetComponent<SoundActive>();
        moveSound.sounds = gameObject.GetComponent<SoundActive>();
        crouchSound.sounds = gameObject.GetComponent<SoundActive>();

        //-------------------------<<<//

        //Input System Setup----------//
        inputStm = new InputSystemActions();
        inputStm.GamePlay.Crouch.performed += ctx => CrouchLocker(crouchLock, true);
        inputStm.GamePlay.Crouch.canceled += ctx => CrouchLocker(crouchLock, false);
        inputStm.GamePlay.Heal.performed += ctx => c_life.TotalRecovery();
        inputStm.GamePlay.MeleAtack.performed += ctx => HitLocker(hitLock, true);
        inputStm.GamePlay.Atack.performed += ctx => HitLocker(hitLock, false);
        inputStm.GamePlay.Recharge.performed += ctx => c_shoot.Recharge(c_mp);
        inputStm.GamePlay.Movement.performed += ctx => c_mov.direction=ctx.ReadValue<Vector2>();
        inputStm.GamePlay.Movement.canceled += ctx => c_mov.direction = Vector2.zero;
        inputStm.GamePlay.Jump.performed += ctx => c_jmp.Jumping(c_crouch.crouching, stunned);
        inputStm.GamePlay.StaminaFull.performed += ctx => c_stm.actStamina = c_stm.maxStamina;
        inputStm.GamePlay.ChangeWeapon1.performed += ctx => WeaponsLocker(weaponLock, 0);
        inputStm.GamePlay.ChangeWeapon2.performed += ctx => WeaponsLocker(weaponLock, 1);
        inputStm.GamePlay.ChangeWeapons.performed += ctx => WeaponsLockers(weaponLock, ctx.ReadValue<float>());
        inputStm.GamePlay.ChangeWeapons.performed += ctx => Debug.Log(ctx.ReadValue<float>());
        inputStm.GamePlay.Run.performed += ctx => RunLocker(runLock, true);
        inputStm.GamePlay.Run.canceled += ctx => RunLocker(runLock, false);
        //-------------------------<<<//



    }
    void RunLocker(bool locked, bool runner)
    {
        if (!locked)
            running = runner;
    }
    void HitLocker(bool locked, bool melee)
    {
        if (!locked)
        {
            if (melee)
            {
                c_atk.Attack();
                numberMove = 2;
            }
            else
            {
                c_shoot.Shooting(currentWeapon, c_mp, shootSound);
            }
        }
    }
    void CrouchLocker(bool locked, bool croucher)
    {
        if (!locked)
            crouching = croucher;
    }
    void WeaponsLocker(bool locked, int number)
    {
        if (!locked)
        {
            currentWeapon = c_chWp.WeaponChanger(number, weapons, currentWeapon);
            ChangedWeapon(number);
        }
    }
    void WeaponsLockers(bool locked, float upDown)
    {
        int number = weaponNumber;
        if (!locked)
        {
            if (upDown > 0)
            {
                number++;
            }
            else if (upDown < 0)
            {
                number--;
            }
            if (number < 0)
            {
                number = weapons.Length - 1;
            }
            else if (number >= weapons.Length)
            {
                number = 0;
            }

            WeaponsLocker(weaponLock, number);
        }
    }
    void ChangedWeapon(int value)
    {
        weaponNumber = value;
        c_shoot.ResetTime();
    }
    // Update is called once per frame
    void Update()
    {
        PlayerLogic();
        ModifyStamina();
        StaminaCondition();
        PlayerStature();
        OneTimeSound();
    }
    void PlayerLogic()
    {
        c_jmp.CheckGround();
        if (c_shoot.shoot)
        {
            numberMove = 1;
            c_shoot.shoot = false;
        }
        if (c_mov.poseser || stunned)
        {
            c_mov.Posesed();
        }
        else if (c_mov.direction != Vector2.zero && !stunned)
        {
            c_mov.Move();
            moving = true;
        }
        else
        {
            c_mov.Quiet();
            moving = false;
        }
        if (crouching && !c_mov.poseser && !stunned && c_jmp.isGrounded)
            c_crouch.Crouching(playerData.crouchHeight);
        else
            c_crouch.NonCrouching(playerData.crouchHeight);

        if (slowed && (running || moving))
        {
            c_mov.speed = playerData.slowSpeed;

        }
        else if (crouching)
        {
            c_mov.speed = playerData.crouchSpeed;
            if (moving)
            {
                /*Debug.Log("Run");
                moveSound.whereSound = 1;
                moveSound.whatSound = 1;
                moveSound.ActiveWhenStopped();*/
            }
        }
        else if (running /*&& !c_stm.empty*/)
        {
            c_mov.speed = playerData.runSpeed;
            if (c_jmp.isGrounded)
            {
                Debug.Log("Run");
                moveSound.whereSound = 1;
                moveSound.whatSound = 1;
                moveSound.ActiveWhenStopped();
            }
        }
        else if (moving)
        {
            c_mov.speed = playerData.normalSpeed;
            if (c_jmp.isGrounded)
            {
                Debug.Log("Walk");
                moveSound.whereSound = 1;
                moveSound.whatSound = 0;
                moveSound.ActiveWhenStopped();
            }
        }
        if (!moving && !running)
        {
            moveSound.InstantStop(); //Si hay un sonido cuando el jugador esté en idle, entonces se cambiará por StopThenActive
        }
        c_mov.grounded = c_jmp.isGrounded;
        if (slowed && slowerings == null)
        {
            StartCoroutine(SlowTheme());
        }
    }
    void ModifyStamina()
    {
        c_stm.ConstModify(stMultiplier);
    }
    void OneTimeSound()
    {
        if (c_jmp.jumping)
        {
            JumpSound();
            c_jmp.jumping = false;
        }
        if (c_crouch.crouchSound && !c_crouch.sounded)
        {
            CrouchingSound();
        }
    }
    void JumpSound()
    {
        jumpSound.whereSound = 1;
        jumpSound.whatSound = 2;
        jumpSound.StopThenActive();
    }
    void CrouchingSound()
    {
        crouchSound.whereSound = 3;
        crouchSound.whatSound = 3;
        crouchSound.StopThenActive();
        c_crouch.sounded = true;
    }
    void StaminaCondition()
    {
        if (moving && running && !c_crouch.crouching && !c_stm.empty /*&& runningWall*/)
        {
            stMultiplier = -1;
        }
        else if (moving && running && !c_crouch.crouching && c_stm.empty)
        {
            stMultiplier = 0;
        }
        else
        {
            stMultiplier = 1;
        }
    }
    void PlayerStature()
    {
        GetComponent<CapsuleCollider>().height = c_crouch.height;
        GetComponent<CapsuleCollider>().center = c_crouch.centering;
    }
    public void Stunning(float seconds)
    {
        StartCoroutine(StunnedPlayer(seconds));
    }
    IEnumerator StunnedPlayer(float timer)
    {
        stunned = true;
        yield return new WaitForSeconds(timer);
        stunned = false;
    }

    public void LoadData()
    {
        c_life.maxHealth = playerData.maxLife;
        c_stm.Maxed(playerData.maxStamina);
        c_stm.increaseSpd = playerData.staminaRegenSpd;
        c_mp.maxMP = playerData.maxMana;
        c_jmp.heightJump = playerData.jumpHeight;
        c_mov.speed = playerData.normalSpeed;
        c_crouch.crouchSpeed = playerData.crouchDelaying;
        c_mov.gravity = playerData.gravityPush;
        c_chWp.changeSeconds = playerData.delayChange;
    }
    public void LoadWeapon()
    {
        for(int i=0; i < weapons.Length; i++)
        {
            if (i == weaponNumber)
            {
                currentWeapon = weapons[i];
            }
        }
    }

    private void OnEnable()
    {
        inputStm.Enable();

        if(playerData)
        {
            LoadData();
        }
    }
    private void OnDisable()
    {
        inputStm.Disable();
    }
    IEnumerator SlowTheme()
    {
        yield return new WaitForSeconds(playerData.slowTime);
        slowed = false;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Slime")
        {
            slowed = true;
            slowerings = other.gameObject;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Slime")
        {
            slowerings = null;
        }
    }
}
