using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class IntermittentObject : MonoBehaviour
{
    private float timer;
    public GameObject simpleObject;

    void Start()
    {
        simpleObject.SetActive(true);
    }

    void Update()
    {      
        timer += Time.deltaTime;
        if(timer >= 1f && timer<2f) simpleObject.SetActive(false);

        else if(timer >= 2f)
        {
            simpleObject.SetActive(true);
            timer = 0;
        }
    }
}
