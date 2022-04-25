using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MP_System : MonoBehaviour
{
    //--VALORES--//
    public float ActualMP;
    public float MaxMP;
    public Text mp_Text;
    public Image mp_Indicator;

    void Start()
    {
        MaxMP = 100;
        ActualMP = MaxMP;
    }

    void Update()
    {
        mp_Text.text = "" + ActualMP;
        mp_Indicator.fillAmount = ActualMP/MaxMP; 
    }

    public void FullRecharge() { ActualMP = 100; }
    public void BasicAttack() { ActualMP -= 10; }

}
