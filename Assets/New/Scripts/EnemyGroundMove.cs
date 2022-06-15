using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyGroundMove : MonoBehaviour
{
    public NavMeshAgent intel;
    public GameObject modelsee;

    public float patrolMaxTime, stunTimer, chasingMaxTime;
    //public ValorSalud valores;
    public bool instantChase;
    [HideInInspector]
    public bool calm, stunned, charge, touch, moving, attacking;
    [HideInInspector]
    public int statNumber;
    // chasing = 0, patrolling = 1, retreating = 2, looking = 3, charging = 4, waiting = 5

    public enum Status { patrolling, chasing, retreating, looking, charging, waiting };
    public Status stat;
    [HideInInspector]
    public float saveSpeed, backSpeed, chaseSpeed, saveAcc, saveLife, stunnedMaxTimer, charging = 1, chargeSpeed, maxDelay;
    private float stunnedTimer, patrolTimer, waitTimer, chasingTime;
    public EnemySense radium;
    private int pinner, marker;
    public int chargeDamage;
    public GameObject moveSound;
    public GameObject[] patrolPoint;
    public GameObject patroller;
    private int pastPatrol, patrolNumber, proximity;
    public GameObject[] savePatrol;
    public Detecter detectPatrol;
    private bool chaseMode;
    private bool locker = true, lockerDraw = false;

    public Animator animator;

    public WaysToSound waysWalk, waysIdle, waysCharge;
    // Start is called before the first frame update
    void Start()
    {
        /*
        if (valores != null)
        {
            guardarVida = valores.vida;
        }*/
        chaseMode = false;
        chasingTime = 0;
        attacking = false;
        charging = 1;
        stunnedTimer = 0;
        waitTimer = 0;
        pinner = 0;
        marker = 0;
        charge = false;
        stunned = false;
        if (patrolPoint.Length != 0)
        {
            ControlPatrol();
        }
        lockerDraw = true;
        patrolNumber = 0;
        saveAcc = intel.acceleration;
        patroller.transform.parent = null;
        locker = true;
        patrolTimer = 0;
        if (gameObject.GetComponent<SoundActive>() != null)
        {
            waysWalk.sounds = gameObject.GetComponent<SoundActive>();
            waysIdle.sounds = gameObject.GetComponent<SoundActive>();
            waysCharge.sounds = gameObject.GetComponent<SoundActive>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (radium != null)
        {
            if (radium.objetive != null)
            {
                if (!stunned)
                {
                    if (!charge)
                    {
                        Movement();
                    }
                    else
                    {
                        Charge();
                    }
                    if(intel.autoRepath)
                    Look();
                }
                else
                {
                    Stunned();
                }
                Animate();
            }
        }
    }

    void Movement()
    {
        marker = 0;


        if (stat == Status.patrolling && !touch)
        {
            if (patrolPoint.Length == 0)
            {
                moving = false;
            }
            else
            {
                moving = true;
            }
            intel.speed = saveSpeed * charging;
            intel.autoRepath = true;
            pinner = 0;
            modelsee.transform.eulerAngles = gameObject.transform.eulerAngles;
            if (patrolNumber > patrolPoint.Length - 1)
            {
                patrolNumber = 0;
                proximity = patrolNumber + 1;
                if (proximity > patrolPoint.Length - 1)
                {
                    proximity = 0;
                }
            }
            if (patrolPoint.Length != 0)
            {
                intel.SetDestination(patrolPoint[patrolNumber].transform.position);
                if (patrolPoint[patrolNumber] == detectPatrol.registeredObject)
                {
                    touch = true;
                }
            }
            else
            {
                intel.SetDestination(transform.position);
            }

        }
        else if (stat == Status.patrolling && touch)
        {
            moving = false;
            intel.speed = 0;
            patrolTimer += Time.deltaTime;
            if (patrolTimer >= patrolMaxTime)
            {
                patrolNumber += 1;
                patrolTimer = 0;
                charging = 1;
                touch = false;
            }

        }
        else if (stat == Status.chasing /*&& */)
        {
            moving = true;
            intel.speed = chaseSpeed * charging;
            intel.SetDestination(radium.objetive.transform.position);
            modelsee.transform.eulerAngles = gameObject.transform.eulerAngles;
            intel.autoRepath = true;
            if (radium.detect)
            {
                chasingTime = 0;
                chaseMode = true;
            }
            else
            {
                chasingTime += Time.deltaTime;
                if (chasingTime >= chasingMaxTime)
                {
                    chaseMode = false;
                    chasingTime = 0;
                }
            }
        }
        else if (stat == Status.retreating)
        {
            moving = true;
            intel.speed = backSpeed * charging;
            intel.SetDestination(radium.retreatPos.transform.position);
            modelsee.transform.eulerAngles = radium.gameObject.transform.eulerAngles;
            intel.autoRepath = true;
        }
        else if (stat == Status.looking)
        {
            moving = false;
            intel.speed = 0;
            intel.SetDestination(transform.position);
            modelsee.transform.eulerAngles = radium.gameObject.transform.eulerAngles;
            intel.autoRepath = true;
        }
        else if (stat == Status.waiting)
        {
            waitTimer += Time.deltaTime;
            intel.speed = 0;
            if (waitTimer >= maxDelay)
            {
                chaseMode = true;
                attacking = false;
                waitTimer = 0;
            }
        }
        if (attacking)
        {
            stat = Status.waiting;
            statNumber = 5;
        }
        else if ((radium.detect || (radium.taken && GetComponent<EnemyLife>().taken) || chaseMode) && !radium.feel && !radium.hear )
        {
            stat = Status.chasing;
            statNumber = 0;
        }
        else if ((!radium.detect && !radium.feel && !radium.hear) && !(radium.taken && GetComponent<EnemyLife>().taken))
        {
            stat = Status.patrolling;
            statNumber = 1;
        }
        else if (radium.feel)
        {
            stat = Status.retreating;
            statNumber = 2;
        }
        else if (radium.hear)
        {
            stat = Status.looking;
            statNumber = 3;
        }

    }
    void Charge()
    {
        moving = true;
        if (marker == 0)
        {
            intel.speed = chargeSpeed * charging;
            intel.autoRepath = false;
            intel.SetDestination(radium.objetive.transform.position);
            modelsee.transform.eulerAngles = radium.gameObject.transform.eulerAngles;
            marker++;
        }
        if (Vector3.Distance(intel.destination, transform.position) < 0.15f)
        {
            intel.speed = 0;
            charging = 0;
            stunned = true;
            Debug.Log("Failed");
        }
        else if (radium.hear)
        {
            charging = 1;
            Debug.Log("Targetted");
            charge = false;
            if (radium.objetive.GetComponent<Life>() != null)
            {
                radium.objetive.GetComponent<Life>().ReduceLife(chargeDamage);
            }
            if (radium.objetive.GetComponent<PlayerController>() != null)
            {
                radium.objetive.GetComponent<PlayerController>().Stunning(stunTimer);
            }
        }
    }
    void Stunned()
    {
        moving = false;
        intel.speed = 0;
        stunnedTimer += Time.deltaTime;
        charging = 0;
        Debug.Log("InRest");
        if (stunnedTimer >= stunnedMaxTimer)
        {
            charging = 1;
            stunnedTimer = 0;
            stunned = false;
            charge = false;
        }
    }
    void Look()
    {
        if (stat == Status.retreating || stat == Status.chasing || stat == Status.looking)
        {
            pinner++;

            Vector3 objetivoO = radium.objetive.transform.position;
            objetivoO.y = 0;
            Vector3 vistaO = transform.position;
            vistaO.y = 0;
            Vector3 mira = (objetivoO - vistaO).normalized;
            float rotacion = Mathf.Atan2(mira.x, mira.z);
            rotacion = rotacion * (180 / Mathf.PI);
            transform.localEulerAngles = new Vector3(0, rotacion, 0);
        }
        else
        {
            if (patrolNumber < patrolPoint.Length)
            {
                Vector3 objetivoO = patrolPoint[patrolNumber].transform.position;
                objetivoO.y = 0;
                Vector3 vistaO = transform.position;
                vistaO.y = 0;
                Vector3 mira = (objetivoO - vistaO).normalized;
                float rotacion = Mathf.Atan2(mira.x, mira.z);
                rotacion = rotacion * (180 / Mathf.PI);
                transform.localEulerAngles = new Vector3(0, rotacion, 0);
            }
        }
    }

    void Animate()
    {
        if (moving)
        {
            //animator.SetBool("Moving", true);
            if (!charge && !stunned)
            {
                waysWalk.ActiveWhenStopped();
            }
            else if (charge && !stunned)
            {
                waysCharge.ActiveWhenStopped();
            }

        }
        else
        {
            if (stat != Status.looking)
            {
                waysIdle.ActiveWhenStopped();
            }

            //animator.SetBool("Moving", false);
        }
    }



    #region GizmosDontTouch

    void OnDrawGizmos()
    {

    }
    public void Modifying()
    {
        if (lockerDraw == false)
        {
            if (locker)
            {
                pastPatrol = patrolPoint.Length;
                locker = false;
            }
            ControlPoints();
            if (patrolPoint.Length != 0)
            {
                ControlPatrol();
            }
            for (int i = 0; i < patrolPoint.Length; i++)
            {
                if (patrolPoint[i] != null)
                {
                    Gizmos.color = Color.yellow;
                    Gizmos.DrawWireSphere(patrolPoint[i].transform.position, 0.5f);
                    Gizmos.color = Color.red;
                    Vector3 heightSize = new Vector3(0.1f, 1, 0.1f), precaution = new Vector3(0, -0.5f, 0);
                    Gizmos.DrawWireCube(patrolPoint[i].transform.position + precaution, heightSize);
                }
            }

            for (int i = 1; i < patrolPoint.Length; i++)
            {
                Gizmos.DrawLine(patrolPoint[i].transform.position, patrolPoint[i - 1].transform.position);
            }
            if (patrolPoint.Length > 1)
            {
                Gizmos.DrawLine(patrolPoint[patrolPoint.Length - 1].transform.position, patrolPoint[0].transform.position);
            }
        }
    }
    void ControlPoints()
    {
        if (pastPatrol != patrolPoint.Length)
        {
            if (pastPatrol > patrolPoint.Length)
            {
                for (int i = 0; i < pastPatrol; i++)
                {
                    if (i > patrolPoint.Length - 1)
                    {
                        DestroyPoints(i);
                    }
                }
                NewPoints();
                SavePoints();
            }
            else if (pastPatrol < patrolPoint.Length)
            {
                for (int i = 0; i < patrolPoint.Length; i++)
                {
                    if (i > pastPatrol - 1)
                    {
                        AddPoints(i);
                        SavePoints();
                    }
                }
            }
            pastPatrol = patrolPoint.Length;
        }
    }

    public void ControlPatrol()
    {
        for (int i = 0; i < savePatrol.Length; i++)
        {
            patrolPoint[i] = GameObject.Find(gameObject.name + "/" + patroller.name + "/PatrolPoint " + i);
            savePatrol[i] = GameObject.Find(gameObject.name + "/" + patroller.name + "/PatrolPoint " + i);
        }
    }

    void AddPoints(int number)
    {
        NewPoints();
        GameObject newGO = new GameObject();
        newGO.name = "PatrolPoint " + number;
        newGO.tag = "PatrolPoint";
        newGO.transform.parent = patroller.transform;
        newGO.transform.position = patroller.transform.position;
        CapsuleCollider colision = newGO.AddComponent(typeof(CapsuleCollider)) as CapsuleCollider;
        colision.isTrigger = true;
        colision.radius = 0.1f;
        colision.height = 0.75f;

        patrolPoint[number] = newGO;
    }
    void DestroyPoints(int numero)
    {
        DestroyImmediate(savePatrol[numero]);
    }
    
    void NewPoints()
    {
        savePatrol = new GameObject[patrolPoint.Length];
    }
    void SavePoints()
    {
        for (int i = 0; i < savePatrol.Length; i++)
        {
            savePatrol[i] = patrolPoint[i];
        }
    }
    #endregion
}