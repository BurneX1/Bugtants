using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLife : MonoBehaviour
{
    public int life;
    public float timeLifeSpan, feedMaxTimer;
    private float feedTimer;
    public bool destroyable, desperate;
    public GameObject objectDesperate;
    public GameObject model;
    private Material actualMat;
    public Material damagedMat;
    [HideInInspector]
    public bool dead;
    private bool damagedFeed;
    // Start is called before the first frame update
    void Start()
    {
        actualMat = model.GetComponent<MeshRenderer>().material;
        feedTimer = 0;
        dead = false;
    }

    // Update is called once per frame
    void Update()
    {
        Feedback();
    }
    void Feedback()
    {
        if (feedTimer > 0)
        {
            feedTimer -= Time.deltaTime;
            model.GetComponent<MeshRenderer>().material = damagedMat;
        }
        else if (actualMat != model.GetComponent<MeshRenderer>().material)
        {
            feedTimer = 0;
            model.GetComponent<MeshRenderer>().material = actualMat;
        }
    }
    public void ChangeLife(int value)
    {
        life += value;
        if (value < 0)
        {
            feedTimer = feedMaxTimer;
        }
        if (life <= 0)
        {
            if (desperate)
            {
                objectDesperate.transform.position = transform.position;
                objectDesperate.GetComponent<LifeSpan>().maxTimer = timeLifeSpan;
                Instantiate(objectDesperate);
                desperate = false;
                objectDesperate.transform.position = new Vector3(0, 0, 0);
            }
            dead = true;
            if (destroyable)
            {
                Destroy(gameObject);
            }
        }
    }
}
