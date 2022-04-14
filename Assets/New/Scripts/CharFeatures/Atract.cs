using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Atract : MonoBehaviour
{
    private GameObject grapplePoint;
    private Vector3 hitPos;

    public LayerMask grapable;
    public Transform basePoint;
    public float maxDistance;
    public float delayTime;
    private SpringJoint joint;
    private bool shoot;
    private Vector3 lastDir;
    private float timer;

    void Awake()
    {
        
        
    }

    private void Update()
    {
        DelayTime();
    }

    public void StartGrapple(Vector3 startPos, Vector3 direction)
    {
        ClearJoint();
        RaycastHit hit;
        if (Physics.Raycast(startPos, direction, out hit, maxDistance, grapable))
        {
            grapplePoint = hit.transform.gameObject;
            lastDir = direction;
            
        }
        shoot = true;
    }
    public void StartGrapple()
    {
        ClearJoint();
        Vector3 startPos = gameObject.transform.position;
        Vector3 direction = gameObject.transform.forward;
        RaycastHit hit;
        if (Physics.Raycast(startPos, direction, out hit, maxDistance, grapable))
        {
            grapplePoint = hit.transform.gameObject;
            lastDir = direction;
            
        }
        shoot = true;
    }

    private void DelayTime()
    {

        if(shoot == true)
        {
            //MakeHereSomeStuff, temporal code
            gameObject.GetComponent<MeshRenderer>().material.color = Color.red;
            if(timer < delayTime)
            {
                
                timer += Time.deltaTime;
            }
            else
            {
                RaycastHit hit;
                
                if (grapplePoint != null && Physics.Raycast(transform.position, lastDir, out hit, maxDistance, grapable))
                {
                    if(hit.transform.gameObject == grapplePoint)
                    {
                        joint = grapplePoint.AddComponent<SpringJoint>();
                    }
                    else
                    {
                        shoot = false;
                        timer = 0;
                        return;
                    }
                    
                }
                else
                {
                    shoot = false;
                    timer = 0;
                    return;
                }
                currentGrapplePosition = transform.position;
                joint.autoConfigureConnectedAnchor = false;

                
                float distanceFromPoint = Vector3.Distance(transform.position, grapplePoint.transform.position);

                //The distance grapple will try to keep from grapple point. 
                joint.maxDistance = 1;
                joint.minDistance = 0;

                //Adjust these values to fit your game.
                joint.spring = 20;
                joint.damper = 1;
                joint.massScale = 4.5f;
                //currentGrapplePosition = basePoint.position;
                joint.connectedAnchor = transform.position;
                shoot = false;
                timer = 0;
            }
        }
        else
        {
            //Temporal code, just for refs
            gameObject.GetComponent<MeshRenderer>().material.color = Color.green;
        }
    }




    void ClearJoint()
    {
        shoot = false;
        Destroy(joint);
        lastDir = Vector3.forward;
        grapplePoint = null;
    }



    private Vector3 currentGrapplePosition;

    void DrawRope()
    {

    }

    public bool IsGrappling()
    {
        return joint != null;
    }

    public Vector3 GetGrapplePoint()
    {
        return grapplePoint.transform.position;
    }

    private void OnDrawGizmos()
    {
        if(grapplePoint!=null)
        {
            Gizmos.DrawCube(grapplePoint.transform.position, new Vector3(0.5f, 0.5f, 0.5f));
        }
        
    }

    private void OnEnable()
    {
        
    }
    private void OnDisable()
    {
        
    }
}
