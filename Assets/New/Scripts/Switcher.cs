using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switcher : MonoBehaviour
{
    [Tooltip("Lo llaman binary si se puede volver a cambiar")]
    public bool binary;
    [HideInInspector]
    public bool activated;
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
            Debug.Log("A");
        }
        else if (activated && binary)
            activated = false;
    }

}
