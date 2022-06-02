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
    public bool destroyable, armor;
    public GameObject model, objectDesperate;
    private Material actualMat;
    public Material damagedMat;

    //State Definition//
    [HideInInspector]
    public bool dead, taken;
    private bool desperated;
    //Sounds//
    private SoundActive sounds;

    void Start()
    {
        desperated = true;
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
            if (armor)
                life -= value / 2;
            feedTimer = feedMaxTimer;
            takeTimer = takeMaxTimer;
        }
        if (life <= 0)
        {
            if (desperated && objectDesperate != null)
            {
                objectDesperate.transform.position = transform.position;
                Instantiate(objectDesperate);
                objectDesperate.transform.position = new Vector3(0, 0, 0);
                desperated = false;
            }

            dead = true;

            if (destroyable) Destroy(gameObject);
        }
    }
}
