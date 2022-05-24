using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Life : MonoBehaviour
{    
    public int maxHealth;
    public int actualHealth;

    private void Awake()
    {
        actualHealth = maxHealth;
    }

    public void ReduceLife(int damage)
    {
        damage = Mathf.Abs(damage);
        if (actualHealth > 0) actualHealth -= damage;
        if (actualHealth < 0) actualHealth = 0;
    }

    public void AddLife(int recovery)
    {
        recovery = Mathf.Abs(recovery);
        actualHealth = actualHealth + recovery;

        if (actualHealth > maxHealth)
        {
            actualHealth = maxHealth;
        }
    }

    public void IncreaseMaxLife(int plusLife)
    {
        plusLife = Mathf.Abs(plusLife);
        maxHealth += plusLife;
    }

    public void TotalRecovery()
    {
        actualHealth = maxHealth;
    }

}
