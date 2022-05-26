using UnityEngine;

public class CrouchSeen : MonoBehaviour
{
    RaycastHit hit;
    public Transform startPos;
    [HideInInspector]
    public bool can;

    public bool CrouchBool(float crouchChange)
    {
        bool cannie;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.up), out hit, Vector3.Distance(transform.position, startPos.position), 1 << 12))
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
