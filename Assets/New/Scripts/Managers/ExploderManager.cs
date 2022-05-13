using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExploderManager : MonoBehaviour
{
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
    [Tooltip("La cantidad que reduce la vida del jugador mediante su explosi�n")]
    public int damage;
    [Tooltip("Velocidad normal del enemigo.")]
    public float speed;
    [Tooltip("Tiempo en que se muestra el estado golpeado")]
    public float feedbackMaxTimer;
    [Tooltip("Tiempo que tendr� el charco lenteador.")]
    public float timeLifeSpan;
    [Tooltip("Tiempo en quedarse quieto luego de llegar a un punto de patrulla")]
    public float vigilanceTimer;
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
            StatAlocate();
    }

    void StatAlocate()
    {
        enSenScript.range = frontDetectRange;
        enSenScript.retreatRange = explodeRange;

        enGrdScript.patrolPoint = new GameObject[patrolPoints];
        enLifeScript.feedMaxTimer = feedbackMaxTimer;

        enGrdScript.intel.speed = speed;
        explodeScript.timeLifeSpan = timeLifeSpan;
        explodeScript.damage = damage;
        enGrdScript.patrolMaxTime = vigilanceTimer;
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
}
