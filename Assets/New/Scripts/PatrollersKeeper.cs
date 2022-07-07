using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrollersKeeper : MonoBehaviour
{
    private GameObject[] patrollins;
    [Header("Antes de inicializar el initiate, es muy pero muy recomendable que todos los enemigos estén activos")]
    [Tooltip("Al presionar ese boton, se cambiara el nombre de los patrullajes madre, eso hara que los patrullajes sean eficientes")]
    public bool initiate;
    private bool lockers;
    // Start is called before the first frame update
    void Awake()
    {
        lockers = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnDrawGizmos()
    {
        if (!lockers && initiate)
        {
            patrollins = GameObject.FindGameObjectsWithTag("Patrollers");
            for(int i = 0; i < patrollins.Length; i++)
            {
                patrollins[i].name = "Patrollers" + " " + i; 
            }
            Debug.Log("Finished cleanship");
            initiate = false;
        }
    }
}
