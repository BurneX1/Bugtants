using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnemyLife : MonoBehaviour
{
    public event Action Damage = delegate { };
    public event Action Dead = delegate { };
    //General//
    public int life, giftQuantity;
    public float timeLifeSpan, feedMaxTimer, takeMaxTimer;
    private float feedTimer, takeTimer;

    //Feedback//
    public bool destroyable, armor, grandArmor;
    public GameObject model, objectDesperate;
    private Material actualMat;
    public Material damagedMat;

    //State Definition//
    [HideInInspector]
    public bool dead, taken, point;
    private bool desperated;
    //Sounds//
    private SoundActive sounds;

    void Awake()
    {
        point = false;
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
        if (value < 0 && !grandArmor)
        {
            Damage.Invoke();
            if (armor)
                life -= value / 2;
            feedTimer = feedMaxTimer;
            takeTimer = takeMaxTimer;
        }
        if (life <= 0)
        {
            Dead.Invoke();
            if (desperated && objectDesperate != null)
            {
                Vector3 look = transform.position;
                if(point)
                look.y += 0.5f;
                objectDesperate.transform.position = look;
                if (objectDesperate.GetComponent<RecovMP>() != null)
                {
                    objectDesperate.GetComponent<RecovMP>().recovAmount = giftQuantity;
                }
                else if (objectDesperate.GetComponent<NegativeSpores>() != null)
                {
                    objectDesperate.GetComponent<NegativeSpores>().damage = giftQuantity;
                }
                Instantiate(objectDesperate);
                objectDesperate.transform.position = new Vector3(0, 0, 0);
                desperated = false;
            }
            dead = true;

            if (destroyable) Destroy(gameObject);
        }
    }
}
