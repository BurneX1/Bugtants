using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScarab : MonoBehaviour
{
    public EnemyGroundMove movement;
    public EnemySense enemySee;
    public int chargeDamage;
    public float stunnerTime;
    private bool preparing;
    public float maxTimer;
    private float saveSpeed, timer;
    // Start is called before the first frame update
    void Start()
    {
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(!movement.charge&&!movement.stunned)
        ChargeTime();
    }

    void ChargeTime()
    {
        timer += Time.deltaTime;
        if ((timer >= maxTimer && enemySee.crash && !preparing)&&!movement.charge)
        {
            saveSpeed = movement.saveSpeed;
            movement.charging = 0;
            Debug.Log("Prepare");
            timer = 0;
            preparing = true;
        }
        else if (timer >= 2f && preparing)
        {
            movement.charging = 1;
            movement.saveSpeed = saveSpeed;
            Debug.Log("Charged");
            movement.stunnedMaxTimer = stunnerTime;
            preparing = false;
            timer = 0;
            movement.charge = true;
        }

    }
}
