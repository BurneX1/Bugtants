using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLife : MonoBehaviour
{
    //General//
    public int life;
    public float timeLifeSpan, feedMaxTimer, takeMaxTimer;
    private float feedTimer, takeTimer;

    //Feedback//
    public bool destroyable;
    public GameObject model;
    private Material actualMat;
    public Material damagedMat;

    //State Definition//
    [HideInInspector]
    public bool dead, taken;

    //Sounds//
    private SoundActive sounds;

    void Start()
    {
        actualMat = model.GetComponent<MeshRenderer>().material;
        feedTimer = 0;
        takeTimer = 0;
        taken = false;
        dead = false;
        if (gameObject.GetComponent<SoundActive>() != null) sounds = gameObject.GetComponent<SoundActive>();
    }

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
        if (takeTimer > 0)
        {
            takeTimer -= Time.deltaTime;

            taken = true;
        }
        else
        {
            takeTimer = 0;

            taken = false;
        }
    }

    public void ChangeLife(int value)
    {
        life += value;
        if (value < 0)
        {
            feedTimer = feedMaxTimer;
            takeTimer = takeMaxTimer;
        }
        if (life <= 0)
        {
            /*if (desperate)
            {
                objectDesperate.transform.position = transform.position;
                objectDesperate.GetComponent<LifeSpan>().maxTimer = timeLifeSpan;
                Instantiate(objectDesperate);
                desperate = false;
                objectDesperate.transform.position = new Vector3(0, 0, 0);
            }*/

            dead = true;

            if (destroyable) Destroy(gameObject);
        }
    }
}
