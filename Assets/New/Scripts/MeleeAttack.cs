using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttack : MonoBehaviour
{
    public EnemyGroundMove movement;
    public float maxTimer;
    [HideInInspector]
    public bool stunned;
    public int damage;
    [HideInInspector]
    public float timer;
    public WaysToSound waysOnAttack;
    // Start is called before the first frame update
    void Start()
    {
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
        timer += Time.deltaTime;
        if (movement.statNumber == 4)
        {
            timer = 0;
        }
        else if (timer >= maxTimer && (movement.statNumber == 2 || movement.statNumber == 3))
        {
            waysOnAttack.StopThenActive();
            Debug.Log("Attacked");
            movement.radium.objetive.GetComponent<Life>().ReduceLife(damage);
            movement.attacking = true;
            timer = 0;
        }
    }
}
