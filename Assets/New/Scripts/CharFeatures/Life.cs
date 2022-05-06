using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Life : MonoBehaviour
{
    [SerializeField]
    public int maxHealth;
    [SerializeField]
    public int actualHealth;
    private SoundActive sounds;


    private void Awake()
    {
        actualHealth = maxHealth;
        if (gameObject.GetComponent<SoundActive>() != null)
        {
            sounds = gameObject.GetComponent<SoundActive>();
        }
    }
    public void ReduceLife(int damage)
    {
        damage = Mathf.Abs(damage);
        if(actualHealth>0)
        {
            actualHealth = actualHealth - damage;
            if (sounds != null)
            {
                sounds.SoundStop(1);
                sounds.SoundPlay(1);
            }
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

    public void MaxLifeTest()
    {
        actualHealth = maxHealth;
    }

}
