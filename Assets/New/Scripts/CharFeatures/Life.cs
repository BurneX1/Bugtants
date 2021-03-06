using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;

public class Life : MonoBehaviour
{
    public PlayerView playerHUD;
    public event Action Damage = delegate { };
    public bool inmortal;
    public int maxHealth;
    public int actualHealth;
    [HideInInspector]
    public bool damaged;
    public UnityEvent damageTaken;
    private void Awake()
    {
        damaged = false;
        if (actualHealth > maxHealth || actualHealth == 0)
        {
            actualHealth = maxHealth;
        }
        playerHUD = GetComponent<PlayerView>();
    }

    public void ReduceLife(int damage)
    {
        if (!inmortal)
        {
            damage = Mathf.Abs(damage);
            if (actualHealth > 0) actualHealth -= damage;
            if (actualHealth < 0) actualHealth = 0;

            if (playerHUD != null)
            {
                damaged = true;
                playerHUD.activateHUD = true;
                Damage.Invoke();
            }
            damageTaken.Invoke();
        }
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
