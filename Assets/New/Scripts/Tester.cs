using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Tester : MonoBehaviour
{
    InputSystemActions inputStm;
    bool running;
    // Start is called before the first frame update
    void Awake()
    {
        inputStm = new InputSystemActions();
        inputStm.GamePlay.Run.performed += ctx => running = true;
        inputStm.GamePlay.Run.canceled += ctx => running = false;

    }

    // Update is called once per frame
    void Update()
    {
        if (running)
        {
            Debug.Log("Corre");
        }
        else
        {
            Debug.Log("No corre");
        }
    }
    void Test()
    {
        Debug.Log("Salta");
    }

    void Testing()
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
