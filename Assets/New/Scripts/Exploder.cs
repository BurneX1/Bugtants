using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exploder : MonoBehaviour
{
    public EnemyGroundMove movement;
    public EnemyLife suicide;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Explode();
    }

    void Explode()
    {
        if (movement.statNumber == 2)
        {
            suicide.ChangeLife(-suicide.life);
        }

    }
}
