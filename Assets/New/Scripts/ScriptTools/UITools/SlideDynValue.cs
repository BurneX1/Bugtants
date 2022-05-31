using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlideDynValue : MonoBehaviour
{
    public Slider sld;
    public void ChnglideValue(float val)
    {
        if(sld != null)
        {
            sld.value = val;
        }
    }
    public void ChnglideValue(string val)
    {
        if (sld != null)
        {
            sld.value = float.Parse(val);
        }
    }
}
