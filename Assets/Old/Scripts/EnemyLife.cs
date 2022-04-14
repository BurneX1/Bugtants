using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLife : MonoBehaviour
{
    public int life;
    public bool destroyable;
    private bool dead;
    // Start is called before the first frame update
    void Start()
    {
        dead = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeLife(int value)
    {
        life += value;
        if (life <= 0)
        {
            dead = true;
            if (destroyable)
            {
                Destroy(gameObject);
            }
        }
    }
}
