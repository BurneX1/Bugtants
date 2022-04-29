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

    void Awake()
    {
        //Component Settup -----------//
        c_ray = gameObject.GetComponent<FrontRayCaster>();
        c_life = gameObject.GetComponent<Life>();
        c_mp = gameObject.GetComponent<MP_System>();
        //-------------------------<<<//


        //Input System Setup----------//
        inputStm = new InputSystemActions();

        inputStm.GamePlay.Interact.performed += _ => c_ray.Interact();
        inputStm.GamePlay.Interact.performed += _ => Debug.Log("KeyPress");
        inputStm.GamePlay.Crouch.performed += ctx => Debug.Log(ctx);
        //-------------------------<<<//

    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
