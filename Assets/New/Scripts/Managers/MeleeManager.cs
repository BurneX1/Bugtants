using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeManager : MonoBehaviour
{
    public  EnemyData enmyData;

    [Header("Scripts editables solo para programadores")]
    public EnemyGroundMove enGrdScript;
    public EnemySense enSenScript;
    public EnemyLife enLifeScript;
    public MeleeAttack meleeScript;
    private bool locker = false;
    [Header("Scripts editables")]
    [Tooltip("Lineas azules, es la distancia en la que puede detectar al jugador a frente")]
    public float frontDetectRange;
    [Tooltip("Circulo celeste, es el rango en donde va a explotar")]
    public float attackRange;
    [Tooltip("Puntos de patrullaje del enemigo, si es 0, entonces se queda parado en su lugar, al no ser asi, entonces se queda parado en su mismo punto de patrullaje")]
    public int patrolPoints;
    [Tooltip("Vida del enemigo")]
    public int life;
    [Tooltip("La cantidad que reduce la vida del jugador al golpear")]
    public int damage;
    [Tooltip("Rango de espera entre golpes (no poner valor 0 o explota tu compu).")]
    public float maxTimer;
    [Tooltip("Tiempo en que se muestra el estado golpeado")]
    public float feedbackMaxTimer;
    [Tooltip("Velocidad del enemigo al patrullar.")]
    public float speed;
    [Tooltip("Velocidad del enemigo al perseguir.")]
    public float chaseSpeed;
    [Tooltip("Tiempo en quedarse quieto luego de llegar a un punto de patrulla")]
    public float vigilanceTimer;
    [Tooltip("Tiempo en que se no se olvida de que lo haya disparado")]
    public float takeMaxTimer;
    [Tooltip("Tiempo en que se queda quieto luego de atacar")]
    public float quietTime;
    [Tooltip("Tiempo en que aun se acuerda al jugador")]
    public float chaseModeMaxTimer;
    [Tooltip("Cantidad de MP que da al jugador cuando el enemigo muere, en caso ser Withered Mothman, entonces el daño que da su humo")]
    public int giftQuantity;
    [Tooltip("Tiempo en que el enemigo se aturde al recibir ataque, recomendable en decimales")]
    public float receiveMaxTimer;

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
        if (!enLifeScript.dead)
        {
            enSenScript.range = frontDetectRange;
            enSenScript.quietRange = attackRange;

            enLifeScript.feedMaxTimer = feedbackMaxTimer;
            enLifeScript.takeMaxTimer = takeMaxTimer;
            enLifeScript.giftQuantity = giftQuantity;

            meleeScript.maxTimer = maxTimer;
            meleeScript.damage = damage;

            enGrdScript.saveSpeed = speed;
            enGrdScript.patrolMaxTime = vigilanceTimer; 
            enGrdScript.maxDelay = quietTime;
            enGrdScript.chaseSpeed = chaseSpeed;
            enGrdScript.chasingMaxTime = chaseModeMaxTimer;
            enGrdScript.receiveMaxTime = receiveMaxTimer;

        }
    }
    void DeathCondition()
    {
        if (enLifeScript.dead)
        {
            enGrdScript.intel.speed = 0;
            enGrdScript.enabled = false;
            enSenScript.enabled = false;
            meleeScript.enabled = false;
            enGrdScript.intel.speed = 0;

        }
    }

    void LoadData()
    {
        if(enmyData != null)
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
