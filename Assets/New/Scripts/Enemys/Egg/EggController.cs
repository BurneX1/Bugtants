using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EggController : MonoBehaviour
{
    private Life c_life;
    private Generator c_gen;


    // Start is called before the first frame update
    void Start()
    {
        c_gen = gameObject.GetComponent<Generator>();
        c_life = gameObject.GetComponent<Life>();
    }

    // Update is called once per frame
    void Update()
    {
        if(c_life.actualHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {

        c_gen.Generate();
        gameObject.SetActive(false);
    }
}
