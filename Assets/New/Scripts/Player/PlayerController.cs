using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private InputSystemActions inputStm;
    private FrontRayCaster c_ray;

    void Awake()
    {
        //Component Settup -----------//
        c_ray = gameObject.GetComponent<FrontRayCaster>();
        //-------------------------<<<//


        //Input System Setup----------//
        inputStm = new InputSystemActions();

        inputStm.GamePlay.Interact.performed += _ => c_ray.Interact();
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
