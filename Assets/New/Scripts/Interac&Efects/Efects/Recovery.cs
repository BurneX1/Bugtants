using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recovery : MonoBehaviour
{
    public int recovAmount;
    private GameObject entity;
    private Interacter c_int;

    private void Start()
    {
        c_int = gameObject.GetComponent<Interacter>();
    }
    public void RecovLife()
    {
        if(c_int.whoCall == null)
        {
            return;
        }

        entity = c_int.whoCall;
        Life lf;
        if(entity.GetComponent<Life>())
        {
            lf = entity.GetComponent<Life>();
            lf.AddLife(recovAmount);

        }
        else
        {
            Debug.Log("This entity dont have Life Script  [" + entity + "]");
        }
    }
}
