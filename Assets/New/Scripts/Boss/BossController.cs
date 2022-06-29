using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour
{
    public BossPatrolAttacks bossAttackPrepare;
    public BossAttacks bossAttacker;
    public BossSense bossSense;
    public BossHealthy bossEyes;
    public BossSummoners bossSummon;
    public Detecter bossDeter, itemDestroyer;
    [Tooltip("Temporizador de cambio de ojo")]
    public float eyesMaxTimer;
    [Tooltip("Temporizador de ataques")]
    public float attackMaxTime;
    private float eyesTimer, attackTime;
    // Update is called once per frame
    void Awake()
    {
        attackTime = 0;
        eyesTimer = 0;
    }

    void Update()
    {
        if (bossEyes.activated && !bossEyes.dead)
        {
            Activations();
            FinishingAttacks();
            BossEyeTransgoing();
            PreparingAttacks();
            ItemChecker();
        }
        else
        {
            Detection();
        }
    }
    void Detection()
    {
        if (bossDeter.touch && !bossEyes.dead)
        {
            bossEyes.Detect();
        }
    }
    void Activations()
    {
        bossSummon.BossBell();
        switch (bossAttackPrepare.numberNow)
        {
            case 1:
                bossAttacker.Attack_01(bossSense);
                break;
            case 2:
                bossAttacker.Attack_02(bossSense);
                break;
            case 3:
                bossAttacker.Attack_03();
                break;
            case 4:
                bossAttacker.Attack_04(bossSense);
                break;
            case 5:
                bossAttacker.Attack_05(bossSense);
                break;
            case 6:
                bossAttacker.Attack_06(bossSense);
                break;

        }
    }

    void FinishingAttacks()
    {
        if(bossAttackPrepare.numberNow!=0&& bossAttacker.step == -1)
        {
            bossAttackPrepare.numberNow = 0;
            bossSummon.Summoners();
            bossAttacker.step = 0;
        }
    }
    void BossEyeTransgoing()
    {
        if (bossEyes.deadReset)
        {
            eyesTimer = 0;
        }
        eyesTimer += Time.deltaTime;
        if (eyesTimer >= eyesMaxTimer)
        {
            bossEyes.CountEyes();
            eyesTimer = 0;
        }
        if (bossEyes.eyes.Length == 0 && !bossAttackPrepare.rage)
        {
            bossAttackPrepare.rage = true;
        }
    }
    void PreparingAttacks()
    {
        if (bossAttackPrepare.numberNow == 0)
        {
            attackTime += Time.deltaTime;
            if (attackTime >= attackMaxTime)
            {
                bossAttackPrepare.NumberMulligan();
                attackTime = 0;
            }
        }
    }
    void ItemChecker()
    {
        if (itemDestroyer.touch)
        {
            itemDestroyer.registeredObject.transform.gameObject.tag = "Untagged";
            bossSummon.items.Checker(itemDestroyer.registeredObject);
        }
    }
}
