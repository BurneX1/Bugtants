using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScarab : MonoBehaviour
{
    public EnemyGroundMove movement;
    public EnemySense enemySee;
    public float stunnerTime;
    private bool preparing;
    public float maxTimer;
    private float saveSpeed, timer;
    // Start is called before the first frame update
    void Start()
    {
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
            movement.saveSpeed = 0;
            preparing = true;
            Debug.Log("Prepare");
            timer = 0;
        }
        else if (timer >= 2f && preparing)
        {
            movement.saveSpeed = saveSpeed;
            Debug.Log("Charged");
            movement.stunnedMaxTimer = stunnerTime;
            preparing = false;
            timer = 0;
            movement.charge = true;
        }

    }
}
