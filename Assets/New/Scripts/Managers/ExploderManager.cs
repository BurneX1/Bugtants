using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExploderManager : MonoBehaviour
{
    [Header("Scripts editables solo para programadores")]
    public EnemyGroundMove enGrdScript;
    public EnemySense enSenScript;
    public EnemyLife enLifeScript;
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
    [Tooltip("Velocidad normal del enemigo.")]
    public float speed;
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
        enSenScript.retreatRange = explodeRange;

        enGrdScript.patrolPoint = new GameObject[patrolPoints];

        enLifeScript.life = life;

        enGrdScript.intel.speed = speed;
    }
}
