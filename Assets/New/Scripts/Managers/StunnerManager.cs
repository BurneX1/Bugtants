using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StunnerManager : MonoBehaviour
{
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
    [Tooltip("Velocidad normal del enemigo.")]
    public float speed;
    [Tooltip("Multiplicador de velocidad al embestir")]
    public float chargeMultiplySpeed;
    [Tooltip("Tiempo en que el enemigo estará aturdido y el tiempo que da al jugador al aturdirlo")]
    public float stunnerTime;
    [Tooltip("Tiempo en que se muestra el estado golpeado")]
    public float feedbackMaxTimer;
    [Tooltip("Rango de espera entre embestidas (no poner valor 0 o explota tu compu).")]
    public float maxTimerScarab;
    [Tooltip("Tiempo en quedarse quieto luego de llegar a un punto de patrulla")]
    public float vigilanceTimer;
    [Tooltip("Tiempo en que se no se olvida de que lo haya disparado")]
    public float takeMaxTimer;

    void Awake()
    {
        enGrdScript.patrolPoint = new GameObject[patrolPoints];
        enGrdScript.savePatrol = new GameObject[patrolPoints];
        enGrdScript.ControlPatrol();
    }
    // Start is called before the first frame update
    void Start()
    {
        enLifeScript.life = life;
        locker = true;
    }

    // Update is called once per frame
    void Update()
    {
        StatAlocate();
        DeathCondition();
    }

    void OnDrawGizmos()
    {
        if (!locker)
        {
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
        enGrdScript.multiplyCharge = chargeMultiplySpeed;
        enGrdScript.chargeDamage = damageStun;

        enLifeScript.feedMaxTimer = feedbackMaxTimer;
        enLifeScript.takeMaxTimer = takeMaxTimer;

        enScbScript.stunnerTime = stunnerTime;
        enScbScript.maxTimer = maxTimerScarab;
        enGrdScript.patrolMaxTime = vigilanceTimer;
    }
    void DeathCondition()
    {
        if (enLifeScript.dead)
        {
            enGrdScript.saveSpeed = 0;
            enGrdScript.enabled = false;
            enSenScript.enabled = false;
            meleeScript.enabled = false;
            enScbScript.enabled = false;
        }
    }
}
