using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New EnemyData", menuName = "Data/EnemyData")]
public class EnemyData : ScriptablePersistentObject
{
    [Header("Base Features")]
    public int life;
    public int damage;
    public float attackRange;
    public float frontDetectRange;
    public int manaReward;
    public float speed;
    public float chaseSpd;

    [Header("Timers & Cooldowns")]
    public float atackTime;
    public float hitFedbckTime;

    public float patrolWaitTime;
    public float waitAtackTime;

    [Space]
    [Space]
    [Space]
    [Header("OCCASIONAL VALUES",order =1)]


    [Header("Range Values",order =2)]
    public float retreatRange;
    public float backSpeed;
    public float bullSpeed;

    [Header("StunnAtack Values")]
    public int stunDamage;
    public float selfStunTime;
    public float stunEfectTime;

    [Header("Tackle Values")]
    public float crashRange;
    public float chargeSpeed;
    public float chargeTime;

    [Header("TimeLife Values")]
    public float timeLifeSpan;
}
