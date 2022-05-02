using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeManager : MonoBehaviour
{
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
    [Tooltip("Velocidad normal del enemigo.")]
    public float speed;
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
        enSenScript.quietRange = attackRange;

        enGrdScript.patrolPoint = new GameObject[patrolPoints];
        enLifeScript.feedMaxTimer = feedbackMaxTimer;

        meleeScript.maxTimer = maxTimer;
        meleeScript.damage = damage;
        enGrdScript.intel.speed = speed;
    }
    void DeathCondition()
    {
        if (enLifeScript.dead)
        {
            enGrdScript.saveSpeed = 0;
            enGrdScript.enabled = false;
            enSenScript.enabled = false;
            meleeScript.enabled = false;

        }
    }
}
