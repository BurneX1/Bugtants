using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MP_System : MonoBehaviour
{
    //--VALORES--//
    public float actualMP;
    public float maxMP;
    public Text mp_Text;
    public Image mp_Indicator;


    public void FullRecharge() { actualMP = 100; }
    public void BasicAttack() { actualMP -= 10; }

}
