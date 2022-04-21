using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System.Linq;

public class AIMovement : MonoBehaviour
{

    private NavMeshAgent agnt;
    private Vector3[] patrolPoints = new Vector3[1];
    public Vector3[] positions;

    public bool cyclic;
    private int indexer;
    private void Awake()
    {
        agnt = gameObject.GetComponent<NavMeshAgent>();
        SettPoints();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Patrol(Vector3[] points)
    {

    }

    public void MovePoint(Vector3 target)
    {
        agnt.destination = target;
    }

    public void DetectFront()
    {

    }

    private void SettPoints()
    {
        patrolPoints[0] = new Vector3(transform.position.x, transform.position.y);
        for (int i = 0; i < positions.Length; i++)
        {
            patrolPoints = patrolPoints.Concat(new Vector3[] { new Vector3(transform.position.x + positions[i].x, transform.position.y + positions[i].y, transform.position.z + positions[i].z) }).ToArray();
        }
    }

    //-------------------Draw&Visual----------------------//

    private void OnDrawGizmos()
    {

        Gizmos.color = new Color(0, 0, 1, 0.12f);
        Vector3 befPos;
        Vector3 aftPos;

        if (Application.isPlaying)
        {
            befPos = patrolPoints[0];
            for (int i = 0; i <= positions.Length; i++)
            {
                Gizmos.DrawCube(patrolPoints[i], gameObject.GetComponent<BoxCollider>().bounds.size);
                if (i - 1 >= 0)
                {
                    befPos = patrolPoints[i - 1];
                }
                Gizmos.DrawLine(patrolPoints[i], befPos);
                if (i + 1 > positions.Length)
                {
                    aftPos = patrolPoints[0];
                    Gizmos.DrawLine(patrolPoints[i], aftPos);
                }

            }
        }
        else
        {
            befPos = transform.position;
            for (int i = 0; i < positions.Length; i++)
            {
                if (i - 1 >= 0)
                {
                    befPos = new Vector3(transform.position.x + positions[i - 1].x, transform.position.y + positions[i - 1].y, transform.position.z + positions[i].z);
                }
                Gizmos.DrawLine(new Vector3(transform.position.x + positions[i].x, transform.position.y + positions[i].y, transform.position.z + positions[i].z), befPos);
                if (i + 1 >= positions.Length)
                {
                    aftPos = transform.position;
                    Gizmos.DrawLine(new Vector3(transform.position.x + positions[i].x, transform.position.y + positions[i].y, transform.position.z + positions[i].z), aftPos);
                }
                Gizmos.DrawCube(new Vector3(transform.position.x + positions[i].x, transform.position.y + positions[i].y, transform.position.z + positions[i].z), gameObject.GetComponent<BoxCollider>().bounds.size);
            }
        }



    }
}
