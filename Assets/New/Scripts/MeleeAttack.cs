using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttack : MonoBehaviour
{
    public EnemyGroundMove movement;
    public float maxTimer;
    [HideInInspector]
    public bool stunned;
    private float timer;
    // Start is called before the first frame update
    void Start()
    {
        stunned = false;
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
        if (timer >= maxTimer && (movement.statNumber == 2 || movement.statNumber == 3))
        {
            Debug.Log("Attacked");
            timer = 0;
        }
    }
}
