using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyGroundMove : MonoBehaviour
{
    public NavMeshAgent intel;
    //public ValorSalud valores;
    public bool instantChase;
    [HideInInspector]
    public bool calm;
    public enum Status{patrolling, chasing, retreating };
    public Status stat;
    [HideInInspector]
    public float saveSpeed, saveAcc, saveLife;
    public EnemySense radium;
    private int pinner;
    public GameObject moveSound;
    public GameObject[] patrolPoint;


    public GameObject patroller;
    private int pastPatrol, patrolNumber, proximity;
    [HideInInspector]
    public GameObject[] savePatrol;
    public Detecter detectPatrol;
    private bool locker = true, lockerDraw = false;

    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        /*
        if (valores != null)
        {
            guardarVida = valores.vida;
        }*/
        pinner = 0;
        if (patrolPoint.Length != 0)
        {
            ControlPatrol();
        }
        lockerDraw = true;
        patrolNumber = 0;
        saveSpeed = intel.speed;
        saveAcc = intel.acceleration;
        patroller.transform.parent = null;
        locker = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (radium != null)
        {
            if (radium.objetive != null)
            {
                Movement();
                //Animate();
            }
        }
    }

    void Movement()
    {
        if (stat == Status.patrolling)
        {
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
                    patrolNumber += 1;
                }
            }
            /*
            if (radar.detectar || guardarVida != valores.vida)
            {
                valores.pesada = false;
                Mirar();
                tranquilo = false;
            }
            */

        }
        else if(stat == Status.chasing)
        {
            intel.SetDestination(radium.objetive.transform.position);
            if (saveSpeed == 0)
            {
                Look();
            }
        }
        if (radium.detect&&!radium.feel)
        {
            stat = Status.chasing;
        }
        else if(!radium.detect&&!radium.feel)
        {
            stat = Status.patrolling;
        }
        else if (radium.feel)
        {
            stat = Status.retreating;
        }
    }

    void Look()
    {
        if (pinner == 0 || (saveSpeed == 0 && calm == false))
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
    }

    void Animate()
    {
        if (intel.speed != 0)
        {
            //sonidoMovimiento.SetActive(true);
            animator.SetBool("Moving", true);
        }
        else if (intel.speed == 0)
        {
            //sonidoMovimiento.SetActive(false);
            animator.SetBool("Moving", false);
        }
    }



    #region GizmosDontTouch

    void OnDrawGizmos()
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

    void ControlPatrol()
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