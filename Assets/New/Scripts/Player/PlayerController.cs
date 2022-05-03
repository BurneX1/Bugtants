using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private InputSystemActions inputStm;
    private FrontRayCaster c_ray;
    [HideInInspector]
    public Life c_life;
    [HideInInspector]
    public MP_System c_mp;
    [HideInInspector]
    public Stamina c_stm;

    private float stMultiplier;

    void Awake()
    {
        //Component Settup -----------//
        c_ray = gameObject.GetComponent<FrontRayCaster>();
        c_life = gameObject.GetComponent<Life>();
        c_mp = gameObject.GetComponent<MP_System>();
        c_stm = gameObject.GetComponent<Stamina>();
        //-------------------------<<<//


        //Input System Setup----------//
        inputStm = new InputSystemActions();

        inputStm.GamePlay.Interact.performed += _ => c_ray.Interact();
        inputStm.GamePlay.Crouch.performed += ctx => Debug.Log(ctx);
        inputStm.GamePlay.Run.performed += _ => stMultiplier = -1;
        inputStm.GamePlay.Run.canceled += _ => stMultiplier = 1;
        //-------------------------<<<//

    }
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("1.- " + -5%1);
        Debug.Log("2.- " + -4 % 1);
        Debug.Log("3.- " + 3 % 1);
        Debug.Log("4.- " + 3 % 1);
        Debug.Log("5.- " + -1 % 1);
    }

    // Update is called once per frame
    void Update()
    {
        c_stm.ConstModify(stMultiplier);
    }


    private void OnEnable()
    {
        inputStm.Enable();
    }
    private void OnDisable()
    {
        inputStm.Disable();
    }
}
