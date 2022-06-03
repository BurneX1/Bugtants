using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlideDynValue : MonoBehaviour
{
    public Slider sld;
    public InputField inpt;
    public void ChngSlideValue(float val)
    {
        if(sld != null)
        {
            sld.value = val;
        }
    }
    public void ChngSlideValue(string val)
    {
        if (sld != null)
        {
            sld.value = float.Parse(val);
        }
    }

    public void ChngInptValue(float val)
    {
        if (sld != null)
        {
            inpt.text = val + "";
        }
    }
    public void ChngInptValue(string val)
    {
        if (sld != null)
        {
            inpt.text = val;
            
        }
    }

    public void EqualizeValues()
    {
        if(sld.value != float.Parse(inpt.text))
        {
            inpt.text = sld.value + "";
        }
    }
}
