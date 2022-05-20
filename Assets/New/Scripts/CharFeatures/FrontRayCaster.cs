using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrontRayCaster : MonoBehaviour
{
    public float interactDistance;
    public GameObject rayBound;
    //[HideInInspector]
    public GameObject frontObj;
    private GameObject realFront;



    public void FrontCast()
    {
        RaycastHit hit;
        if (Physics.Raycast(
            rayBound.transform.position,
            rayBound.transform.forward,
            out hit
        ))
        {
            realFront = hit.collider.gameObject;
            if(Vector3.Distance(realFront.transform.position,rayBound.transform.position) < interactDistance)
            {
                frontObj = realFront;
            }
            else
            {
                frontObj = null;
            }
        }


    }

    public void Interact()
    {
        FrontCast();
        if (frontObj == null)
        {
            return;
        }
        if (frontObj)
        {

        }

        if(frontObj.gameObject.GetComponent<Interacter>())
        {
            frontObj.gameObject.GetComponent<Interacter>().ExternalCall(gameObject);
        }
    }

    public GameObject CustomCast(float distance, LayerMask mask)
    {
        return null;
    }
}
