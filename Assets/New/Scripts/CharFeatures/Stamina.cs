using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stamina : MonoBehaviour
{
    [SerializeField]
    public float maxStamina;
    [SerializeField]
    public float actStamina;
    public float increaseSpd;

    public bool empty;

    private void Awake()
    {
        actStamina = maxStamina;
        increaseSpd = Mathf.Abs(increaseSpd);
    }
    void Update()
    {
        StaminaIdentify();
    }

    void StaminaIdentify()
    {
        if (actStamina <= 1)
        {
            empty = true;
        }
        else
        {
            empty = false;
        }
    }

    public void SpecificReduse(float amount)
    {
        amount = Mathf.Abs(amount);
        if (actStamina > 0)
        {
            actStamina = actStamina - amount;
        }
    }

    public void ConstModify(float upMultiplier)
    {
        if(upMultiplier > 0 && actStamina < maxStamina || upMultiplier < 0 && actStamina > 0)
        {
            upMultiplier = upMultiplier / Mathf.Abs(upMultiplier);
            actStamina = actStamina + (upMultiplier * Time.deltaTime * increaseSpd);
            
        }
        

    }

    public void IncreaseMaxSt(int plusST)
    {
        plusST = Mathf.Abs(plusST);
        maxStamina += plusST;
    }

}
