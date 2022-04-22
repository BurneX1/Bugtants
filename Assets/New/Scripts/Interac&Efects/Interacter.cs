using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Interacter : MonoBehaviour
{
    public bool instaPick;
    public bool dsblOnPick;
    public UnityEvent effectList;
    public string[] tagList;
    [HideInInspector]
    public GameObject whoCall;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(instaPick == true)
        {
            for (int i = 0; i < tagList.Length; i++)
            {
                if (other.gameObject.tag == tagList[i])
                {
                    whoCall = other.gameObject;
                    CallEfects();
                }
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject == whoCall)
        {
            whoCall = null;
        }
    }

    public void ExternalCall(GameObject callEntity)
    {
        if(instaPick == false)
        {
            whoCall = callEntity;
            CallEfects();
        }

    }

    private void CallEfects()
    {
        effectList.Invoke();
        if (dsblOnPick)
        {
            gameObject.SetActive(false);
        }
    }


}
