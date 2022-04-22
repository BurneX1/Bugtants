using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLife : MonoBehaviour
{
    public int life;
    public float timeLifeSpan;
    public bool destroyable, desperate;
    public GameObject objectDesperate;
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
            if (desperate)
            {
                objectDesperate.transform.position = transform.position;
                objectDesperate.GetComponent<LifeSpan>().maxTimer = timeLifeSpan;
                Instantiate(objectDesperate);
                desperate = false;
            }
            dead = true;
            if (destroyable)
            {
                Destroy(gameObject);
            }
        }
    }
}
