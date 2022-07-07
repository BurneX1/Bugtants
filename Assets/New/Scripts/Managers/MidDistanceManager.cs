using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MidDistanceManager : MonoBehaviour
{
    public EnemyData enmyData;

    [Header("Scripts editables solo para programadores")]
    public EnemyMidDistance enMidScript;
    public EnemyGroundMove enGrdScript;
    public EnemySense enSenScript;
    public EnemyLife enLifeScript;
    private bool locker=false;
    [Header("Scripts editables")]
    [Tooltip("Lineas azules, es la distancia en la que puede detectar al jugador a frente")]
    public float frontDetectRange;
    [Tooltip("Circulo celeste, es el rango en donde dispara y se queda quieto, tiene que ser mayor al retreatRange")]
    public float idleRange;
    [Tooltip("Circulo rosado, es el rango en donde dispara y retrocede, Tiene que ser menor al idleRange")]
    public float retreatRange;
    [Tooltip("Puntos de patrullaje del enemigo, si es 0, entonces se queda parado en su lugar, al no ser asi, entonces se queda parado en su mismo punto de patrullaje")]
    public int patrolPoints;
    [Tooltip("Vida del enemigo")]
    public int life;
    [Tooltip("La cantidad que sus balas reduce la vida del jugador")]
    public int damage;
    [Tooltip("Rango de espera entre disparos (no poner valor 0 o explota tu compu).")]
    public float maxTimer;
    [Tooltip("Velocidad de la bala.")]
    public float bullSpeed;
    [Tooltip("Velocidad del enemigo al patrullar.")]
    public float speed;
    [Tooltip("Velocidad del enemigo al perseguir.")]
    public float chaseSpeed;
    [Tooltip("Tiempo en que se muestra el estado golpeado")]
    public float feedbackMaxTimer;
    [Tooltip("Velocidad del retroceso del enemigo.")]
    public float backSpeed;
    [Tooltip("Tiempo en quedarse quieto luego de llegar a un punto de patrulla")]
    public float vigilanceTimer;
    [Tooltip("Tiempo en que se no se olvida de que lo haya disparado")]
    public float takeMaxTimer;
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
            enGrdScript.CheckpointControlPatrol();
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
        enSenScript.quietRange = idleRange;
        enSenScript.retreatRange = retreatRange;



        enMidScript.maxTimer = maxTimer;
        enMidScript.bulletSpeed = bullSpeed;
        enMidScript.damage = damage;

        enLifeScript.feedMaxTimer = feedbackMaxTimer;
        enLifeScript.takeMaxTimer = takeMaxTimer;
        enLifeScript.giftQuantity = giftQuantity;

        enGrdScript.saveSpeed = speed;
        enGrdScript.backSpeed = backSpeed;
        enGrdScript.patrolMaxTime = vigilanceTimer;
        enGrdScript.chaseSpeed = chaseSpeed;
        enGrdScript.chasingMaxTime = chaseModeMaxTimer;
        enGrdScript.receiveMaxTime = receiveMaxTimer;

    }
    void DeathCondition()
    {
        if (enLifeScript.dead)
        {
            enGrdScript.intel.speed = 0;
            enGrdScript.enabled = false;
            enSenScript.enabled = false;
            enMidScript.enabled = false;
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
            idleRange = enmyData.attackRange;
            frontDetectRange = enmyData.frontDetectRange;
            speed = enmyData.speed;
            chaseSpeed = enmyData.chaseSpd;
            giftQuantity = enmyData.manaReward;

            maxTimer = enmyData.atackTime;
            feedbackMaxTimer = enmyData.hitFedbckTime;
            vigilanceTimer = enmyData.patrolWaitTime;

            retreatRange = enmyData.retreatRange;
            backSpeed = enmyData.backSpeed;
            bullSpeed = enmyData.bullSpeed;
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
