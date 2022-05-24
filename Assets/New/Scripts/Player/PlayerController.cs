using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
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
    [HideInInspector]
    public PlayerMovement c_temp_mov;
    private AtackMele c_atk;
    [HideInInspector]
    public Jump c_jmp;
    [HideInInspector]
    public ChangeWeapon c_chWp;
    [HideInInspector]
    public ShootPlayer c_shoot;
    private float stMultiplier;

    void Awake()
    {
        //Component Settup -----------//
        currentWeapon = weapons[0];
        c_ray = gameObject.GetComponent<FrontRayCaster>();
        c_life = gameObject.GetComponent<Life>();
        c_mp = gameObject.GetComponent<MP_System>();
        c_stm = gameObject.GetComponent<Stamina>();
        c_mov = gameObject.GetComponent<Movement>();
        c_temp_mov = gameObject.GetComponent<PlayerMovement>();
        c_jmp = gameObject.GetComponent<Jump>();
        c_atk = gameObject.GetComponent<AtackMele>();
        c_chWp = GameObject.Find("Main Camera/FBX_Brazo-infectado").GetComponent<ChangeWeapon>();
        c_shoot= GameObject.Find("Main Camera/GunPointer").GetComponent<ShootPlayer>();
        //-------------------------<<<//


        //Input System Setup----------//
        inputStm = new InputSystemActions();
        inputStm.GamePlay.Interact.performed += _ => c_ray.Interact();
        //inputStm.GamePlay.Crouch.performed += ctx => c_temp_mov.HeightStat();
        inputStm.GamePlay.Heal.performed += ctx => c_life.TotalRecovery();
        inputStm.GamePlay.MeleAtack.performed += ctx => c_atk.Attack();
        inputStm.GamePlay.Atack.performed += ctx => c_shoot.Shooting(currentWeapon, c_mp);
        //inputStm.GamePlay.Atack.performed += _ => c_shoot.Shoot();
        inputStm.GamePlay.Recharge.performed += ctx => c_shoot.Recharge(c_mp);
        /*inputStm.GamePlay.Movement.performed += ctx => c_mov.direction=ctx.ReadValue<Vector2>();
        inputStm.GamePlay.Movement.canceled += ctx => c_mov.direction = Vector2.zero;*/
        inputStm.GamePlay.Jump.performed += ctx => c_jmp.Jumping();
        inputStm.GamePlay.StaminaFull.performed += ctx => c_stm.actStamina = c_stm.maxStamina;
        inputStm.GamePlay.ChangeWeapon1.performed += ctx => currentWeapon=c_chWp.WeaponChanger(0, weapons);
        inputStm.GamePlay.ChangeWeapon2.performed += ctx => currentWeapon=c_chWp.WeaponChanger(1, weapons);
        //inputStm.GamePlay.Atack.performed += _ => c_jmp.Jumping();

        //inputStm.GamePlay.Run.performed += _ => c_mov.Move();
        /*inputStm.GamePlay.Run.performed += _ => stMultiplier = -1;
        inputStm.GamePlay.Run.canceled += _ => stMultiplier = 1;*/

        //-------------------------<<<//

    }
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        ModifyStamina();
        StaminaCondition();
        if (c_mov.direction != Vector2.zero)
            c_mov.Move();

    }

    void ModifyStamina()
    {
        c_stm.ConstModify(stMultiplier);
    }
    void StaminaCondition()
    {
        if (c_temp_mov.moving && c_temp_mov.running && !c_temp_mov.crouching && !c_stm.empty && c_temp_mov.runningWall)
        {
            stMultiplier = -1;
        }
        else if (c_temp_mov.moving && c_temp_mov.running && !c_temp_mov.crouching && c_stm.empty)
        {
            stMultiplier = 0;
        }
        else
        {
            stMultiplier = 1;
        }
    }

    public void LoadData()
    {
        /*c_life.maxHealth = playerData.maxLife;
        c_stm.increaseSpd = playerData.staminaRegenSpd;
        c_mp.maxMP = playerData.maxMana;*/
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
}
