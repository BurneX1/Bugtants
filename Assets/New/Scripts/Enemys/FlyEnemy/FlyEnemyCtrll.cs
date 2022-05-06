using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyEnemyCtrll : MonoBehaviour
{
    private AIMovement c_mov;

    private void Awake()
    {
        
    }
    // Start is called before the first frame update
    void Start()
    {
        //Component Settup -----------//
        c_mov = gameObject.GetComponent<AIMovement>();
        //-------------------------<<<//
    }

    // Update is called once per frame
    void Update()
    {
        c_mov.Patrol();
    }
}
