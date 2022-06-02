using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switcher : MonoBehaviour
{
    private InputSystemActions inputStm;

    [Tooltip("Lo llaman binary si se puede volver a cambiar")]
    public bool binary;
    [HideInInspector]
    public bool activated, located;
    public bool changecolor;

    public Light[] lightColorChange;
    public Color[] colorList;

    public GameObject[] Status_0, Status_1;
    // Start is called before the first frame update
    void Awake()
    {
        inputStm = new InputSystemActions();
        activated = false;
        inputStm.GamePlay.Interact.performed += ctx => DoingActivate();
    }
    void DoingActivate()
    {
        if (located) 
            Activation();
    }
    public void Activation()
    {
        if (!activated)
        {
            activated = true;
            if (Status_0.Length != 0)
            {
                foreach (GameObject off in Status_0)
                {
                    off.SetActive(false);
                }
                /*
                for (int i = 0; i < Status_0.Length; i++)
                {
                    Status_0[i].SetActive(false);  
                }
                */
                if (Status_1.Length != 0)
                {
                    foreach (GameObject on in Status_1)
                    {
                        on.SetActive(true);
                    }
                    /*
                    for (int i = 0; i < Status_1.Length; i++)
                    { Status_1[i].SetActive(true); }
                    */
                }
            }
        }
        else if (activated && binary)
        {
            activated = false;
        }

        if (changecolor)
        {
            LogChangeColor();
        }
        else { Debug.Log("change color off"); }
    }
    public void LogChangeColor()
    {
        if (lightColorChange.Length != 0)
        {
            if (colorList.Length != 0)
            {
                for (int i = 0; i < lightColorChange.Length; i++)
                { lightColorChange[i].color = colorList[i]; }
            }
            else { Debug.LogError("No assign Colors"); }
        }
        else { Debug.LogError("No LightColors"); }
    }
    private void OnEnable()
    {
        inputStm.Enable();
    }
    private void OnDisable()
    {
        inputStm.Disable();
    }
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            located = true;
        }
    }

    void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            located = false;
        }
    }
}
