using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;


public class ItemDetectors : MonoBehaviour
{
    public string tagName;
    public List<GameObject> TouchingObjects;
    void Start()
    {
        TouchingObjects = new List<GameObject>();
    }
    void Update()
    {

    }

    public void Checker(GameObject obj)
    {
        if (TouchingObjects.Contains(obj))
        {
            TouchingObjects.Remove(obj);
            obj.SetActive(false);
            StartCoroutine(Destroying(obj));
        }
    }
    IEnumerator Destroying(GameObject obj)
    {
        yield return new WaitForSeconds(0.1f);
        Destroy(obj);

    }
    void OnTriggerEnter(Collider collision)
    {
        if (!TouchingObjects.Contains(collision.gameObject) && collision.gameObject.tag == tagName && collision.gameObject.GetComponent<EnemyAttract>() == null)
        {
            TouchingObjects.Add(collision.gameObject);
        }
        else if (TouchingObjects.Contains(collision.gameObject) && collision.gameObject.tag != tagName)
        {
            TouchingObjects.Remove(collision.gameObject);
        }
    }

    void OnTriggerExit(Collider collision)
    {
        if (TouchingObjects.Contains(collision.gameObject) && collision.gameObject.tag == tagName && collision.gameObject.GetComponent<EnemyAttract>() == null)
            
            TouchingObjects.Remove(collision.gameObject);
    }

}
