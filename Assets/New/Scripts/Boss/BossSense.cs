using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSense : MonoBehaviour
{
    public Transform rotOrigin;
    

    public int firstOption, secondOption;
    public float range, goingRange;
    private RaycastHit wall, floor;
    [HideInInspector]
    public float startLook, tryWall, tryObjetive, totalRange, angle;
    [HideInInspector]
    public GameObject objetive;
    public GameObject[] rangePoints;
    [HideInInspector]
    public bool detect, feel;

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
        }
    }
    void Looking()
    {
        transform.LookAt(objetive.transform);
    }
    void Sensing()
    {
        tryObjetive = Vector3.Distance(transform.position, objetive.transform.position);
        if (Physics.Linecast(transform.position, objetive.transform.position, out wall, (1 << 12)))
        {
            tryWall = Vector3.Distance(transform.position, wall.point);
        }
        else if (Physics.Linecast(transform.position, objetive.transform.position, out floor, (1 << 3)))
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
        if (tryObjetive > goingRange)
        {
            feel = false;
        }
        else if (tryObjetive <= goingRange)
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
        if (angle <= 45 && angle > -45) //Frente
        {
            firstOption = 1;
            secondOption = 2;
        }
        else if (angle <= 135 && angle > 45) // Izquierda
        {
            firstOption = 4;
            secondOption = 1;
        }
        else if (angle <= -45 && angle > -135) // Derecha
        {
            firstOption = 2;
            secondOption = 3;
        }
        else // Atras
        {
            firstOption = 3;
            secondOption = 4;
        }
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
        drawing[1].z -= range;
        drawing[2].x += range;
        drawing[3].x -= range;
        drawing[4].y += range;
        drawing[5].y -= range;

        for (int i = 0; i < rangePoints.Length; i++)
        {
            rangePoints[i].transform.localPosition += drawing[i];
        }
        for (int i = 0; i < rangePoints.Length; i++)
        {
            Gizmos.DrawLine(draw, rangePoints[i].transform.position);
        }
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, goingRange);
    }
}
