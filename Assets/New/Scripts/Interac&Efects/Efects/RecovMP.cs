using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecovMP : MonoBehaviour
{
    public int recovAmount;
    private GameObject entity;
    private Interacter c_int;

    private void Start()
    {
        c_int = gameObject.GetComponent<Interacter>();
    }
    public void RecovManaPoints()
    {
        if (c_int.whoCall == null)
        {
            return;
        }

        entity = c_int.whoCall;
        MP_System mp;
        if (entity.GetComponent<Life>())
        {
            mp = entity.GetComponent<MP_System>();
            mp.AddMP(recovAmount);

        }
        else
        {
            Debug.Log("This entity dont have MP_System Script  [" + entity + "]");
        }
    }
}
