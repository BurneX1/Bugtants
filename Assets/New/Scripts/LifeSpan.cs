using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeSpan : MonoBehaviour
{
    private float timer;
    public float maxTimer;
    // Start is called before the first frame update
    void Start()
    {
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Timeling();
    }

    void Timeling()
    {
        timer += Time.deltaTime;
        if (timer > maxTimer)
        {
            Destroy(gameObject);
        }
    }
}
