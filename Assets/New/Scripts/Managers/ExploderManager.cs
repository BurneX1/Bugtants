using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExploderManager : MonoBehaviour
{
    public EnemyData enmyData;

    [Header("Scripts editables solo para programadores")]
    public EnemyGroundMove enGrdScript;
    public EnemySense enSenScript;
    public EnemyLife enLifeScript;
    public Exploder explodeScript;
    private bool locker = false;
    [Header("Scripts editables")]
    [Tooltip("Lineas azules, es la distancia en la que puede detectar al jugador a frente")]
    public float frontDetectRange;
    [Tooltip("Circulo rosado, es el rango en donde va a explotar")]
    public float explodeRange;
    [Tooltip("Puntos de patrullaje del enemigo, si es 0, entonces se queda parado en su lugar, al no ser asi, entonces se queda parado en su mismo punto de patrullaje")]
    public int patrolPoints;
    [Tooltip("Vida del enemigo")]
    public int life;
    [Tooltip("La cantidad que reduce la vida del jugador mediante su explosión")]
    public int damage;
    [Tooltip("Velocidad del enemigo al patrullar.")]
    public float speed;
    [Tooltip("Velocidad del enemigo al perseguir.")]
    public float chaseSpeed;
    [Tooltip("Tiempo en que se muestra el estado golpeado")]
    public float feedbackMaxTimer;
    [Tooltip("Tiempo que tendrá el charco lenteador.")]
    public float timeLifeSpan;
    [Tooltip("Tiempo en quedarse quieto luego de llegar a un punto de patrulla")]
    public float vigilanceTimer;
    [Tooltip("Tiempo en que se no se olvida de que lo haya disparado")]
    public float takeMaxTimer;
    [Tooltip("Tiempo en que aun se acuerda al jugador")]
    public float chaseModeMaxTimer;
    [Tooltip("Cantidad de MP que da al jugador cuando el enemigo muere")]
    public int giftQuantity;

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
        enSenScript.retreatRange = explodeRange;

        enLifeScript.feedMaxTimer = feedbackMaxTimer;
        enLifeScript.takeMaxTimer = takeMaxTimer;
        enLifeScript.giftQuantity = giftQuantity;

        explodeScript.timeLifeSpan = timeLifeSpan;
        explodeScript.damage = damage;

        enGrdScript.saveSpeed = speed;
        enGrdScript.patrolMaxTime = vigilanceTimer;
        enGrdScript.chaseSpeed = chaseSpeed;
        enGrdScript.chasingMaxTime = chaseModeMaxTimer;

    }
    void DeathCondition()
    {
        if (enLifeScript.dead)
        {
            enGrdScript.saveSpeed = 0;
            enGrdScript.enabled = false;
            enSenScript.enabled = false;
            explodeScript.enabled = false;

        }
    }

    void LoadData()
    {
        if (enmyData != null)
        {
            life = enmyData.life;
            damage = enmyData.damage;
            explodeRange = enmyData.attackRange;
            frontDetectRange = enmyData.frontDetectRange;
            speed = enmyData.speed;
            chaseSpeed = enmyData.chaseSpd;
            giftQuantity = enmyData.manaReward;


            feedbackMaxTimer = enmyData.hitFedbckTime;
            vigilanceTimer = enmyData.patrolWaitTime;

            timeLifeSpan = enmyData.timeLifeSpan;
            chaseModeMaxTimer = enmyData.chaseModeTime;
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
