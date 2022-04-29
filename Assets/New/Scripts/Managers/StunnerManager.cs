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
    [Tooltip("Rango de espera entre golpes (no poner valor 0 o explota tu compu).")]
    public float maxTimer;
    [Tooltip("Velocidad normal del enemigo.")]
    public float speed;
    [Tooltip("Tiempo en que el enemigo estará aturdido y el tiempo que da al jugador al aturdirlo")]
    public float stunnerTime;
    [Tooltip("Rango de espera entre embestidas (no poner valor 0 o explota tu compu).")]
    public float maxTimerScarab;
    // Start is called before the first frame update
    void Start()
    {
        locker = true;
    }

    // Update is called once per frame
    void Update()
    {
        StatAlocate();
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
        enSenScript.crashRange = crashRange;
        enGrdScript.patrolPoint = new GameObject[patrolPoints];

        enLifeScript.life = life;
        meleeScript.maxTimer = maxTimer;
        enGrdScript.saveSpeed = speed;


        enScbScript.stunnerTime = stunnerTime;
        enScbScript.maxTimer = maxTimerScarab;
    }
}
