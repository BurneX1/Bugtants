using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    private InputSystemActions inputStm;
    public bool grab;
    public Detecter detect;
    void Awake()
    {
        inputStm = new InputSystemActions();
        inputStm.GamePlay.Interact.canceled += ctx => grab = false;
        inputStm.GamePlay.Interact.performed += ctx => grab = true;
    }

    void Update()
    {
        Detecting();
    }
    void Detecting()
    {
        if (detect.touch && grab)
        {
            Destroy(gameObject);
        }
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
