using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MidDistanceManager : MonoBehaviour
{
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
    [Tooltip("Rango de espera entre disparos (no poner valor 0 o explota tu compu).")]
    public float maxTimer;
    [Tooltip("Velocidad de la bala).")]
    public float bullSpeed;
    [Tooltip("Velocidad normal del enemigo.")]
    public float speed;
    [Tooltip("Velocidad del retroceso del enemigo.")]
    public float backSpeed;
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
        if(!locker)
        StatAlocate();
    }

    void StatAlocate()
    {
        enSenScript.range = frontDetectRange;
        enSenScript.quietRange = idleRange;
        enSenScript.retreatRange = retreatRange;

        enGrdScript.patrolPoint = new GameObject[patrolPoints];

        enLifeScript.life = life;

        enMidScript.maxTimer = maxTimer;
        enMidScript.bulletSpeed = bullSpeed;

        enGrdScript.intel.speed = speed;
        enGrdScript.backSpeed = backSpeed;
    }
}
