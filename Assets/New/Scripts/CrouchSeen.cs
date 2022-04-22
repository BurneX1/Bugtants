using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrouchSeen : MonoBehaviour
{
    RaycastHit hit;
    public PlayerMovement playerCrouch;
    public Transform startPos;
    [HideInInspector]
    public bool can;
    void Start()
    {

    }
    void Update()
    {
        Crouch();
    }
    void Crouch()
    {
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.up), out hit, Vector3.Distance(transform.position, startPos.position), 1 << 0))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.up) * hit.distance, Color.yellow);
            Debug.Log("Did Hit");
            can = false;
        }
        else
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.up) * playerCrouch.altitude * 2, Color.white);
            Debug.Log("Did not Hit");
            can = true;
        }
    }
}
