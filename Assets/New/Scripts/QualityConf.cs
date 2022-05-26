using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class QualityConf : MonoBehaviour
{
    public Dropdown qualityDpdn;

    void Start()
    {
        QualityChange(); 
    }

    public void QualityChange()
    {
        QualitySettings.SetQualityLevel(qualityDpdn.value);
        Debug.Log(qualityDpdn.value);
    }
}
