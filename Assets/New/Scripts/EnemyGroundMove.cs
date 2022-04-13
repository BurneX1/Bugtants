using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyGroundMove : MonoBehaviour
{
    public NavMeshAgent intel;
    //public ValorSalud valores;
    public bool calm;
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
                Animate();
            }
        }
    }

    void Movement()
    {
        if (calm)
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
        else
        {
            intel.SetDestination(radium.objetive.transform.position);
            if (saveSpeed == 0)
            {
                Mirar();
            }
        }

    }

    void Mirar()
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
            animator.SetBool("SeMueve", true);
        }
        else if (intel.speed == 0)
        {
            //sonidoMovimiento.SetActive(false);
            animator.SetBool("SeMueve", false);
        }
    }



    #region GizmosNoTocar

    void OnDrawGizmos()
    {
        if (lockerDraw == false)
        {
            if (locker)
            {
                pastPatrol = patrolPoint.Length;
                locker = false;
            }
            ControlarPuntos();
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
                    Vector3 tamañoAltura = new Vector3(0.1f, 1, 0.1f), precaucion = new Vector3(0, -0.5f, 0);
                    Gizmos.DrawWireCube(patrolPoint[i].transform.position + precaucion, tamañoAltura);
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

    void ControlarPuntos()
    {
        if (pastPatrol != patrolPoint.Length)
        {
            if (pastPatrol > patrolPoint.Length)
            {
                for (int i = 0; i < pastPatrol; i++)
                {
                    if (i > patrolPoint.Length - 1)
                    {
                        DestruirPuntos(i);
                    }
                }
                NuevosPuntos();
                GuardaPuntos();
            }
            else if (pastPatrol < patrolPoint.Length)
            {
                for (int i = 0; i < patrolPoint.Length; i++)
                {
                    if (i > pastPatrol - 1)
                    {
                        AnadirPuntos(i);
                        GuardaPuntos();
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
            patrolPoint[i] = GameObject.Find(gameObject.name + "/" + patroller.name + "/Punto de Patrulla " + i);
            savePatrol[i] = GameObject.Find(gameObject.name + "/" + patroller.name + "/Punto de Patrulla " + i);
        }
    }

    void AnadirPuntos(int numero)
    {
        NuevosPuntos();
        GameObject nuevoGO = new GameObject();
        nuevoGO.name = "Punto de Patrulla " + numero;
        nuevoGO.tag = "Punto de patrulla";
        nuevoGO.transform.parent = patroller.transform;
        nuevoGO.transform.position = patroller.transform.position;
        CapsuleCollider colision = nuevoGO.AddComponent(typeof(CapsuleCollider)) as CapsuleCollider;
        colision.isTrigger = true;
        colision.radius = 0.1f;
        colision.height = 0.75f;

        patrolPoint[numero] = nuevoGO;
    }
    void DestruirPuntos(int numero)
    {
        DestroyImmediate(savePatrol[numero]);
    }
    
    void NuevosPuntos()
    {
        savePatrol = new GameObject[patrolPoint.Length];
    }
    void GuardaPuntos()
    {
        for (int i = 0; i < savePatrol.Length; i++)
        {
            savePatrol[i] = patrolPoint[i];
        }
    }
    #endregion
}