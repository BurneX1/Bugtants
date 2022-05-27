using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttracterManager : MonoBehaviour
{
    [Header("Scripts editables solo para programadores")]
    public EnemyAttract enAttScript;
    public EnemySense enSenScript;
    public EnemyLife enLifeScript;
    private bool locker = false;
    [Header("Scripts editables")]
    [Tooltip("Lineas azules, es la distancia en la que puede detectar al jugador a frente")]
    public float frontDetectRange;
    [Tooltip("Vida del enemigo")]
    public int life;
    [Tooltip("La cantidad que reduce la vida del jugador durante la succion")]
    public int damage;
    [Tooltip("Velocidad de succion.")]
    public float speedSuction;
    [Tooltip("Frecuencia de dano al haber succionado.")]
    public float damageRate;
    [Tooltip("Tiempo en que se muestra el estado golpeado")]
    public float feedbackMaxTimer;
    [Tooltip("Tiempo en que se no se olvida de que lo haya disparado")]
    public float takeMaxTimer;



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

        enAttScript.damage = damage;
        enAttScript.speedSuction = speedSuction;
        enAttScript.damageRate = damageRate;

        enLifeScript.feedMaxTimer = feedbackMaxTimer;
        enLifeScript.takeMaxTimer = takeMaxTimer;

    }
    void DeathCondition()
    {
        if (enLifeScript.dead)
        {
            enAttScript.player.GetComponent<PlayerMovement>().poseser = null;
            enAttScript.enabled = false;
            enSenScript.enabled = false;

        }
    }
}