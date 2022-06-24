using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnViewEnemy : MonoBehaviour
{
    private bool visible, wallHit;
    public bool resultView;
    public GameObject objetive;
    // Start is called before the first frame update
    void Start()
    {
        objetive = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        SeeVisible();
    }

    void SeeVisible()
    {
        if (Physics.Linecast(transform.position, objetive.transform.position, (1 << 12) | (1 << 3)))
        {
            wallHit = true;
        }
        else
        {
            wallHit = false;
        }
        if (visible && !wallHit)
        {
            resultView = true;
        }
        else
        {
            resultView = false;
        }
    }
    void OnBecameVisible()
    {
        visible = true;
    }
    void OnBecameInvisible()
    {
        visible = false;
    }
}
