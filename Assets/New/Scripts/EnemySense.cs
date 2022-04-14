using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySense : MonoBehaviour
{
    public Transform rotOrigin;
    public float range, minRange;
    private RaycastHit wall, floor;
    [HideInInspector]
    public float startLook, tryWall, tryObjetive, totalRange, angle;
    [HideInInspector]
    public GameObject objetive;
    [HideInInspector]
    public Vector3 retreatPos;

    public GameObject[] rangePoints;
    [HideInInspector]
    public bool dead, detect, feel;

    // Start is called before the first frame update
    void Start()
    {
        totalRange = range;
        startLook = rotOrigin.eulerAngles.y;
        objetive = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (objetive != null)
        {
            Looking();
            Sensing();
            Sides();
            RetreatZone();
        }
    }
    void Looking()
    {
        transform.LookAt(objetive.transform);
    }
    void Sensing()
    {
        tryObjetive = Vector3.Distance(transform.position, objetive.transform.position);
        if (Physics.Linecast(transform.position, objetive.transform.position, out wall, (1 << 7)))
        {
            tryWall = Vector3.Distance(transform.position, wall.point);
        }
        else if (Physics.Linecast(transform.position, objetive.transform.position, out floor, (1 << 6)))
        {
            tryWall = Vector3.Distance(transform.position, floor.point);
        }
        else
        {
            tryWall = totalRange;
        }

        if (tryWall <= tryObjetive)
        {
            detect = false;
        }
        else if (tryWall > tryObjetive)
        {
            detect = true;
        }
        if (tryWall > minRange)
        {
            feel = false;
        }
        else if (tryWall <= tryObjetive)
        {
            feel = true;
        }

    }
    void Sides()
    {
        angle = transform.localEulerAngles.y;
        if (angle > 180)
        {
            angle -= 360;
        }
        if (angle <= 90 && angle >= -90)
        {
            totalRange = range / 1;
        }
        else
        {
            totalRange = range / 4;
        }
    }
    void RetreatZone()
    {

    }
    void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Vector3 draw;

        draw = transform.position;
        for (int i = 0; i < rangePoints.Length; i++)
        {
            rangePoints[i].transform.position = draw;
        }
        Vector3[] drawing = new Vector3[rangePoints.Length];
        drawing[0].z += range;
        drawing[1].x += range;
        drawing[2].x -= range;
        drawing[3].y += range;
        drawing[4].y -= range;

        for (int i = 0; i < rangePoints.Length; i++)
        {
            rangePoints[i].transform.localPosition += drawing[i];
        }
        for (int i = 0; i < rangePoints.Length; i++)
        {
            Gizmos.DrawLine(draw, rangePoints[i].transform.position);
        }
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(transform.position, range/4);
        Gizmos.color = Color.magenta;
        Gizmos.DrawWireSphere(transform.position, minRange);
    }
}
