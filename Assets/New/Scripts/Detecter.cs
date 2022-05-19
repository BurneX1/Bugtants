using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detecter : MonoBehaviour
{
    public bool touch, otherTouch;
    public GameObject registeredObject, anotherRegisteredObject;
    public string tagName, anotherTagName;
    // Start is called before the first frame update
    void Start()
    {
        touch = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == tagName)
        {
            touch = true;
            registeredObject = col.gameObject;
        }
        else if (col.gameObject.tag == anotherTagName)
        {
            otherTouch = true;
            anotherRegisteredObject = col.gameObject;
        }
    }

    void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == tagName)
        {
            touch = false;
            registeredObject = null;
        }
        else if (col.gameObject.tag == anotherTagName)
        {
            otherTouch = true;
            anotherRegisteredObject = null;
        }

    }
}
