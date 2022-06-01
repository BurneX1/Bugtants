using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switcher : MonoBehaviour
{
    [Tooltip("Lo llaman binary si se puede volver a cambiar")]
    public bool binary;
    [HideInInspector]
    public bool activated;
    public bool changecolor;

    public Light[] lightColorChange;
    public Color[] colorList;

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
            if (changecolor)
            {
                LogChangeColor();
            }
        }
        else if (activated && binary)
            activated = false;
    }

    public void LogChangeColor ()
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
}
