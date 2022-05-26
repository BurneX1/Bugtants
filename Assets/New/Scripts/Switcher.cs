using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switcher : MonoBehaviour
{
    [Tooltip("Lo llaman binary si se puede volver a cambiar")]
    public bool binary;
    [HideInInspector]
    public bool activated;

    public Light[] LightColorChange;

    public GameObject[] Status_0, Status_1;
    // Start is called before the first frame update
    void Start()
    {
        activated = false;
    }
    public void Activation()
    {
        if (!activated)
        {
            activated = true;
            for (int i = 0; i < Status_0.Length; i++)
            { Status_0[i].SetActive(false); ; }

            for (int i = 0; i < Status_1.Length; i++)
            { Status_1[i].SetActive(true); }

            if(LightColorChange.Length!= 0)
            {
                for (int i = 0; i < LightColorChange.Length; i++)
                { LightColorChange[i].color = Color.green; }
            }
            Debug.Log("A");
        }
        else if (activated && binary)
            activated = false;
    }

}
