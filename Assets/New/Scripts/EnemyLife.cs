using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnemyLife : MonoBehaviour
{
    private SoundFights audios;
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
    public bool dead, taken, point, reached;
    private bool desperated;
    public WaysToSound waysDead, waysDamaged;
    //Sounds//
    private SoundActive sounds;
    void Start()
    {
        audios = GameObject.Find("AudioManager").GetComponent<SoundFights>();
        reached = false;
        point = false;
        desperated = true;
        actualMat = model.GetComponent<MeshRenderer>().material;
        feedTimer = 0;
        takeTimer = 0;
        taken = false;
        dead = false;
        waysDead.sounds = gameObject.GetComponent<SoundActive>();
        waysDamaged.sounds = gameObject.GetComponent<SoundActive>();
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
                life -= (int)(value / 1.5f);
            feedTimer = feedMaxTimer;
            takeTimer = takeMaxTimer;
            reached = true;
            waysDamaged.StopThenActive();
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
            transform.gameObject.tag = "Untagged";
            Debug.Log("-1");
            audios.tensionNumber -= 1;
            waysDead.StopThenActive();

            if (destroyable) Destroy(gameObject);
            else SetLayerRecursively(gameObject, 10);

        }
    }
    public static void SetLayerRecursively(GameObject go, int layerNumber)
    {
        foreach (Transform trans in go.GetComponentsInChildren<Transform>(true))
        {
            trans.gameObject.layer = layerNumber;
        }
    }
}
