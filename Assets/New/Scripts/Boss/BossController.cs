using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour
{
    public BossPatrolAttacks bossAttackPrepare;
    public BossAttacks bossAttacker;
    public BossSense bossSense;
    public BossEyes bossEyes;
    [Tooltip("Temporizador de cambio de ojo")]
    public float eyesMaxTimer;
    private float eyesTimer;
    // Update is called once per frame
    void Awake()
    {
        eyesTimer = 0;
    }

    void Update()
    {
        Activations();
        FinishingAttacks();
        BossEyeTransgoing();
    }

    void Activations()
    {
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

    }
}
