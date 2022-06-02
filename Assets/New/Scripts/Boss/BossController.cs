using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour
{
    public BossPatrolAttacks bossAttackPrepare;
    public BossAttacks bossAttacker;
    public BossSense bossSense;
    public BossEyes bossEyes;
    // Update is called once per frame
    void Update()
    {
        Activations();
    }

    void Activations()
    {
        switch (bossAttackPrepare.numberNow)
        {
            case 1:
                bossAttacker.Attack_01(bossSense);
                break;
            case 2:
                bossAttacker.Attack_02();
                break;
            case 3:
                bossAttacker.Attack_03();
                break;
            case 4:
                bossAttacker.Attack_04();
                break;
            case 5:
                bossAttacker.Attack_05();
                break;
            case 6:
                bossAttacker.Attack_06();
                break;

        }
    }
}
