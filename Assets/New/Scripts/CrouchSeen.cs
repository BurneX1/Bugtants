using UnityEngine;

public class CrouchSeen : MonoBehaviour
{
    RaycastHit hit;
    //public PlayerMovement playerCrouch;
    public Transform startPos;
    [HideInInspector]
    public bool can;

    /*void Update()
    {
        Crouch();
    }
    public void Crouch()
    {
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.up), out hit, Vector3.Distance(transform.position, startPos.position), 1 << 0))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.up) * hit.distance, Color.yellow);
            can = false;
        }
        else
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.up) * playerCrouch.altitude * 2, Color.white);
            can = true;
        }
    }*/
    public bool CrouchBool(float crouchChange)
    {
        bool cannie;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.up), out hit, Vector3.Distance(transform.position, startPos.position), 1 << 0))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.up) * hit.distance, Color.yellow);
            cannie = false;
        }
        else
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.up) * crouchChange * 2, Color.white);
            cannie = true;
        }
        return cannie;
    }
}
