using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detecter : MonoBehaviour
{
    public bool touch;
    public GameObject registeredObject;
    public string tagName;
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
    }

    void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == tagName)
        {
            touch = false;
            registeredObject = null;
        }
    }
}
