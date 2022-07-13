using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class MeleeAttack : MonoBehaviour
{
    public event Action Atack = delegate { };
    public EnemyGroundMove movement;
    public float maxTimer;
    [HideInInspector]
    public bool stunned, attacking;
    public int damage;
    [HideInInspector]
    public float timer;
    public WaysToSound waysOnAttack;
    public Detecter attackDoner;
    // Start is called before the first frame update
    void Start()
    {
        attacking = false;
        stunned = false;
        if (gameObject.GetComponent<SoundActive>() != null)
        {
            waysOnAttack.sounds = gameObject.GetComponent<SoundActive>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!stunned)
        Attack();
    }
    void Attack()
    {
        if (!attacking)
            timer += Time.deltaTime;
        if (movement.statNumber == 4)
        {
            timer = 0;
        }
        else if (timer >= maxTimer && (movement.statNumber == 2 || movement.statNumber == 3) && !attacking)
        {
            waysOnAttack.StopThenActive();
            Atack.Invoke();
            attacking = true;
        }
    }
    public void AttackPoint()
    {
        movement.attacking = true;
        if (attackDoner.touch)
        {
            movement.radium.objetive.GetComponent<Life>().ReduceLife(damage);
        }
        timer = 0;
        attacking = false;

    }
}
