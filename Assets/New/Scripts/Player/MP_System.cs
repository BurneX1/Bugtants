using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MP_System : MonoBehaviour
{
    public PlayerView playerHUD;

    //--VALORES--//
    public float actualMP;
    public float maxMP;


    private void Awake()
    {
        actualMP = maxMP;
        playerHUD = GetComponent<PlayerView>();
    }
    public void FullRecharge() { actualMP = maxMP; }
    public void Shotgun() { actualMP -= 10; }
    public void Pistol() { actualMP -= 3; }

    public void ModifyMp(float mpValue)
    { 
        actualMP += mpValue;
        playerHUD.activateHUD = true;
    }
    public void ReduceMP(int amount)
    {
        amount = Mathf.Abs(amount);
        actualMP = actualMP - amount;

        if (actualMP < 0)
        {
            actualMP = 0;
        }
    }

    public void AddMP(int recovery)
    {
        recovery = Mathf.Abs(recovery);
        actualMP = actualMP + recovery;

        if (actualMP > maxMP)
        {
            actualMP = maxMP;
        }
    }


}
