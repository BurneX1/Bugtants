using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StunnerManager : MonoBehaviour
{
    public EnemyData enmyData;

    [Header("Scripts editables solo para programadores")]
    public EnemyGroundMove enGrdScript;
    public EnemyScarab enScbScript;
    public EnemySense enSenScript;
    public EnemyLife enLifeScript;
    public MeleeAttack meleeScript;

    private bool locker = false;
    [Header("Scripts editables")]
    [Tooltip("Lineas azules, es la distancia en la que puede detectar al jugador a frente")]
    public float frontDetectRange;
    [Tooltip("Circulo celeste, es el rango en donde va a explotar")]
    public float attackRange;
    [Tooltip("Circulo amarillo, es el rango en donde va a preparar la embestida")]
    public float crashRange;
    [Tooltip("Puntos de patrullaje del enemigo, si es 0, entonces se queda parado en su lugar, al no ser asi, entonces se queda parado en su mismo punto de patrullaje")]
    public int patrolPoints;
    [Tooltip("Vida del enemigo")]
    public int life;
    [Tooltip("La cantidad que reduce la vida del jugador al golpear")]
    public int damage;
    [Tooltip("La cantidad que reduce la vida del jugador al embestir")]
    public int damageStun;
    [Tooltip("Rango de espera entre golpes (no poner valor 0 o explota tu compu).")]
    public float maxTimer;
    [Tooltip("Velocidad del enemigo al patrullar.")]
    public float speed;
    [Tooltip("Velocidad del enemigo al perseguir.")]
    public float chaseSpeed;
    [Tooltip("Velocidad de embestida")]
    public float chargeSpeed;
    [Tooltip("Tiempo en que el enemigo estar? aturdido")]
    public float stunnedTime;
    [Tooltip("Tiempo en que se muestra el estado golpeado")]
    public float feedbackMaxTimer;
    [Tooltip("Rango de espera entre embestidas (no poner valor 0 o explota tu compu).")]
    public float maxTimerScarab;
    [Tooltip("Tiempo en quedarse quieto luego de llegar a un punto de patrulla")]
    public float vigilanceTimer;
    [Tooltip("Tiempo en que se no se olvida de que lo haya disparado")]
    public float takeMaxTimer;
    [Tooltip("Tiempo en que se queda quieto luego de atacar")]
    public float quietTime;
    [Tooltip("Tiempo en que el jugador sea stuneado luego de atacar")]
    public float stunTime;
    [Tooltip("Tiempo en que aun se acuerda al jugador")]
    public float chaseModeMaxTimer;
    [Tooltip("Cantidad de MP que da al jugador cuando el enemigo muere")]
    public int giftQuantity;
    [Tooltip("Tiempo en que el enemigo se aturde al recibir ataque, recomendable en decimales")]
    public float receiveMaxTimer;

    public bool saveBlocker = false;
    private bool updateStarter, awakeStarted;
    void Awake()
    {
        awakeStarted = false;
        updateStarter = false;
    }
    // Update is called once per frame
    void Update()
    {
        if (enGrdScript.loaded && updateStarter)
        {
            StatAlocate();
            DeathCondition();
        }
        if (enGrdScript.loaded && !awakeStarted)
        {
            StartCoroutine(WhenLoading());
            awakeStarted = true;
        }
    }
    IEnumerator WhenLoading()
    {
        if (!saveBlocker)
        {
            enGrdScript.patrolPoint = new GameObject[patrolPoints];
            enGrdScript.savePatrol = new GameObject[patrolPoints];
            enGrdScript.ControlPatrol();
        }
        else
        {
            enGrdScript.patrolPoint = new GameObject[patrolPoints];
            enGrdScript.savePatrol = new GameObject[patrolPoints];
        }

        saveBlocker = true;
        yield return new WaitForSeconds(0.01f);
        enLifeScript.life = life;
        locker = true;
        yield return new WaitForSeconds(0.01f);
        updateStarter = true;
    }
    void OnDrawGizmos()
    {
        if (!locker)
        {
            saveBlocker = false;
            StatAlocate();
            enGrdScript.patrolPoint = new GameObject[patrolPoints];
            enGrdScript.savePatrol = new GameObject[patrolPoints];
            enGrdScript.Modifying();
        }

    }

    void StatAlocate()
    {
        enSenScript.range = frontDetectRange;
        enSenScript.quietRange = attackRange;
        enSenScript.crashRange = crashRange;

        meleeScript.damage = damage;
        meleeScript.maxTimer = maxTimer;

        enGrdScript.saveSpeed = speed;
        enGrdScript.chargeSpeed = chargeSpeed;
        enGrdScript.chargeDamage = damageStun;
        enGrdScript.maxDelay = quietTime;
        enGrdScript.stunTimer = stunTime;
        enGrdScript.chaseSpeed = chaseSpeed;
        enGrdScript.patrolMaxTime = vigilanceTimer;
        enGrdScript.chasingMaxTime = chaseModeMaxTimer;
        enGrdScript.receiveMaxTime = receiveMaxTimer;

        enLifeScript.feedMaxTimer = feedbackMaxTimer;
        enLifeScript.takeMaxTimer = takeMaxTimer;
        enLifeScript.giftQuantity = giftQuantity;

        enScbScript.stunnerTime = stunnedTime;
        enScbScript.maxTimer = maxTimerScarab;
    }
    void DeathCondition()
    {
        if (enLifeScript.dead)
        {
            enGrdScript.intel.speed = 0;
            enGrdScript.enabled = false;
            enSenScript.enabled = false;
            meleeScript.enabled = false;
            enScbScript.enabled = false;
            enGrdScript.intel.speed = 0; 
            enLifeScript.enabled = false;
        }
    }

    void LoadData()
    {
        if (enmyData != null)
        {
            life = enmyData.life;
            damage = enmyData.damage;
            attackRange = enmyData.attackRange;
            frontDetectRange = enmyData.frontDetectRange;
            speed = enmyData.speed;
            chaseSpeed = enmyData.chaseSpd;
            giftQuantity = enmyData.manaReward;

            maxTimer = enmyData.atackTime;
            feedbackMaxTimer = enmyData.hitFedbckTime;
            vigilanceTimer = enmyData.patrolWaitTime;
            quietTime = enmyData.waitAtackTime;

            crashRange = enmyData.crashRange;
            damageStun = enmyData.stunDamage;
            chargeSpeed = enmyData.chargeSpeed;
            stunnedTime = enmyData.selfStunTime;
            stunTime = enmyData.stunEfectTime;
            maxTimerScarab = enmyData.chargeTime;
            chaseModeMaxTimer = enmyData.chaseModeTime;
            receiveMaxTimer = enmyData.receiveMaxTime;
        }
    }

    private void OnEnable()
    {
        if (enmyData != null)
        {
            enmyData.Refresh += LoadData;
        }
    }

    private void OnDisable()
    {
        if (enmyData != null)
        {
            enmyData.Refresh -= LoadData;
        }
    }
}
