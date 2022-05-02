using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletTime : MonoBehaviour
{
    private float timer;
    private Rigidbody rb;
    [HideInInspector]
    public Vector3 angler;
    [HideInInspector]
    public string tagName;
    [HideInInspector]
    public int damage;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.velocity = new Vector3(angler.x, angler.y, angler.z);
    }

    // Update is called once per frame
    void Update()
    {
        Timerling();
    }
    
    void Timerling()
    {
        timer += Time.deltaTime;
        if (timer > 3)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(tagName))
        {
            if (other.GetComponent<Life>() != null)
            {
                other.GetComponent<Life>().ReduceLife(damage);
            }
            else if(other.GetComponent<EnemyLife>() != null)
            {
                other.GetComponent<EnemyLife>().ChangeLife(-damage);
            }
            Destroy(gameObject);
            damage = 0;
        }
    }
}
